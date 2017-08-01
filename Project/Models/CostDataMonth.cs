namespace GAForecast.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CostDataMonth
    {
        public int Id { get; set; }

        public decimal? Arbetskostnad { get; set; }

        public decimal? Materialkostnad { get; set; }

        public decimal? Verktygskostnad { get; set; }

        public DateTime? Rapporteringsdatum { get; set; }
    }
}
