using Core.Enums;
using Core.Interface;

namespace Core.Entities
{
    public class Day : IDay
    {
        public int Id { get; set; }
        public Language? Language { get; set; }
        public DayType? DayType { get; set; }
        public string? Value { get; set; }
    }
}
