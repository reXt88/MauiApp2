using MauiApp2.Model;
using MauiApp2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.ViewModel
{
    internal class CarViewModel : BindableObject
    {
        public Car _selectedItem;
        carService carService = new();
        public ObservableCollection<Car> Cars { get; } = new();
        public CarViewModel()
        {
            GetCarsAsync();
        }
        public string Desc { get; set; }
        public Car SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                Desc = value?.Description;
                OnPropertyChanged(nameof(Desc));
            }
        }
        public async Task GetCarsAsync()
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
    }
}
