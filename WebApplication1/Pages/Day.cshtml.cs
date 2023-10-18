using Core.Entities;
using Core.Enums;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BootCampWeb.Pages
{
    public class DayModel : PageModel
    {
        protected readonly IDayService _dayService;
        public DayModel(IDayService dayService)
        {
            _dayService = dayService;
        }
        public Week Week { get; set; }
        [BindProperty]
        public Language Language { get; set; }
        public void OnGet()
        {

        }
        public void OnPost() 
        {
            Week = _dayService.GetWeekDaysByLanguage(Language);
        }
    }
}
