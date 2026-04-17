using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Practice.Models;

public class Product : INotifyPropertyChanged
{
    private string _name;
    private int _quantity;
    private decimal _price;

    public string Name
    {
       get => _name;
       set
       {
           if (!string.IsNullOrEmpty(value))
           {
               _name = value;
               OnPropertyChanged();
           }
       }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value > 0)
            {
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StockValue));
            }
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value > 0)
            {
                _price = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StockValue));
            }
        }
    }

    public Product() : this("Unknown Item", 0, 0.0m)
    {
        // Initializes values to main constructor
        // for items initialized with no values
    }
    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public virtual decimal StockValue => Quantity * Price;


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}