using MauiApp2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp2.Services
{
    internal class carService
    {
        static List<Car> carlist = new();
        public static async Task<IEnumerable<Car>> GetCar()
        {
            if (carlist?.Count > 0)
                return carlist;
            using var stream = await FileSystem.OpenAppPackageFileAsync("Cars.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            carlist = JsonSerializer.Deserialize<List<Car>>(contents);
            return carlist;
        }
    }
}
