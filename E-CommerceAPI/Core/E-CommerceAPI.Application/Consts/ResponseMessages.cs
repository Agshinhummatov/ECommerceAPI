using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Consts
{
    public static class ResponseMessages
    {

        // Products controller sesponse messages
        public const string ProductRetrievalError = "An error occurred while retrieving the products.";
        public const string ProductNotFound = "Product '{0}' not found.";
        public const string ProductCreationError = "An error occurred while creating the product.";
        public const string ProductRemovalError = "An error occurred while removing the product.";
        public const string ProductUpdateError = "An error occurred while updating the product.";
        public const string InvalidArgument = "Invalid argument provided: {0}";
        public const string ProductSearchError = "An error occurred while searching for products.";
        public const string ProductSearchCannotEmpty = "Search cannot be empty terminal";
        public const string ProductSearchNotFound = "The product you were looking for was not found.";


        //Create Product Validator response messages

        public const string BlankProductName = "Please do not leave the product name blank.";
        public const string InvalidProductNameLength = "Please enter the product name between 2 and 150 characters.";
        public const string BlankProductDescription = "Please do not leave the product description blank.";
        public const string InvalidProductDescriptionLength = "Please enter the product description between 2 and 1000 characters.";
        public const string BlankStock = "Please do not leave the product's stock information blank.";
        public const string NegativeStock = "Stock information cannot be negative.";
        public const string ExcessiveStock = "The product stock is too big.";
        public const string BlankPrice = "Please do not leave the product's price information blank.";
        public const string NegativePrice = "Price information cannot be negative.";
        public const string ZeroPrice = "The product price cannot be zero.";
        public const string ExcessivePrice = "The product price is too big.";




    }
}
