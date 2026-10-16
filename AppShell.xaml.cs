namespace Diosan_Verter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Allow Shell to navigate to ConverterPage with query parameters
            Routing.RegisterRoute(nameof(ConverterPage), typeof(ConverterPage));
        }
    }
}
