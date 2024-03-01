using Microsoft.EntityFrameworkCore;
using PizzaDot.Models;

namespace PizzaDot
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public virtual DbSet <Pizza> Pizza { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}
