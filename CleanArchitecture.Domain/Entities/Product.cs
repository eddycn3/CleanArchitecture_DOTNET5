using System;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Product Id");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name,string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name,string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Product name cannot be null or empty");

            DomainExceptionValidation.When(name.Length < 3, "Product name to short, min lenght is 3");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Product description cannot be null or empty");

            DomainExceptionValidation.When(description.Length < 5, "Product description to short, min lenght is 5");

            DomainExceptionValidation.When(price < 0, "Invalid product price");

            DomainExceptionValidation.When(stock < 0, "Invalid product stock");

            DomainExceptionValidation.When(image?.Length > 250, "Product image to long, max length is 250");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }

    }
}
