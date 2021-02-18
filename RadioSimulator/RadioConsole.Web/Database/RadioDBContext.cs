using System;
using System.Collections.Generic;
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

        public DbSet<RadioEntity> Radios { get; set; }

        public DbSet<UsersEntity> Users { get; set; }

        public DbSet<IncidentEntity> Incidents { get; set; }

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

        public DbSet<RadioConsole.Web.Models.IncidentModel> IncidentModel { get; set; }
    }
}