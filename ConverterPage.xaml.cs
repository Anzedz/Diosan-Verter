using Diosan_Verter.ViewModels;

namespace Diosan_Verter;

public partial class ConverterPage : ContentPage
{
    public ConverterPage(ConverterPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnBackClicked(object? sender, EventArgs e) => await Navigation.PopAsync();
}
