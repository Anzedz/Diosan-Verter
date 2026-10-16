using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Diosan_Verter.Models;

// MVVMTK0045 warns that field-based [ObservableProperty] isn't WinRT-AOT friendly and
// suggests partial properties. Partial properties require a source generator, but MAUI's
// XAML source-generation pass (MauiXamlInflator=SourceGen) compiles with /skipanalyzers+,
// which disables generators, so partial properties fail to build. Field-based properties
// are the compatible choice here; the warning is irrelevant unless NativeAOT/WinRT is enabled.
#pragma warning disable MVVMTK0045

namespace Diosan_Verter.ViewModels;

public partial class ConverterPageViewModel : ObservableObject, IQueryAttributable
{
    private Category? _category;
    private List<Unit>? _units;

    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private Color _themeColor = Colors.Transparent;

    [ObservableProperty]
    private string _inputValue = string.Empty;

    [ObservableProperty]
    private int _fromUnitIndex = -1;

    [ObservableProperty]
    private int _toUnitIndex = -1;

    [ObservableProperty]
    private string _result = "0";

    public ObservableCollection<string> UnitNames { get; } = new();

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("name", out var nameObj) || nameObj is not string name)
            return;

        var category = MainPageViewModel.Catalog.FirstOrDefault(c => c.Name == name);
        if (category is null) return;

        _category = category;
        _units = ConverterData.UnitsFor(category.Name);

        Title = category.Name;
        ThemeColor = Color.FromArgb(category.Color);

        UnitNames.Clear();
        foreach (var unit in _units)
            UnitNames.Add(unit.Name);

        FromUnitIndex = 0;
        ToUnitIndex = _units.Count > 1 ? 1 : 0;
    }

    partial void OnInputValueChanged(string value) => UpdateResult();
    partial void OnFromUnitIndexChanged(int value) => UpdateResult();
    partial void OnToUnitIndexChanged(int value) => UpdateResult();

    [RelayCommand]
    private void Swap()
    {
        (FromUnitIndex, ToUnitIndex) = (ToUnitIndex, FromUnitIndex);
    }

    private void UpdateResult()
    {
        if (_category is null || _units is null || FromUnitIndex < 0 || ToUnitIndex < 0)
            return;

        if (!double.TryParse(InputValue, NumberStyles.Float,
                             CultureInfo.CurrentCulture, out double value))
        {
            Result = "0";
            return;
        }

        var from = _units[FromUnitIndex];
        var to = _units[ToUnitIndex];
        double result = ConverterData.Convert(_category.Name, from, to, value);

        Result = $"{result.ToString("#,0.######", CultureInfo.CurrentCulture)} {to.Name}";
    }
}
