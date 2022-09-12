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
	}
}

