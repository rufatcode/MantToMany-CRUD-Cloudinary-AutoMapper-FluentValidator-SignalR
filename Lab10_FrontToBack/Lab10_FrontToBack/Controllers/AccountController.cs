using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.Services.Interfaces;
using Lab10_FrontToBack.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab10_FrontToBack.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISendEmail _sendEmail;
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, ISendEmail sendEmail)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _sendEmail = sendEmail;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (await _userManager.Users.AnyAsync(u => u.UserName.ToLower() == registerVM.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "UserName must be unique for every users");
                return View();
            }
            AppUser appUser = new();
            appUser.Email = registerVM.Email;
            appUser.FullName = registerVM.FullName;
            appUser.UserName = registerVM.UserName;
            appUser.Created = DateTime.Now;
            appUser.IsActive = true;

            IdentityResult resoult = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!resoult.Succeeded)
            {
                foreach (var error in resoult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(appUser, "User");
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string link = Url.Action(nameof(VerifyEmail), "Account", new { VerifyEmail = appUser.Email, token }, Request.Scheme, Request.Host.ToString());

            string verificationMessageBody = string.Empty;
            using (StreamReader fileStream = new StreamReader("wwwroot/Verification/VerificationEmail.html"))
            {
                verificationMessageBody = await fileStream.ReadToEndAsync();
            }
            verificationMessageBody = verificationMessageBody.Replace("{{link}}", link);
            verificationMessageBody = verificationMessageBody.Replace("{{userName}}", appUser.UserName);
            _sendEmail.Send("rufatri@code.edu.az", "Allup", appUser.Email, verificationMessageBody, "Confirm Account");
            TempData["Verify"] = "Please verify your account";
            return RedirectToAction("Login", "Account");
        }
        public async Task<IActionResult> VerifyEmail(string VerifyEmail, string token)
        {
            /*
            AppUser appUser =await _userManager.FindByEmailAsync(VerifyEmail);
            if (appUser==null)
            {
                return NotFound();
            }
            var IsExpired = await _userManager.VerifyUserTokenAsync(appUser, _userManager.Options.Tokens.EmailConfirmationTokenProvider, "VerifyEmail", token);
            if (!IsExpired)
            {
                return RedirectToAction("TokenIsNotValid");
            }
            */
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> VerifyEmail(string VerifyEmail, string token, int id)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(VerifyEmail);
            if (appUser == null)
            {
                return RedirectToAction("TokenIsNotValid");
            }
            await _userManager.ConfirmEmailAsync(appUser, token);
            await _userManager.UpdateSecurityStampAsync(appUser);

            return RedirectToAction("Login");
        }
        public IActionResult TokenIsNotValid()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.EmailOrUserName);
            if (appUser == null)
            {
                appUser = await _userManager.FindByNameAsync(loginVM.EmailOrUserName);
                if (appUser == null)
                {
                    ModelState.AddModelError("EmailOrUserName", "Invalid User");
                    return View();
                }
            }
            if (!appUser.IsActive)
            {
                ModelState.AddModelError("", "User is blocked");
                return View();
            }
            var resoult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.IsRemember, true);
            if (resoult.IsLockedOut)
            {
                ModelState.AddModelError("", "User is blocked");
                return View();
            }
            else if (!appUser.EmailConfirmed)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
            else if (!resoult.Succeeded)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
            await _signInManager.SignInAsync(appUser, loginVM.IsRemember);
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "User is not valid");
                return View();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
            string link = Url.Action(nameof(ResetPassword), "Account", new { email = appUser.Email, token }, Request.Scheme, Request.Host.ToString());

            string resetPasswordBody = string.Empty;
            using (StreamReader stream = new StreamReader("wwwroot/Verification/ResetPassword.html"))
            {
                resetPasswordBody = await stream.ReadToEndAsync();
            };
            resetPasswordBody = resetPasswordBody.Replace("{{link}}", link);
            resetPasswordBody = resetPasswordBody.Replace("{{userName}}", appUser.UserName);
            _sendEmail.Send("rufatri@code.edu.az", "Allup", appUser.Email, resetPasswordBody, "Reset Password");


            return RedirectToAction("Login", "Account");
        }
        public async Task<IActionResult> ResetPassword(string email, string token)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null)
            {
                return RedirectToAction("TokenIsNotValid");
            }
            var resoult = await _userManager.VerifyUserTokenAsync(appUser, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
            if (!resoult)
            {
                return RedirectToAction("TokenIsNotValid");
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ResetPassword(string email, string token, ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            IdentityResult resoult = await _userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.Password);
            if (!resoult.Succeeded)
            {
                foreach (var error in resoult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.UpdateSecurityStampAsync(appUser);
            return RedirectToAction("Login");
        }
    }
}

