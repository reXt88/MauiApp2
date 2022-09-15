using MauiApp2.Model;
using MauiApp2.Services;
using MauiApp2.VIew;
using MauiApp2.ViewModel;

namespace MauiApp2;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
		BindingContext = new CarViewModel();

    }
	private async void b1Clicked(object sender, System.EventArgs e)
	{
		await Navigation.PushAsync(new AddCar());
        carService.carlist.Clear();
        CarViewModel cvm = new CarViewModel();
        cvm.GetCarsAsync();
    }

	private void changeButton_Clicked(object sender, EventArgs e)
	{
		//CarViewModel cvm = new CarViewModel();
		//cvm.GetPathToCarsJson();
    }
}