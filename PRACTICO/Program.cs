using System;
using System.Collections.Generic;

public class Flight
{
    public string Airline { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public decimal Price { get; set; }
}

public class FlightSearch
{
    public static Flight FindCheapestFlight(List<Flight> flights, string origin, string destination, int month, int year)
    {
        Flight cheapestFlight = null;
        decimal minPrice = decimal.MaxValue;

        foreach (var flight in flights)
        {
            if (flight.Origin == origin && flight.Destination == destination &&
                flight.DepartureDate.Month == month && flight.DepartureDate.Year == year)
            {
                if (flight.Price < minPrice)
                {
                    minPrice = flight.Price;
                    cheapestFlight = flight;
                }
            }
        }
        return cheapestFlight;
    }

    public static void Main(string[] args)
    {
        List<Flight> flightDatabase = new List<Flight>()
        {
            new Flight { Airline = "Avianca", Origin = "GYE", Destination = "BOG", DepartureDate = new DateTime(2024, 7, 15), DepartureTime = new TimeSpan(08, 00, 00), Price = 250 },
            new Flight { Airline = "LATAM", Origin = "GYE", Destination = "LIM", DepartureDate = new DateTime(2024, 7, 15), DepartureTime = new TimeSpan(10, 00, 00), Price = 220 },
            new Flight { Airline = "Copa", Origin = "GYE", Destination = "PTY", DepartureDate = new DateTime(2024, 7, 16), DepartureTime = new TimeSpan(14, 00, 00), Price = 280 },
            new Flight { Airline = "American", Origin = "MIA", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 16), DepartureTime = new TimeSpan(16, 00, 00), Price = 350 },
            new Flight { Airline = "United", Origin = "IAH", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 17), DepartureTime = new TimeSpan(09, 00, 00), Price = 320 },
            new Flight { Airline = "Avianca", Origin = "BOG", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 17), DepartureTime = new TimeSpan(12, 00, 00), Price = 260 },
            new Flight { Airline = "LATAM", Origin = "LIM", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 18), DepartureTime = new TimeSpan(18, 00, 00), Price = 230 },
            new Flight { Airline = "Copa", Origin = "PTY", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 18), DepartureTime = new TimeSpan(20, 00, 00), Price = 290 },
            new Flight { Airline = "JetBlue", Origin = "JFK", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 19), DepartureTime = new TimeSpan(07, 00, 00), Price = 380 },
            new Flight { Airline = "Spirit", Origin = "FLL", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 19), DepartureTime = new TimeSpan(11, 00, 00), Price = 300 },
            new Flight { Airline = "LATAM", Origin = "GYE", Destination = "MAD", DepartureDate = new DateTime(2024, 7, 20), DepartureTime = new TimeSpan(15, 00, 00), Price = 700 },
            new Flight { Airline = "Iberia", Origin = "MAD", Destination = "GYE", DepartureDate = new DateTime(2024, 7, 21), DepartureTime = new TimeSpan(17, 00, 00), Price = 720 }
        };

        string originAirport = "GYE";
        string destinationAirport = "LIM";
        int searchMonth = 7;
        int searchYear = 2024;

        Flight cheapestFlightFound = FindCheapestFlight(flightDatabase, originAirport, destinationAirport, searchMonth, searchYear);

        if (cheapestFlightFound != null)
        {
            Console.WriteLine($"El vuelo más barato desde {originAirport} a {destinationAirport} en {searchMonth}/{searchYear} es con {cheapestFlightFound.Airline} el {cheapestFlightFound.DepartureDate.ToShortDateString()} a las {cheapestFlightFound.DepartureTime} por ${cheapestFlightFound.Price}");
        }
        else
        {
            Console.WriteLine($"No se encontraron vuelos de {originAirport} a {destinationAirport} en {searchMonth}/{searchYear}.");
        }
    }
}

// Desarrollado por los estudiantes:
// Jeffrey Jose Mayorga Angos
// Lucia Jeaneth Rodríguez Requelme
// Ana Lucía Toapanta Trujillo
