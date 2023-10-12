using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class MyDbContext : DbContext
    {
        internal DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }
    }
}