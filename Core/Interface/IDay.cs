using Core.Enums;

namespace Core.Interface
{
    public interface IDay
    {
        int Id { get; set; }
        Language? Language { get; set; }
        DayType? DayType { get; set; }
        string? Value { get; set; }
    }
}
