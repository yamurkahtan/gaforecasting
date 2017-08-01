namespace GAForecast.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<CostDataMonth> CostDataMonths { get; set; }
        public virtual DbSet<Rapporteringsdatum> Rapporteringsdatums { get; set; }
        public virtual DbSet<StationaryCostData> StationaryCostDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostDataMonth>()
                .Property(e => e.Arbetskostnad)
                .HasPrecision(12, 4);

            modelBuilder.Entity<CostDataMonth>()
                .Property(e => e.Materialkostnad)
                .HasPrecision(12, 4);

            modelBuilder.Entity<CostDataMonth>()
                .Property(e => e.Verktygskostnad)
                .HasPrecision(12, 4);

            modelBuilder.Entity<Rapporteringsdatum>()
                .Property(e => e.Arbetskostnad)
                .HasPrecision(12, 4);

            modelBuilder.Entity<Rapporteringsdatum>()
                .Property(e => e.Materialkostnad)
                .HasPrecision(12, 4);

            modelBuilder.Entity<Rapporteringsdatum>()
                .Property(e => e.Verktygskostnad)
                .HasPrecision(12, 4);

            modelBuilder.Entity<StationaryCostData>()
                .Property(e => e.Arbetskostnad)
                .HasPrecision(10, 6);

            modelBuilder.Entity<StationaryCostData>()
                .Property(e => e.Materialkostnad)
                .HasPrecision(10, 6);

            modelBuilder.Entity<StationaryCostData>()
                .Property(e => e.Verktygskostnad)
                .HasPrecision(10, 6);

            modelBuilder.Entity<StationaryCostData>()
                .Property(e => e.lags_Arbetskostnad)
                .HasPrecision(10, 6);

            modelBuilder.Entity<StationaryCostData>()
              .Property(e => e.lags_Materialkostnad)
              .HasPrecision(10, 6);

            modelBuilder.Entity<StationaryCostData>()
              .Property(e => e.lags_Verktygskostnad)
              .HasPrecision(10, 6);
        }
    }
}
