using System;

namespace MasteringWpf.DataModels
{
    public class Product :BaseValidationModel
    {
        private Guid id = Guid.Empty;
        private string name = string.Empty;
        private decimal price = 0;

        public Guid Id
        {
            get { return id; }
            set { if (id != value) { id = value; NotifyPropertyChanged(); } }
        }

        public string Name
        {
            get { return name; }
            set { if (name != value) { name = value; NotifyPropertyChanged(); } }
        }

        public decimal Price
        {
            get { return price; }
            set { if (price != value) { price = value; NotifyPropertyChanged(); } }
        }

        public override string this[string propertyName]
        {
            get
            {
                string error = string.Empty;
                if (propertyName == nameof(Name))
                {
                    if (string.IsNullOrEmpty(Name)) error = "Please enter the product name.";
                    else if (Name.Length > 25) error = "The product name cannot be longer than twenty-five characters.";
                }
                else if (propertyName == nameof(Price) && Price == 0) error = "Please enter a valid price for the product.";
                return error;
            }
        }
    }
}
