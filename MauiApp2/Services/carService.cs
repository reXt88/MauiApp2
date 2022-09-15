using MauiApp2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace MauiApp2.Services
{
    internal class carService
    {
        public static List<Car> carlist = new();
        public static async Task<IEnumerable<Car>> GetCar()
        {
            string pathToCarsJson = AppDomain.CurrentDomain.BaseDirectory + "Cars.json";
            if (carlist?.Count > 0)
                return carlist;
            var stream = await File.ReadAllTextAsync(pathToCarsJson);
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            carlist = JsonSerializer.Deserialize<List<Car>>(stream);
            return carlist;
        }
    }
}
