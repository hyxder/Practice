using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Practice.Models;
namespace Practice.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Product> Products { get; set; }
    
    // Holds both Imported and regular Products
    // Derived class ImportedProduct IS-A Product
    public MainViewModel()
    {
        Products = new ObservableCollection<Product>();
        Products.Add(new Product("Local Bread", 20, 3.5m));
        Products.Add(new ImportedProduct("French Cheese", 10, 12.00m, 5.50m));
    }
    
    // Holds selected item
    private Product _selectedProduct;

    public Product SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            if (_selectedProduct != value)
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }
    }


    private async void NavigateToDetails()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "SelectedProduct", SelectedProduct }
        };
        await Shell.Current.GoToAsync(nameof(Views.ProductDetailsPage), navigationParameter);
        
        SelectedProduct = null;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}