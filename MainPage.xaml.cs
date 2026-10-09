namespace Diosan_Verter
{
    public record Category(string Name, string Gif, string Color);
    public partial class MainPage : ContentPage
    {
        public List<Category> Categories { get; } = new()
    {
        new("Information", "info.gif", "#FF6B9D"),
        new("Volume",      "volume.gif",      "#4D96FF"),
        new("Length",      "length.gif",      "#FF9F1C"),
        new("Mass",        "mass.gif",        "#6BCB77"),
        new("Temperature", "temperature.gif", "#FF5E5B"),
        new("Energy",      "energy.gif",      "#FFC93C"),
        new("Area",        "area.gif",        "#9B5DE5"),
        new("Speed",       "speed.gif",       "#00BBF9"),
        new("Duration",    "duration.gif",    "#F15BB5"),
    };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private async void OnCategoryTapped(object? sender, TappedEventArgs e)
        {
            if (sender is not Border border || border.BindingContext is not Category c) return;

            await border.ScaleTo(0.9, 80);
            await border.ScaleTo(1.0, 80);

            await Navigation.PushAsync(new ConverterPage(c));
        }


    }
}
