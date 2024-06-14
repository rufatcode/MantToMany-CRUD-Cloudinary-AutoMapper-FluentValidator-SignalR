using System;
using System.ComponentModel.DataAnnotations;

namespace Lab10_FrontToBack.ViewModels.AccountVM
{
    public class ResetPasswordVM
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(ConfirmPassword), ErrorMessage = "Password and Confirm Password must be same")]
        public string ConfirmPassword { get; set; }
        public ResetPasswordVM()
        {
        }
    }
}

