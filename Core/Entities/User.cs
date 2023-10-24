using Core.Interface;

namespace Core.Entities
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public IAddress? Address { get; set; }
        public int? AddressId { get; set; }
        public int? Age { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Password { get; set; }
    }
}
