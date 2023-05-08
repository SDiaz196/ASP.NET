namespace Session_Workshop.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Required(ErrorMessage = "Name should be at least 2 characters")]
    [MinLength(2)]
    [Display(Name = "Please enter your name:")]
    public string Name { get; set; }
}