using Diosan_Verter;
using System.Globalization;

namespace Diosan_Verter;

public partial class ConverterPage : ContentPage
{
    private readonly Category _category;
    private readonly List<Unit> _units;

    public ConverterPage(Category category)
    {
        InitializeComponent();
        _category = category;
        _units = ConverterData.UnitsFor(category.Name);

        var color = Color.FromArgb(category.Color);
        HeaderBorder.BackgroundColor = color;
        ResultBorder.BackgroundColor = color;
        TitleLabel.Text = category.Name;

        var names = _units.Select(u => u.Name).ToList();
        FromPicker.ItemsSource = names;
        ToPicker.ItemsSource = names;
        FromPicker.SelectedIndex = 0;
        ToPicker.SelectedIndex = names.Count > 1 ? 1 : 0;
    }

    private void OnInputChanged(object? sender, TextChangedEventArgs e) => UpdateResult();
    private void OnUnitChanged(object? sender, EventArgs e) => UpdateResult();

    private void OnSwapClicked(object? sender, EventArgs e)
    {
        int from = FromPicker.SelectedIndex;
        FromPicker.SelectedIndex = ToPicker.SelectedIndex;
        ToPicker.SelectedIndex = from;
    }

    private async void OnBackClicked(object? sender, EventArgs e) => await Navigation.PopAsync();

    private void UpdateResult()
    {
        if (_units is null || FromPicker.SelectedIndex < 0 || ToPicker.SelectedIndex < 0)
            return;

        if (!double.TryParse(InputEntry.Text, NumberStyles.Float,
                             CultureInfo.CurrentCulture, out double value))
        {
            ResultLabel.Text = "0";
            return;
        }

        var from = _units[FromPicker.SelectedIndex];
        var to = _units[ToPicker.SelectedIndex];
        double result = ConverterData.Convert(_category.Name, from, to, value);

        ResultLabel.Text = $"{result.ToString("#,0.######", CultureInfo.CurrentCulture)} {to.Name}";
    }
}