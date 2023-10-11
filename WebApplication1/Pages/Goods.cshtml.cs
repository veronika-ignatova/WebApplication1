using Core.Interface;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class GoodsModel : PageModel
    {
        public IEnumerable<UserModel> Users { get; set; }
        protected readonly IUserService _userService;
        public GoodsModel(IUserService userService)
        {
            _userService = userService;
        }
        public class UserModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [Required]
            [StringLength(50, MinimumLength =3)]
            [Display(Name = "Name", Prompt = "Enter your name")]
            public string? Name { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email", Prompt = "Enter your email")]
            public string? Email { get; set; }
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
            [Required]
            [Compare("Password", ErrorMessage = "Passwords must be equal")]
            [DataType(DataType.Password)]
            [Display(Name = "Repeat password", Prompt = "Enter your password again")]
            public string? ConfirmPassword { get; set; }
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public UserModel Input { get; set; }
        public Result Response { get; set; }
        public enum ResultType
        {
            Success,
            Error
        }

        public class Result
        {
            public ResultType ResultType { get; set; }
            public string? Message { get; set; }
        }
        public void OnPost()
        {
            ModelState.Remove("Input.Id");
            if(!string.IsNullOrEmpty(Input?.Email) && _userService.IsUsedEmail(Input?.Email))
            {
                ModelState.AddModelError("Input.Email", "This email can`t be used");
            }

            if (!ModelState.IsValid)
            {
                return;
            }
            if (Input != null)
            {
                var user = new User() { Name = Input.Name, Age = Input.Age, Email = Input.Email, Password = Input.Password };

                if (_userService.CreateUser(user))
                {
                    Response = new Result() { ResultType = ResultType.Success, Message = $"User {Input.Name} was created" };
                }
                else
                {
                    Response = new Result() { ResultType = ResultType.Error, Message = $"User {Input.Name} was not created" };
                }
            }
            else
            {
                Response = new Result() { ResultType = ResultType.Error, Message = $"User {Input.Name} was not created" };
            }
        }

    }
}
