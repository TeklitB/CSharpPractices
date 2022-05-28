using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace CSharoLINQ
{
    public class CarData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("car_make")]
        public string Make { get; set; }
        [JsonPropertyName("car_model")]
        public string Model { get; set; }
        [JsonPropertyName("car_year")]
        public int Year { get; set; }
        [JsonPropertyName("number_of_doors")]
        public int NumberOfDoors { get; set; }
        [JsonPropertyName("hp")]
        public int HP { get; set; }

        public async Task<List<CarData>> DeserializeCarDat(string fileName)
        {
            var fileContent = await File.ReadAllTextAsync(fileName);
            var cars = JsonSerializer.Deserialize<List<CarData>>(fileContent);

            return cars;
        }

        public void DisplayCars(List<CarData> cars)
        {
            //// Print all cars with at least 4 doors
            //var carsWithAtleastFourDoors = cars.Where(x => x.NumberOfDoors >= 4).ToList();
            //foreach (var car in carsWithAtleastFourDoors)
            //{
            //    Console.WriteLine($"The car {car.Model} has {car.NumberOfDoors} of doors.");
            //}

            // Print all Mazda cars with atleast four doors.
            //var mazdasWithAtleastFourDoors = cars.Where(car => car.Make == "Mazda" && car.NumberOfDoors >= 4);

            //foreach (var car in mazdasWithAtleastFourDoors)
            //{
            //    Console.WriteLine($"The {car.Make} car {car.Model} has {car.NumberOfDoors} of doors.");
            //}

            // Print Make + Model for all Makes that start with "M"
            //cars.Where(car => car.Make.StartsWith("M"))
            //    .Select(car => $"{car.Make} {car.Model}")
            //    .ToList()
            //    .ForEach(car => Console.WriteLine(car));

            // Print the top 10 most powerfull cars interms of HP
            //cars.OrderByDescending(car => car.HP)
            //    .Take(10)               
            //    .Select(car => $"{car.Make} - {car.Model} - {car.HP}")
            //    .ToList()
            //    .ForEach(car => Console.WriteLine(car));

            // Print the number of models per make that appear after 2008
            // Make zero if it does not appear after 2008
            //cars.GroupBy(car => car.Make)
            //    .ToList()
            //    .ForEach(c => Console.WriteLine(c.Key));
            //cars.GroupBy(car => car.Make)
            //    .Select(c => new {c.Key, NumberOfModels = c.Where(car => car.Year >= 2008).Count()})
            //    .ToList()
            //    .ForEach(item => Console.WriteLine($"{item.Key}: {item.NumberOfModels}"));

            // Print makes that have at least 2 models with >= 4800
            //cars.Where(car => car.HP >= 4800)
            //    .GroupBy(car => car.Make)
            //    .Select(c => new { Make = c.Key, NumberOfPowerfulCars = c.Count() })
            //    .Where(make => make.NumberOfPowerfulCars >= 2)
            //    .ToList()
            //    .ForEach(make => Console.WriteLine(make.Make));

            // Print the average HP per make
            //cars.GroupBy(car => car.Make)
            //    .Select(car => new {Make = car.Key, AverageHP = car.Average(c => c.HP)})
            //    .ToList()
            //    .ForEach(make => Console.WriteLine($"{make.Make} - {make.AverageHP}"));

            // How many makes build cars with HP between 0..100, 101..200, 201..300, 301..400, 401..500
            // Switch expression introduced in C# 9
            cars.GroupBy(car => car.HP switch
            {
                <= 100 => "0..100",
                <= 200 => "101..200",
                <= 300 => "201..300",
                <= 400 => "301..400",
                _ => "401..500"
            })
                .Select(car => new { HPCategory = car.Key, 
                    NumberOfMake = car.Select(c => c.Make).Distinct().Count() })
                .ToList()
                .ForEach(item => Console.WriteLine($"{item.HPCategory}: {item.NumberOfMake}"));

        }

    }
}
