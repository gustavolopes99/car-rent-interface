using System.Globalization;
using Primeiro.Entities;
using Primeiro.Services;

namespace Primeiro
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car Model: ");
            var model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            var start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            var finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var carRental = new CarRental(start, finish, new Vehicle(model));

            var rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine(carRental.Invoice);




        }
    }
}