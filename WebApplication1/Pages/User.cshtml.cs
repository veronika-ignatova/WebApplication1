using Core.Entities;
using Core.Interface;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BootCampWeb.Pages
{
    public class UserEditModel : PageModel
    {
        protected readonly IUserService _userService;

        public UserEditModel(IUserService userService)
        {
            _userService = userService;
        }

        public IUser? User { get; set; }
        public void OnGet(Guid id)
        {
            User = _userService.GetUserById(id);
        }
    }
}
