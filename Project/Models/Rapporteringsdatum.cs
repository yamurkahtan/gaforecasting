namespace GAForecast.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rapporteringsdatum")]
    public partial class Rapporteringsdatum
    {
        public int Id { get; set; }

        public string Placering { get; set; }

        public string Placeringens_beskrivning { get; set; }

        public string Arbetsorder { get; set; }

        public int? överliggande_ao { get; set; }

        [Column(TypeName = "ntext")]
        public string Arbetsorderbeskrivning_och_långtext { get; set; }

        [Column("Rapporteringsdatum")]
        public DateTime? Rapporteringsdatum1 { get; set; }

        public DateTime? Verkligt_startdatum { get; set; }

        public DateTime? verkligt_slutdatum { get; set; }

        public string Arbetstyp { get; set; }

        public string Problemkod { get; set; }

        public string Problemkodsbeskrivning { get; set; }

        public string Orsakskod { get; set; }

        public string Orsaksbeskrivning { get; set; }

        public string Åtgärdskod { get; set; }

        public string Åtgärdskodsbeskrivning { get; set; }

        [Column(TypeName = "ntext")]
        public string Beskrivning_av_utfört_arbete_och_långtext { get; set; }

        public int? Antal_timmar { get; set; }

        public decimal? Arbetskostnad { get; set; }

        public decimal? Materialkostnad { get; set; }

        public decimal? Verktygskostnad { get; set; }
    }
}
