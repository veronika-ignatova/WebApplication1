using Core.Entities;
using Core.Enums;
using Core.Interface.Repository;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
