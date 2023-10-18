using Core.Entities;
using Core.Enums;

namespace Core.Interface.Service
{
    public interface IDayService
    {
        Week GetWeekDaysByLanguage(Language language);
    }
}
