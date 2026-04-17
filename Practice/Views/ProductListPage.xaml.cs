using Practice.Models;

namespace Practice.Views;

public partial class ProductListPage : ContentPage
{
    public ProductListPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.MainViewModel();
    }

    private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        // 1. Get the object that was tapped
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Product;

        if (selectedItem != null)
        {
            // 2. Create the page and pass the object into the constructor
            await Navigation.PushAsync(new ProductDetailsPage(selectedItem));

            // 3. Reset selection so the row doesn't stay highlighted
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}