using Practice.Models;

namespace Practice.Views;

public partial class ProductDetailsPage : ContentPage
{
    // Constructor now takes the product as a parameter
    public ProductDetailsPage(Product product)
    {
        InitializeComponent();

        // Directly set the BindingContext to the passed object
        BindingContext = product;
    }
}