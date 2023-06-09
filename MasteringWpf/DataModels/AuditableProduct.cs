﻿using MasteringWpf.DataModels.Interfaces;
using MasteringWpf.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MasteringWpf.DataModels
{
    /// <summary>
    /// Represents a validatable product in the application.
    /// </summary>
    public class AuditableProduct : BaseNotifyValidationModelExtended<AuditableProduct>, IAuditable
    {
        private Auditable auditable;
        private Guid id = Guid.Empty;
        private string name = string.Empty, description = string.Empty;
        private decimal price = 0;

        /// <summary>
        /// Initialises a new empty AuditableProduct object.
        /// </summary>
        public AuditableProduct()
        {
            Auditable = new Auditable();
        }

        /// <summary>
        /// Initialises a new AuditableProduct object with the value provided by the input parameter.
        /// </summary>
        /// <param name="product"></param>
        public AuditableProduct(ThinProduct product) : this()
        {
            Id = product.Id;
            Name = product.Name;
        }

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
        public string Name
        {
            get { return name; }
            set { if (name != value) { name = value; NotifyPropertyChangedAndValidate(); } }
        }

        /// <summary>
        /// Gets or sets the price of the Product object.
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { if (price != value) { price = value; NotifyPropertyChangedAndValidate(); } }
        }

        public Auditable Auditable
        {
            get { return auditable; }
            set { auditable = value; }
        }

        /// <summary>
        /// Copies all of the values from the product input parameter to this object.
        /// </summary>
        /// <param name="product">The object to copy the values from.</param>
        public override void CopyValuesFrom(AuditableProduct product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }

        /// <summary>
        /// Specifies whether the property values of the Product object are equal to the property values of the object specified by the otherProduct input parameter, or not.
        /// </summary>
        /// <param name="otherProduct">The object to compare with the current object.</param>
        /// <returns>True if the property values of the specified object are equal to the property values of the object specified by the otherProduct input parameter, otherwise false.</returns>
        public override bool PropertiesEqual(AuditableProduct otherProduct)
        {
            if (otherProduct == null) return false;
            return Id == otherProduct.Id && Name == otherProduct.Name && Price == otherProduct.Price;
        }

        /// <summary>
        /// Validates all of the validatable properties of the Product object.
        /// </summary>
        public override void ValidateAllProperties()
        {
            Validate(nameof(Name), nameof(Price));
        }

        /// <summary>
        /// Gets the validation message relating to the propertyName input parameter, if there are any validation errors.
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
                else if (propertyName == nameof(Price) && ValidationLevel == ValidationLevel.Full && Price == 0) errors.Add("Please enter a valid price for the product.");
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
