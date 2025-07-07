using CsvHelper.Configuration.Attributes;

namespace OfertasCsv.Entity
{
    public class ItineraryOffer
    {
        [Name("SHIP_CODE")]
        public string ShipCode { get; set; }

        [Name("SAIL_CODE")]
        public string SailCode { get; set; }

        [Name("SAIL_DATE")]
        public DateTime SailDate { get; set; }

        [Name("RETURN_DATE")]
        public DateTime ReturnDate { get; set; }

        [Name("CRUISE_LENGTH")]
        public int CruiseLength { get; set; }

        [Name("ORIGINATING_PORT")]
        public string OriginatingPort { get; set; }

        [Name("DESTINATION_PORT")]
        public string DestinationPort { get; set; }

        [Name("ITIN_DESCRIPTION")]
        public string ItineraryDescription { get; set; }

        [Name("DAY_OF_CRUISE")]
        public int DayOfCruise { get; set; }

        [Name("BERTH_DATE")]
        public DateTime BerthDate { get; set; }

        [Name("ARRIVAL_TIME")]
        public string ArrivalTime { get; set; } 

        [Name("DEPARTURE_TIME")]
        public string DepartureTime { get; set; }

        [Name("COUNTRY_CODE")]
        public string CountryCode { get; set; }

        [Name("PORT_CODE")]
        public string PortCode { get; set; }

        [Name("PORT_NAME")]
        public string PortName { get; set; }

        [Name("OVERNIGHT_FLAG")]
        public char OverNightFlag { get; set; }




        public override string ToString()
        {
            return ShipCode +
                " - " +
                SailCode +
                " - " +
                PortName;
        }
    }
}
