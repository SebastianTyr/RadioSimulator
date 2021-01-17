using System;
using System.Linq;
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

        public RadioEntity RetrieveDataToEdit(int id)
        {
            var rawData = Radios.Where(r => r.Id == id).FirstOrDefault();

            return rawData;
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
            builder.Entity<RadioEntity>(entity =>
            {

                entity.HasKey(r => r.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}