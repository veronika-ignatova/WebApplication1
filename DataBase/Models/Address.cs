using Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    internal class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(100)]
        public string? City { get; set; }
        [StringLength(100)]
        public string? Country { get; set; }
        [StringLength (100)]
        public string? Street { get; set; }
        [StringLength(100)]
        [Required]
        public string? Index { get; set; }
    }
}
