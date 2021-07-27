using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities
{
    public class Category : Entity
    {

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name);
        }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(name),
                "Category name is required, cannot be null or empty");

            DomainExceptionValidation.When(
                name.Length < 3,
                "Category name to short, minimum is 3 characters");

            Name = name;
        }
    }
}
