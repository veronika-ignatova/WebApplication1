using Core.Interface;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BootCampWeb.Pages
{
    public class UsersModel : PageModel
    {
        protected readonly IUserService _userService;
        public UsersModel(IUserService userService)
        {
            _userService = userService;
        }
        public IEnumerable<IUser> Users { get; set; }
        
        public void OnGet()
        {
            Users = _userService.GetAllUsers();
        }
    }
}
