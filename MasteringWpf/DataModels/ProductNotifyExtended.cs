using MasteringWpf.DataModels.Enums;
using System;
using System.Collections.Generic;

namespace MasteringWpf.DataModels
{
    public class ProductNotifyExtended : BaseNotifyValidationModelExtended<ProductNotifyExtended>
    {
        private Guid id = Guid.Empty;
        private string name = string.Empty, description = string.Empty;
        private decimal price = 0;

        public Guid Id
        {
            get { return id; }
            set { if (id != value) { id = value; NotifyPropertyChanged(); } }
        }

        public string Name
        {
            get { return name; }
            set { if (name != value) { name = value; NotifyPropertyChangedAndValidate(); } }
        }

        public decimal Price
        {
            get { return price; }
            set { if (price != value) { price = value; NotifyPropertyChangedAndValidate(); } }
        }

        public override void CopyValuesFrom(ProductNotifyExtended product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }

        public override bool PropertiesEqual(ProductNotifyExtended otherProduct)
        {
            if (otherProduct == null) return false;
            return Id == otherProduct.Id && Name == otherProduct.Name && Price == otherProduct.Price;
        }

        public override void ValidateAllProperties()
        {
            Validate(nameof(Name), nameof(Price));
        }

        public override IEnumerable<string> this[string propertyName]
        {
            get
            {
                List<string> errors = new List<string>();
                if (propertyName == nameof(Name))
                {
                    if (string.IsNullOrEmpty(Name)) errors.Add("Please enter the product name.");
                    else if (Name.Length > 25) errors.Add("The product name cannot be longer than twenty-five characters.");
                    if (Name.Length > 0 && char.IsLower(Name[0])) errors.Add("The first letter of the product name must be a capital letter.");
                }
                else if (propertyName == nameof(Price) && ValidationLevel == ValidationLevel.Full && Price == 0) errors.Add("Please enter a valid price for the product.");
                return errors;
            }
        }

        public override string ToString()
        {
            return $"{Name}: £{Price:N2}";
        }
    }
}
