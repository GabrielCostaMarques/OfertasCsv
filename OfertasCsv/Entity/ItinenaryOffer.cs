using CsvHelper.Configuration.Attributes;

namespace OfertasCsv.Entity
{
    public class ItineraryOffer
    {
        public ItineraryOffer()
        {
        }

        [Name("SHIP_CODE")]
        public string ShipCode { get; set; } = string.Empty;

        [Name("SAIL_CODE")]
        public string SailCode { get; set; } = string.Empty;

        [Name("SAIL_DATE")]
        public DateTime SailDate { get; set; }

        [Name("RETURN_DATE")]
        public DateTime ReturnDate { get; set; }

        [Name("CRUISE_LENGTH")]
        public int CruiseLength { get; set; }

        [Name("ORIGINATING_PORT")]
        public string OriginatingPort { get; set; } = string.Empty;

        [Name("DESTINATION_PORT")]
        public string DestinationPort { get; set; } = string.Empty;

        [Name("ITIN_DESCRIPTION")]
        public string ItineraryDescription { get; set; } = string.Empty;

        [Name("DAY_OF_CRUISE")]
        public int DayOfCruise { get; set; }

        [Name("BERTH_DATE")]
        public DateTime BerthDate { get; set; }

        [Name("ARRIVAL_TIME")]
        public string ArrivalTime { get; set; } = string.Empty;

        [Name("DEPARTURE_TIME")]
        public string DepartureTime { get; set; } = string.Empty;

        [Name("COUNTRY_CODE")]
        public string CountryCode { get; set; } = string.Empty;

        [Name("PORT_CODE")]
        public string PortCode { get; set; } = string.Empty;

        [Name("PORT_NAME")]
        public string PortName { get; set; } = string.Empty;

        [Name("OVERNIGHT_FLAG")]
        public char OverNightFlag { get; set; }

       
    }
}
