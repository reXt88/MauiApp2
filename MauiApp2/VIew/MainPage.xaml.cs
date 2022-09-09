using MauiApp2.ViewModel;

namespace MauiApp2;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new CarViewModel();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{

	}
}

