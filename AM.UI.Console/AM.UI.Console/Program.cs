// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");


ServiceFlight serviceflight = new ServiceFlight();
serviceflight.Flights = TestData.listFlights;


//Console.WriteLine(  "question 1 ");
//foreach (var item in serviceflight.GetFlightDates("Paris"))
//  Console.WriteLine(item);

Console.WriteLine("question 2 ");
serviceflight.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("question 3");

Console.WriteLine(serviceflight.ProgrammedFlighNumber(new DateTime (2022, 05, 01, 17, 10, 10)));

Console.WriteLine("question 4");

Console.WriteLine(serviceflight.DurationAverage("Paris"));

Console.WriteLine("question 5");

foreach (var item in serviceflight.OrderedDurationFlights())
{
    Console.WriteLine(item.EstimatedDuration);
}


Console.WriteLine("question 6");

foreach (var item in serviceflight.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item.FirstName);
}

Console.WriteLine("question 7");

serviceflight.DestinationGroupedFlights();


//serviceflight.FlightDetailsDel(TestData.BoingPlane);
//Console.WriteLine(serviceflight.DurationAverageDel("Paris"));