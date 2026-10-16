using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Diosan_Verter.Models;

namespace Diosan_Verter.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    // Shared catalog so ConverterPageViewModel can look up by name
    public static readonly IReadOnlyList<Category> Catalog = new List<Category>
    {
        new("Information", "info.gif", "#FF6B9D"),
        new("Volume",      "volume.gif", "#4D96FF"),
        new("Length",      "length.gif", "#FF9F1C"),
        new("Mass",        "mass.gif", "#6BCB77"),
        new("Temperature", "temperature.gif", "#FF5E5B"),
        new("Energy",      "energy.gif", "#FFC93C"),
        new("Area",        "area.gif", "#9B5DE5"),
        new("Speed",       "speed.gif", "#00BBF9"),
        new("Duration",    "duration.gif", "#F15BB5"),
    };

    public ObservableCollection<Category> Categories { get; } = new(Catalog);

    [RelayCommand]
    private async Task SelectCategoryAsync(Category category)
    {
        if (category is null) return;
        await Shell.Current.GoToAsync($"{nameof(ConverterPage)}?name={Uri.EscapeDataString(category.Name)}");
    }
}
