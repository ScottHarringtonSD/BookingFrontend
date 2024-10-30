using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace BookingFrontEnd.Models;

public class Credentials{

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public Credentials(){
        Username = string.Empty;
        Password = string.Empty;
    }

    public Credentials(string username, string password){
        Username = username;
        Password = password;
    }

}