using Core.Enums;
using Core.Interface.Repository;

namespace DataBase
{
    public class DayRepository : IDayRepository
    {
        protected readonly MyDbContext _myDbContext;
        public DayRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public IDictionary<DayType, string> GetDaysByLanguage(Language language)
        {
            var days = _myDbContext.Days;
            var dictionary = new Dictionary<DayType, string>();
            foreach (var day in days)
            {
                if (day.Language == language)
                {
                    dictionary.Add(day.DayType ?? DayType.None, day.Value);
                }
            }
            return dictionary;
        }
    }
}
