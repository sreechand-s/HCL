using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Models
{

    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserDetails> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserDetails>().HasData(
                  new UserDetails()
                  {
                      id = 1,
                      name = "Midhun",
                      email = "midhun@gmail.com",
                      phone = "1234567890",
                      address = "address"
                  });

            builder.Entity<UserDetails>().HasData(
                new UserDetails()
                {
                    id = 2,
                    name = "Sreechand",
                    email = "sreechand@gmail.com",
                    phone = "1234567890",
                    address = "address",
                });
        }
    }
}
