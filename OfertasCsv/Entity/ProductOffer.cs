using CsvHelper.Configuration.Attributes;

namespace OfertasCsv.Entity
{
    public class ProductOffer
    {
        [Name("DESTINATION")]
        public string Destination { get; set; }

        [Name("ID")]
        public string ProductId { get; set; } = string.Empty;

        [Name("SHIP")]
        public string ShipName { get; set; }

        [Name("NAME")]
        public string ProductName { get; set; }

        [Name("SAIL_TYPE")]
        public string SailType { get; set; }

        [Name("DURATION")]
        public int? Duration { get; set; }

        [Name("EMBARK_DATE_TIME")]
        public DateTime EmbarkDate { get; set; }

        [Name("DEBARK_DATE_TIME")]
        public DateTime DebarkDate { get; set; }

        [Name("EMBARK_PORT")]
        public string EmbarkPortCode { get; set; }

        [Name("DEBARK_PORT")]
        public string DebarkPortCode { get; set; }

        [Name("CATEGORY_RANK")]
        public int CategoryRank { get; set; }

        [Name("CATEGORY")]
        public string CategoryCode { get; set; }

        [Name("CATEGORY_NAME")]
        public string CategoryName { get; set; }

        [Name("CURRENCY")]
        public string Currency { get; set; }

        [Name("CRUISE_FARE")]
        public double CruiseFare { get; set; }

        [Name("NCCF")]
        public double NCCF { get; set; }

        [Name("GOV_TAXES")]
        public double GovTaxes { get; set; }

        [Name("DISCOUNT")]
        public double Discount { get; set; }

        [Name("AVAILABILITY")]
        public string Available { get; set; }

        [Name("PORT_FEES")]
        public double PortFees { get; set; }

        public List<ItinenaryOffer> Itinerary { get; set; }
    }


    
}

