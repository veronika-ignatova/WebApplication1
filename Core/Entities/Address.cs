using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Address : IAddress
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public string? Index { get; set; }
    }
}
