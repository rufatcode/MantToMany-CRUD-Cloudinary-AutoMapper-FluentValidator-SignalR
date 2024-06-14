using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab10_FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab10_FrontToBack.Controllers
{
    public class ChatController : Controller
    {
        // GET: /<controller>/
        private readonly UserManager<AppUser> _userManager;
        public ChatController(UserManager<AppUser>userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _userManager.Users.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null) return BadRequest();
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null) return NotFound();
            

            return Ok(appUser);
        }
    }
}

