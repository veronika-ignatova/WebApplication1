using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    internal class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
        public Address? Address { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }
        [Range(0,100)]
        public int? Age { get; set; }
        public DateTime? CreateDate { get; set; }
        [MinLength(5)]
        [StringLength(50)]
        public string? Password { get; set; }
    }
}
