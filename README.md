The more advanced version of this project is in this repository : https://github.com/Agshinhummatov/E-CommerceAPI-ASP.NET-Core-OnionArchitectureProject


# ECommerce Project

This project aims to [briefly describe the project purpose].

## Technologies Used

- ASP.NET Core
- MediatR CQRS
- Entity Framework Core 
- Onion Architecture
- Swagger
- PostgreSQL
- Docker (optional, if used)
- JWT Authentication (optional, if used)

## Project Overview

This project [provide a more detailed description of the project's goals and scope].

## Folder Structure

The project follows the principles of Onion Architecture, with the following folder structure:

- **Application**: Application services and CQRS commands/handlers.
- **Domain**: Domain models and business logic.
- **Infrastructure**: Database connections, external services, and data persistence layer.
- **Presentation**: API controllers and Swagger configuration.

## Persistence Layer

The persistence layer includes database interactions and concrete service implementations:

- **ProductRepository**: Handles database operations related to products.
- **OrderRepository**: Manages database operations for orders.
- **UserRepository**: Implements database operations for user-related data.

##Product
Create Product: Endpoint to create a new product.

Update Product: Endpoint to update an existing product.

Search Product: Endpoint to search for products based on a search term.

Create Product Image: Endpoint to upload and associate images with a product.

Delete Product Image: Endpoint to delete an image associated with a product.

Get Product by Id: Endpoint to retrieve details of a product by its unique identifier.

Change Showcase Image for Product: Endpoint to set a specific image as the showcase image for a product.

##Basket

Add Product to User Basket: Endpoint to add a product to a user's basket.

Update Product in User Basket: Endpoint to update a product quantity in the user's basket.

Complete User Basket: Endpoint to finalize the selection and prepare for order.

##Order
User Order: Endpoint for a user to place an order.

Admin Complete Order: Endpoint for an admin to mark an order as completed.

Admin Delete Order: Endpoint for an admin to delete an order.

##Login

User Login: Endpoint for users to log in using credentials.

Google Login: Endpoint for users to log in using Google authentication.

Reset Password via Email: Endpoint to initiate a password reset process via email.

Reset JWT Token: Endpoint to regenerate a new JWT token after expiration.

##Register

User Register: Endpoint for user registration.
Google Register: Endpoint for user registration using Google authentication.



## Validation and Filters

### Validation Filters

Validation filters are implemented using FluentValidation for robust input validation:

- **CreateProductValidator**: Validates `CreateProductCommandRequest` before processing, enforcing rules for product name, description, stock, and price.

### Action Filters

Action filters, such as `ValidationFilter`, intercept requests before execution to ensure data validity:

- **ValidationFilter**: Checks `ModelState.IsValid` before action execution. If invalid, it returns a `BadRequestObjectResult` with detailed validation errors.

## Getting Started

To get started with the project locally or on a server, follow these steps:
1. [Instructions on setting up prerequisites, dependencies, and environment variables].
2. [How to run the project locally or deploy it on a server].
3. [Additional configuration steps, if any].

## API Documentation

Explore the project's API endpoints using Swagger UI at [URL]. Here you can test and interact with various endpoints.

## Contributing

Contributions are welcome! Please follow [guidelines or instructions for contributing], and submit pull requests.




Shopping Cart Operations
1. Get Basket Items

URL: /get-basket-items
Method: GET
Description: Retrieves all items in the user's shopping cart.
Success Response: 200 - Successfully retrieved basket items.
Error Response: 500 - Internal server error encountered.
2. Add Item to Basket

URL: /add-item-to-basket
Method: POST
Description: Adds a new item to the user's shopping cart.
Success Response: 200 - Item added to the basket successfully.
Error Response: 500 - Internal server error encountered.
3. Update Item Quantity

URL: /update-quantity
Method: PUT
Description: Updates the quantity of an item in the user's shopping cart.
Success Response: 200 - Quantity updated successfully.
Error Response: 500 - Internal server error encountered.
4. Remove Item from Basket

URL: /remove-basket-item/{BasketItemId}
Method: DELETE
Description: Removes a specific item from the user's shopping cart.
Success Response: 200 - Item removed from the basket successfully.
Error Response: 500 - Internal server error encountered.
User Operations
1. User Login

URL: /login
Method: POST
Description: Allows the user to log in.
Success Response: 200 - Login successful.
Error Response: 400 - Bad request, or 500 - Internal server error encountered.
2. Login with Refresh Token

URL: /refresh-token-login
Method: GET
Description: Allows the user to log in using a refresh token.
Success Response: 200 - Login with refresh token successful.
Error Response: 400 - Bad request, or 500 - Internal server error encountered.
3. Login with Google

URL: /google-login
Method: POST
Description: Allows the user to log in using their Google account.
Success Response: 200 - Login with Google successful.
Error Response: 400 - Bad request, or 500 - Internal server error encountered.
4. Password Reset

URL: /password-reset
Method: POST
Description: Allows the user to reset their password.
Success Response: 200 - Password reset successful.
Error Response: 400 - Bad request, or 500 - Internal server error encountered.
5. Verify Reset Token

URL: /verify-reset-token
Method: POST
Description: Allows the user to verify their password reset token.
Success Response: 200 - Token verification successful.
Error Response: 400 - Bad request, or 500 - Internal server error encountered.
Order Operations
1. Get Order Details

URL: /{Id}
Method: GET
Description: Retrieves details of a specific order.
Success Response: 200 - Order details retrieved successfully.
Error Response: 404 - Order not found, or 500 - Internal server error encountered.
2. Get All Orders

URL: /
Method: GET
Description: Retrieves all orders.
Success Response: 200 - All orders retrieved successfully.
Error Response: 500 - Internal server error encountered.
3.Create Order

URL: /create-order
Method: POST
Description: Creates a new order.
Success Response: 201 - Order created successfully.
Error Response: 500 - Internal server error encountered.
4. Complete Order

URL: /complete-order/{Id}
Method: POST
Description: Completes a specific order.
Success Response: 200 - Order completed successfully.
Error Response: 500 - Internal server error encountered.
Product Operations
1. Get All Products

URL: /
Method: GET
Description: Retrieves all products.
Success Response: 200 - All products retrieved successfully.
Error Response: 500 - Internal server error encountered.
2. Get Specific Product

URL: /{Id}
Method: GET
Description: Retrieves details of a specific product.
Success Response: 200 - Product details retrieved successfully.
Error Response: 404 - Product not found, or 500 - Internal server error encountered.
3. Create Product

URL: /
Method: POST
Description: Creates a new product.
Success Response: 201 - Product created successfully.
Error Response: 400 - Bad request, or 500 - Internal server error encountered.
4. Delete Product

URL: /{Id}
Method: DELETE
Description: Deletes a specific product.
Success Response: 200 - Product deleted successfully.
Error Response: 404 - Product not found, or 500 - Internal server error encountered.
Payment Operations
1. Make Payment

URL: /make-payment
Method: POST
Description: Processes payment for a specific order.
Success Response: 200 - Payment processed successfully.
Error Response: 400 - Bad request, or 500 - Internal server error encountered.











