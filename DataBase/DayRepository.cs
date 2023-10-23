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
            return _myDbContext.Days
                .Where(x => x.Language == language)
                .ToDictionary(x => x.DayType ?? DayType.None, x => x.Value);
        }
    }
}
