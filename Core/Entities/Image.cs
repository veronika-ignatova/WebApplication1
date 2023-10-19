using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Image : IImage
    {
        public string? Name { get; set; }
        public byte[]? Data { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}