using System;
using System.ComponentModel.DataAnnotations;

namespace shop.Pages;

public partial class Register
{
    [Required(ErrorMessage = "Username error")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password error")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password didnt match!")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}

