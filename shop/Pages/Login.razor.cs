using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace shop.Pages;


public partial class Login
{
    [Required(ErrorMessage = "Username error")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password error")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}

