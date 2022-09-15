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
            if (carlist?.Count > 0)
                return carlist;
            var stream = await File.ReadAllTextAsync("C:\\Users\\seva8\\source\\repos\\MauiApp2\\MauiApp2\\Resources\\Raw\\Cars.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            carlist = JsonSerializer.Deserialize<List<Car>>(stream);
            return carlist;
        }
    }
}
