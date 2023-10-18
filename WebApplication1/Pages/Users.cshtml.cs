using Core.Interface;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BootCampWeb.Pages
{
    public class UsersModel : PageModel
    {
        protected readonly IUserService _userService;
        protected readonly IAddressService _addressService;
        public UsersModel(IUserService userService, IAddressService addressService)
        {
            _userService = userService;
            _addressService = addressService;
        }
        public IEnumerable<IUser> Users { get; set; }
        public IEnumerable<IAddress> Addresses { get; set; }
            public void OnGet()
        {
            Users = _userService.GetAllUsers();
        }
    }
}