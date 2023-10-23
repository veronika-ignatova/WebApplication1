using Core.Entities;
using Core.Enums;
using Core.Interface.Repository;
using Core.Interface.Service;

namespace Core.Service
{
    public class DayService : IDayService
    {
        protected readonly IDayRepository dayRepository;
        public DayService(IDayRepository dayRepository)
        {
            this.dayRepository = dayRepository;
        }
        public Week GetWeekDaysByLanguage(Language language)
        {
            var days = dayRepository.GetDaysByLanguage(language);
            var defaultDays = dayRepository.GetDaysByLanguage(Language.English);
            var allDays = Enum.GetValues<DayType>();
            Dictionary<DayType, string> week = new Dictionary<DayType, string>();
            //var a = allDays.Skip(1).Where(days.ContainsKey).Select(x => x, x=> days[x]);
            foreach (var day in allDays)
            {
                if (day == DayType.None) continue;
                if (days.ContainsKey(day)) week.Add(day, days[day]);
                else week.Add(day, defaultDays[day]);
            }
            return new Week(week);
        }
    }
}
