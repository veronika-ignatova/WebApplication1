using Core.Interface;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BootCampWeb.PageModels;
using Core.Enums;

namespace WebApplication1.Pages
{
    public class GoodsModel : PageModel
    {
        protected readonly IUserService _userService;

        public ResultModel Response { get; set; }
        public IEnumerable<UserModel> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public UserModel Input { get; set; }

        public GoodsModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
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
                    Response = new ResultModel() { ResultType = ResultType.Success, Message = $"User {Input.Name} was created" };
                }
                else
                {
                    Response = new ResultModel() { ResultType = ResultType.Error, Message = $"User {Input.Name} was not created" };
                }
            }
            else
            {
                Response = new ResultModel() { ResultType = ResultType.Error, Message = $"User {Input.Name} was not created" };
            }
        }
        public IActionResult OnPostCheckEmail(string email)
        {
            return new JsonResult(_userService.IsUsedEmail(email));
        }

    }
}
