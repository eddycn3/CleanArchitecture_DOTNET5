using System;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.Tests
{
    public class ProductUnitTestes1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ReturnObjectValidState()
        {
            Action action = () => new Product(1,"Product", "Dddddd", 9m, 1, "qwdqwdqwdqwd");
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithInvalidId_DomainExceptionInvalidId()
        {
            Action action = () =>  new Product(-1,"Product", "Dddddd", 9m, 1, "qwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Id");
        }

        [Fact]
        public void CreateProduct_WithNullOrEmptyName_DomainExceptionNameCannotBeNullOrEmpty()
        {
            Action action = () =>  new Product(1, null, "Dddddd", 9m, 1, "qwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product name cannot be null or empty");

        }

        [Fact]
        public void CreateProduct_WithShortName_DomainExceptionNameToShort()
        {
            Action action = ()=> new Product(1, "Pr", "Dddddd", 9m, 1, "qwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product name to short, min lenght is 3");
        }

        [Fact]
        public void CreateProduct_WithEmptyOrNullDescription_DomainExceptionDescriptionIsNullOrEmpty()
        {
            Action action = () =>  new Product(1, "Product", null, 9m, 1, "qwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product description cannot be null or empty");
        }

        [Fact]
        public void CreateProduct_WithShortDescription_DomainExceptionDescriptionIsToShort()
        {
            Action action = () => new Product(1, "Product", "Dddd", 9m, 1, "qwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product description to short, min lenght is 5");
        }

        [Fact]
        public void CreateProduct_WithInvalidProductPrice_DomainExceptionInvalidProductPrice()
        {
            Action action = () => new Product(1, "Produc", "Ddddd", -1, 1, "qwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid product price");
        }

        [Fact]
        public void CreateProduct_WithInvalidProductStock_DomainExceptionInvalidProductStock()
        {
            Action action = () => new Product(1, "Produc", "Ddddd", 9m, -1, "qwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid product stock");
        }


        [Fact]
        public void CreateProduct_WithProductImageToLong_DomainExceptionImageLenthToLong()
        {
            Action action = () => new Product(1, "Product", "Dddddd", 9m, 1, "qwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdvqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwdqwd");
            action.Should()
                .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Product image to long, max length is 250");
        }


        [Fact]
        public void CreateProduct_WithProductNullImageValue_NotDomainException()
        {
            Action action = () => new Product(1, "Product", "Dddddd", 9m, 1,null);
            action.Should()
                .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
               
        }

        [Fact]
        public void CreateProduct_WithProductNullImageValue_NotNullReferenceException()
        {
            Action action = () => new Product(1, "Product", "Dddddd", 9m, 1, null);
            action.Should()
                .NotThrow<NullReferenceException>();

        }

    }
}
