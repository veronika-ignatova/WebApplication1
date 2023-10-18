using Core.Enums;

namespace Core.Interface.Repository
{
    public interface IDayRepository
    {
        IDictionary<DayType, string> GetDaysByLanguage(Language language);

    }
}
