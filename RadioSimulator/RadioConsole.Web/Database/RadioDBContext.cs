using System;
using Microsoft.EntityFrameworkCore;
using RadioConsole.Web.Entities;

namespace RadioConsole.Web.Database
{
    public class RadioDBContext : DbContext
    {
        public RadioDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RadioEntity> Radios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //fluent configuration
        }
    }
}