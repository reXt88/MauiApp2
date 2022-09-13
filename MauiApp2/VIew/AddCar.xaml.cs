using MauiApp2.Model;
using MauiApp2.Services;
using MauiApp2.ViewModel;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MauiApp2.VIew;

public partial class AddCar : ContentPage
{
	public AddCar()
	{
		InitializeComponent();
        GetCarsAsync();
    }
    ObservableCollection<Car> Cars { get; } = new();
    async Task GetCarsAsync()
    {
        try
        {
            var cars = await carService.GetCar();
            if (Cars.Count != 0)
                Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка!", $"Что-то пошло не так: {ex.Message}", "OK");
        }
    }

    public void SaveButtonClicked(object sender, EventArgs e)
	{
        Random random = new Random();
        int a = random.Next(100000);
        var car = new Car()
        {
            ID = random.Next(1000000),
            Brand = Convert.ToString(BrandEntry.Text),
            Description = Convert.ToString(DescriptionEntry.Text),
            Image = "cvbdcf"
        };
        Cars.Add(car);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonStr = JsonSerializer.Serialize(Cars, options);
        File.WriteAllText(@"C:\Users\seva8\source\repos\MauiApp2\MauiApp2\Resources\Raw\Cars.json", jsonStr);
    }
}
