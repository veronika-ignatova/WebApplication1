using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCampWeb.PageModels
{
    public class UserEditViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Name", Prompt = "Enter your name")]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Enter your email")]
        public string? Email { get; set; }
        public AddressModel? Address { get; set; }
        [Required]
        [Range(18, 99)]
        [Display(Name = "Age", Prompt = "Enter your age")]
        public int? Age { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(16)]
        //[RegularExpression("^((?=.?[A-Z])(?=.?[a-z])(?=.?[0-9])|(?=.?[A-Z])(?=.?[a-z])(?=.?[^a-zA-Z0-9])|(?=.?[A-Z])(?=.?[0-9])(?=.?[^a-zA-Z0-9])|(?=.?[a-z])(?=.?[0-9])(?=.?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Display(Name = "Password", Prompt = "Enter your password")]
        public string? Password { get; set; }

        public ResultModel? Result { get; set; }
    }
}
