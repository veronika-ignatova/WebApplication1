using Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
        public int AddressId { get; set; }
        public int? Age { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Password { get; set; }
    }
}
