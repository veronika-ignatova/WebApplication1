using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class MyDbContext : DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<Address> Addresses { get; set; }
        internal DbSet<Day> Days { get; set; }
        internal DbSet<Image> Images { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }
        public MyDbContext()
        {
        }
    }
}