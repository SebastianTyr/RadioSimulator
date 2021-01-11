using System;
using Microsoft.EntityFrameworkCore;
using RadioConsole.Web.Entities;
using RadioConsole.Web.Models;

namespace RadioConsole.Web.Database
{
    public class RadioDBContext : DbContext
    {
        public RadioDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RadioEntity> Radios { get; set; }

        public RadioEntity Delete(RadioEntity deletedRadio)
        {
            var entity = Radios.Attach(deletedRadio);
            entity.Context.Entry(deletedRadio).State = EntityState.Deleted;
            return deletedRadio;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //fluent configuration
        }

        public DbSet<RadioConsole.Web.Models.RadioModel> RadioModel { get; set; }
    }
}