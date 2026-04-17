namespace Practice.Models;

public class ImportedProduct : Product
{
    private decimal _importDuty;

    public decimal ImportDuty
    {
        get => _importDuty;
        private set
        {
            if (value >= 0)
            {
                _importDuty = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StockValue));
            }
        }
    }
    
    
    // Inheriting from base class
    public ImportedProduct(string name, int quantity, decimal price, decimal importduty)
        : base(name, quantity, price) // base class properties
    {
        ImportDuty = importduty;
    }
    
    // Overriding virtual StockValue computed property
    public override decimal StockValue => (Quantity * Price) + ImportDuty;
}