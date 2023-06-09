﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteringWpf.DataModels
{
    public class ProductNotify : BaseNotifyValidationModel
    {
        private Guid id = Guid.Empty;
        private string name = string.Empty, description = string.Empty;
        private decimal price = 0;

        /// <summary>
        /// Gets or sets the unique identification number of the Product object.
        /// </summary>
        public Guid Id
        {
            get { return id; }
            set { if (id != value) { id = value; NotifyPropertyChanged(); } }
        }

        /// <summary>
        /// Gets or sets the name of the Product object.
        /// </summary>
        //[Required(ErrorMessage = "Please enter the product name.")]
        //[MaxLength(ErrorMessage = "The product name cannot be longer than twenty-five characters.")]
        public string Name
        {
            get { return name; }
            set { if (name != value) { name = value; NotifyPropertyChangedAndValidate(); } }
        }

        /// <summary>
        /// Gets or sets the price of the Product object.
        /// </summary>
        //[Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Please enter a valid price for the product.")]
        //[Minimum(0.01, ErrorMessage = "Please enter a valid price for the product.")]
        public decimal Price
        {
            get { return price; }
            set { if (price != value) { price = value; NotifyPropertyChangedAndValidate(); } }
        }


        /// <summary>
        /// Gets the validation message relating to the propertyName input parameter if there are any validation errors.
        /// </summary>
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
                else if (propertyName == nameof(Price) && Price == 0) errors.Add("Please enter a valid price for the product.");
                return errors;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Name}: £{Price:N2}";
        }
    }
}
