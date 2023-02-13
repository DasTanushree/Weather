// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.IO;
using System.Linq;
namespace HelloWorld
{
    class Program
    {
        public static object JObject { get; private set; } = default!;

        static void Main(string[] args)
        {
            List<Weather> weatherList = new List<Weather>();
            string jsonFile = "Data.json";
            string json = File.ReadAllText(jsonFile);

            Console.WriteLine();
            Console.WriteLine("Enter your city: ");
            var icity = Console.ReadLine();
            if (json != null)
            {
                weatherList = JsonSerializer.Deserialize<List<Weather>>(json)!;
            }
            else
                System.Environment.Exit(0);

            if (weatherList != null)
            {
                var weather = from w in weatherList
                              where w.city.Equals(icity)
                              select new { w.city, w.lat, w.lng };
                foreach (var q in weather)
                {
                    Console.WriteLine($"latitude and longitude of {q.city} is : ( {q.lat} , {q.lng} )");
                }
            }


        }
    }
}
