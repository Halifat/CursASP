using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace curs.Models
{
    public class BuildingContractorContext:DbContext
    {
        public BuildingContractorContext() : base("BuildingContractorContext")
        {

        }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<KindWork> KindWork { get; set; }
        public DbSet<TechnicalEquipment> TechnicalEquipment { get; set; }
        public DbSet<Objects> Objects { get; set; }
        public DbSet<Works> Works { get; set; }
        public DbSet<Materials> Materials { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Stock>()
                .HasMany(s => s.Materials)
                .WithRequired(e => e.Stock)
                .HasForeignKey(e => e.StockID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Objects>()
                .HasMany(s => s.Materials)
                .WithRequired(e => e.Objects)
                .HasForeignKey(e => e.ObjectsID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KindWork>()
                .HasMany(s => s.Works)
                .WithRequired(e => e.KindWork)
                .HasForeignKey(e => e.KindWorkID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Objects>()
                .HasMany(s => s.Works)
                .WithRequired(e => e.Objects)
                .HasForeignKey(e => e.ObjectsID);

        }


    }
}