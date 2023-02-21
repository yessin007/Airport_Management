using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        
        

        //public List<DateTime> GetFlightDates(String destination)
        //{
        //    List<DateTime> result = new List<DateTime>();
        //    for (int i = 0; i < Flights.Count; i++)
        //    {
        //        if (Flights[i].Destination.Equals(destination))
        //        {
        //            result.Add(Flights[i].FlightDate);
        //        }
        //    }
        //    return result;
        //}

        /// methode foreach
        public List<DateTime> GetFlightDates(String destination)
        {

            /*
             * foreach method
             * 
            List<DateTime> result = new List<DateTime>();
            foreach (var flight in Flights)
            {
                if(flight.Destination.Equals(destination))
                {
                    result.Add(flight.FlightDate);
                }
            }
            return result;

            */


            /*
             *  LINQ method
             
            var query = from flight in Flights
                        where flight.Destination == destination
                        select flight.FlightDate;
            return query.ToList();
            */



            /*
             *lambda
             return Flights.Where(p=> p.Destination == destination).Select(p=> p.FlightDate).ToList(); 
             * */
            return null;

        }




        public void ShowFlightDetails(Plane plane)
        {
            /*
             * foreach method
             * 
            foreach (var flight in Flights)
            {
                if (flight.Plane== plane)
                {
             
                Console.WriteLine(" Destination --> " + flight.Destination + " dans le date ---> " + flight.FlightDate);
                }
            }
            */


            /*
             *  LINQ method
             * 

            var query = from flight in Flights
                        where flight.Plane == plane
                        select new { flight.Destination , flight.FlightDate };
            foreach( var item in query)
            {
                Console.WriteLine("  Destination --> " + item.Destination + " dans le date ---> " + item.FlightDate);
            }
            */


            /*
             * Lambda method
             *
            var queryLambda = Flights.Where(f => f.Plane == plane).Select(f=>f);
            
            foreach (var item in queryLambda)
            {
                Console.WriteLine(item.FlightDate + "   " + item.Destination);
            }
            */
        }

        public int ProgrammedFlighNumber(DateTime startDate)
        {
            /*
             * foreach method
             * 
            int result = 0;
            foreach(var flight in Flights)
            {
                if (flight.FlightDate>=startDate &&flight.FlightDate<=startDate.AddDays(7))
                {
                    result++;
                }
            }
            return result;
            */


            /*
             * LINQ method
             * 
            var query = from flight in Flights
                        where flight.FlightDate>= startDate && flight.FlightDate<= startDate.AddDays(7)
                        select flight;
            return query.Count();
            */


            /*
             * Lambda method 
             * */

            var queryLambda = Flights.Where(f => f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7))
                                     .Count();
            return queryLambda;
            
        }




        public double DurationAverage(string destination)
        {
            /*
            *  foreach method
            *
            

            float result = 0;
            int i = 0;
            foreach(var flight in Flights)
            {
                if (flight.Destination.Equals(destination))
                {
                    result = (result + flight.EstimatedDuration);
                    i++;
                }
            }
            return result/i;
            */


            /*
            *  LINQ method
            *
            *
            var query = from flight in Flights
                        where flight.Destination == destination
                        select flight.EstimatedDuration;
            
            return query.Average();
            */



            /*
             * Lambda method
             * */
            var queryLambda = Flights.Where(f => f.Destination == destination)
                    .Select(f => f.EstimatedDuration).Average();
            return queryLambda;

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            /*
             * List<Flight> flights = new List<Flight>();

            foreach (var flight in Flights)
            {
                
                //flights.Add(flight.EstimatedDuration);
            }
            return flights;
            */

            
            /*
             * LINQ method
             *
             */

            var query = from flight in Flights
                        orderby flight.EstimatedDuration descending
                        select flight;
            return query;
            
            /*
             * Lambda method
             * 
             * 
             var queryLambda = Flights.OrderByDescending(f => f.EstimatedDuration);
                
            return queryLambda.ToList();

             * */

        }


        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            /*
             * LINQ method
             * 
             */
            var query = from pass in flight.Passengers.OfType<Traveller>()   
                        orderby pass.BirthDate 
                        select pass;
            return query.Take(3);


            /*
             * Lambda method
             *
             *
            var queryLambda = flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate);
            return queryLambda.Take(3);
             
             * */
        }


        public void DestinationGroupedFlights()
        {
            /*
             * LINQ method
             * */
            var query = from flight in Flights.GroupBy(f => f.Destination)
                        select flight;
            foreach(var item in query)
            {
                Console.WriteLine("Destiantion " +item.Key);
                foreach(var item1 in item)
                {
                    Console.WriteLine( " Decoullage   dans la date  -->> " +item1.FlightDate  );
                }
            }


            /*
             * Lambda method
             * 
             * 
             var queryLambda = Flights.GroupBy(f => f.Destination)
                                     .Select(f=>f);

            foreach (var group in queryLambda)
            {
                Console.WriteLine("Destination " + group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("Decollage :" + item.FlightDate);
                }
            }
            return queryLambda;

            */
        }

        public Action<Plane> FlightDetailsDel;
        public Func<String, double> DurationAverageDel;
        public ServiceFlight()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            /*
            FlightDetailsDel = p => {


                var query = from flight in Flights
                            where flight.Plane == p
                            select flight;


                foreach (var item in query)
                {
                    Console.WriteLine(item.FlightDate);
                    Console.WriteLine(item.Destination);
                }
            };
            DurationAverageDel = d => {
                var query = from flight in Flights
                            where flight.Destination == d
                            select flight.EstimatedDuration;
                return query.Average();
            };
            */
        }
    }


}
