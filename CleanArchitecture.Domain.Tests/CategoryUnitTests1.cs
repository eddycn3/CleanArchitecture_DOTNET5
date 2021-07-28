using System;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryUnitTests1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value");
        }

        [Fact]
        public void CreateCategory_WithNullOrEmptyValue_DomainExceptionNameIsRequired()
        {
            Action action = () => new Category(null);
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Category name is required, cannot be null or empty");
           
        }


        [Fact]
        public void CreateCategory_WithShortLenth_DomainExceptionNameIsToShort()
        {
            Action action = () => new Category("Ca");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Category name to short, minimum is 3 characters");
        }
    }
}
