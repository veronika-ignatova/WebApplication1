using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum DayType
    {
        None,
        [Display(Name = "Понеділок")]
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
