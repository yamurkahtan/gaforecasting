namespace GAForecast.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StationaryCostData")]
    public partial class StationaryCostData
    {
        public int Id { get; set; }

        public decimal? Arbetskostnad { get; set; }

        public decimal? Materialkostnad { get; set; }

        public decimal? Verktygskostnad { get; set; }

        public DateTime? Rapporteringsdatum { get; set; }

        public decimal? lags_Arbetskostnad { get; set; }

        public decimal? lags_Materialkostnad { get; set; }

        public decimal? lags_Verktygskostnad { get; set; }
    }
}
