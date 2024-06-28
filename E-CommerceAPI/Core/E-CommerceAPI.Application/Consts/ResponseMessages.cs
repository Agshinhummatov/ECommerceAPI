
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
        public const string ProductImagesNotFound = "Product not Found";



        public const string NoFilesProvided = "No files provided.";
        public const string UploadProductFileError = "An error occurred while uploading the product file.";
        public const string GetProductImagesError = "An error occurred while retrieving the product images.";
        public const string InvalidImageId = "Invalid image ID.";
        public const string DeleteProductImageError = "An error occurred while deleting the product image.";
        public const string ChangeShowcaseImageError = "An error occurred while changing the showcase image.";

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


        //User response message 

      
        public const string UserCreationError = "Error creating user.";
        public const string PasswordUpdateError = "Error updating password.";
        public const string LoginError = "Error during login.";
        public const string RefreshTokenLoginError = "Error during refresh token login.";
        public const string GoogleLoginError = "Error during Google login.";
        public const string PasswordResetError = "Error during password reset.";
        public const string VerifyResetTokenError = "Error during token verification.";

        // Basket response message 
        public const string BasketRetrievalError = "An error occurred while retrieving the basket items.";
        public const string BasketItemAdditionError = "An error occurred while adding the item to the basket.";
        public const string BasketItemUpdateError = "An error occurred while updating the basket item quantity.";
        public const string BasketItemRemovalError = "An error occurred while removing the item from the basket.";

        // Order response message
        public const string OrderRetrievalError = "An error occurred while retrieving the order.";
        public const string OrderNotFound = "Order with ID {0} was not found.";
        public const string OrderCreationError = "An error occurred while creating the order.";
        public const string OrderCompletionError = "An error occurred while completing the order.";




    }
}
