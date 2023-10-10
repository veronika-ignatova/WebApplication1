using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    internal class Users
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
        [Range(0,100)]
        public int? Age { get; set; }
        public DateTime? CreateDate { get; set; }
        [MinLength(5)]
        [StringLength(50)]
        public string? Password { get; set; }
    }
}
