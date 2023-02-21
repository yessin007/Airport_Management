using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight 
    {
        List<DateTime> GetFlightDates(String destination);

        public void ShowFlightDetails(Plane plane);

        public int ProgrammedFlighNumber(DateTime startDate);

        public double DurationAverage(String destination);

        public IEnumerable<Flight> OrderedDurationFlights();

        public IEnumerable<Passenger> SeniorTravellers(Flight flight);

        public void DestinationGroupedFlights();
    }
}
