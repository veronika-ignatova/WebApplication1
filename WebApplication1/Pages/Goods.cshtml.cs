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
            [MinLength(3)]
            [StringLength(50)]
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
