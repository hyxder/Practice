namespace Practice;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.ProductDetailsPage), typeof(Views.ProductDetailsPage));
    }
}