# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

## Overview
This project serves as an evaluation for senior developer candidates. It is designed to assess various skills and competencies required for a senior developer role, including but not limited to:

1. Proficiency in C# and .NET 8.0 development
2. Project Layer Separation
3. Database skills with both PostgreSQL and MongoDB
4. Understanding and implementation of design patterns (e.g., Mediator pattern)
5. Ability to work with object-relational mapping tools (EF Core)
6. Proficiency in writing and maintaining unit tests using xUnit
7. Experience with mocking frameworks like NSubstitute
8. Familiarity with object mapping libraries such as AutoMapper
9. API design and RESTful service implementation
10. Version control with Git 
11. Understanding of both relational and non relational database systems
12. Data generation and management for testing purposes (using Faker)
13. Code organization and project structure
14. Implementation of pagination, filtering, and sorting in APIs
15. Error handling and API response formatting
16. Use of Git Flow and Semantic Commits
17. Performance optimization for database queries and API responses
18. Understanding of asynchronous programming patterns
19. Code quality and adherence to best practices
20. Problem-solving and analytical skills
21. Attention to detail in implementing business logic
22. Ability to work with and integrate multiple technologies and frameworks


This comprehensive evaluation aims to assess both the technical proficiency and the broader software engineering skills necessary for a senior developer role.


## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

## Tech Stack
The Tech Stack is a set of technologies we use to build our Ambev products, which is why we can consider it the heart of our products.

All versions of languages, frameworks, and tools have been carefully chosen based on a predefined strategy. We selected the technologies based on our daily challenges and needs.

We use the following technologies in this project:

Backend:
- **.NET 8.0**: A free, cross-platform, open source developer platform for building many different types of applications.
  - Git: https://github.com/dotnet/core
- **C#**: A modern object-oriented programming language developed by Microsoft.
  - Git: https://github.com/dotnet/csharplang

Testing:
- **xUnit**: A free, open source, community-focused unit testing tool for the .NET Framework.
  - Git: https://github.com/xunit/xunit

Frontend:
- **Angular**: A platform for building mobile and desktop web applications.
  - Git: https://github.com/angular/angular

Databases:
- **PostgreSQL**: A powerful, open source object-relational database system.
  - Git: https://github.com/postgres/postgres
- **MongoDB**: A general purpose, document-based, distributed database.
  - Git: https://github.com/mongodb/mongo


## Frameworks
Our frameworks are the building blocks that enable us to create robust, efficient, and maintainable software solutions. They have been carefully selected to complement our tech stack and address specific development challenges we face in our projects.

These frameworks enhance our development process by providing tried-and-tested solutions to common problems, allowing our team to focus on building unique features and business logic. Each framework has been chosen for its ability to integrate seamlessly with our tech stack, its community support, and its alignment with our development principles.

We use the following frameworks in this project:

Backend:
- **Mediator**: A behavioral design pattern that helps reduce chaotic dependencies between objects. It allows loose coupling by encapsulating object interaction.
  - Git: https://github.com/jbogard/MediatR
- **Automapper**: A convention-based object-object mapper that simplifies the process of mapping one object to another.
  - Git: https://github.com/AutoMapper/AutoMapper
- **Rebus**: A lean service bus implementation for .NET, providing a simple and flexible way to do messaging and queueing in .NET applications.
  - Git: https://github.com/rebus-org/Rebus

Testing:
- **Faker**: A library for generating fake data for testing purposes, allowing for more realistic and diverse test scenarios.
  - Git: https://github.com/bchavez/Bogus
- **NSubstitute**: A friendly substitute for .NET mocking libraries, used for creating test doubles in unit testing.
  - Git: https://github.com/nsubstitute/NSubstitute

Database:
- **EF Core**: Entity Framework Core, a lightweight, extensible, and cross-platform version of Entity Framework, used for data access and object-relational mapping.
  - Git: https://github.com/dotnet/efcore

<br>

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

## Project Structure

The project should be structured as follows:

```
root
├── src/
├── tests/
└── README.md
```


## API Structure
### Pagination

Pagination is supported for list endpoints using the following query parameters:

- `_page`: Page number (default: 1)
- `_size`: Number of items per page (default: 10)

Example:
```
GET /products?_page=2&_size=20
```

### Ordering

When requesting a collection of a resource, you can also specify the order of the elements in the collection using the query parameter `_order`. Simply indicate the desired order: ascending (`asc`) or descending (`desc`). If not specified, the default order will be ascending.

**Note**

In the GET request, you must use the field names in the same format as the JSON response.

For example, consider the following Product resource:

```json
{
  "id": 1,
  "title": "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
  "price": 109.95,
  "description": "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
  "category": "men's clothing",
  "image": "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
  "rating": {
    "rate": 3.9,
    "count": 120
  }
}
```

In this case, to retrieve a list of products ordered by price in descending order and then by title in ascending order, the request would look like this:

```
GET /products?_order="price desc, title asc"
```

or 

```
GET /products?_order="price desc, title"
```

### Filtering

Filters can be applied to list endpoints using the following query parameters:

- `field=value`: Filter by specific field value.

Example:

```
GET /products?category=men's clothing&price=109.95
```

**String Fields**

To filter partial matches for string fields, use an asterisk (`*`) before or after the value.

Example:

```
GET /products?title=Fjallraven*
GET /products?category=*clothing
```

**Numeric and Date Fields**

To filter numeric or date fields by range, use `_min` and `_max` prefixes before the field name.

Example:

```
GET /products?_minPrice=50
GET /products?_minPrice=50&_maxPrice=200
GET /carts?_minDate=2023-01-01
```

Logical Operators
When combining filters, use `&` (AND) between them.

Example:

```
GET /products?category=men's clothing&_minPrice=50
GET /products?title=Fjallraven*&category=men's clothing&_minPrice=100
```

*Note*
Even when filtering with "or" for different values in the same field, use `&` in the query.

## Error Handling

The API uses conventional HTTP response codes to indicate the success or failure of an API request. In general:

- 2xx range indicate success
- 4xx range indicate an error that failed given the information provided (e.g., a required parameter was omitted, etc.)
- 5xx range indicate an error with our servers

### Error Response Format

```json
{
  "type": "string",
  "error": "string",
  "detail": "string"
}
```

- `type`: A machine-readable error type identifier
- `error`: A short, human-readable summary of the problem
- `detail`: A human-readable explanation specific to this occurrence of the problem

Example error responses:

1. Resource Not Found
```json
{
  "type": "ResourceNotFound",
  "error": "Product not found",
  "detail": "The product with ID 12345 does not exist in our database"
}
```

2. Authentication Error
```json
{
  "type": "AuthenticationError",
  "error": "Invalid authentication token",
  "detail": "The provided authentication token has expired or is invalid"
}
```

3. Validation Error
```json
{
  "type": "ValidationError",
  "error": "Invalid input data",
  "detail": "The 'price' field must be a positive number"
}
```


## Products API

### Products

#### GET /products
- Description: Retrieve a list of all products
- Query Parameters:
  - `_page` (optional): Page number for pagination (default: 1)
  - `_size` (optional): Number of items per page (default: 10)
  - `_order` (optional): Ordering of results (e.g., "price desc, title asc")
- Response: 
  ```json
  {
    "data": [
      {
        "id": "integer",
        "title": "string",
        "price": "number",
        "description": "string",
        "category": "string",
        "image": "string",
        "rating": {
          "rate": "number",
          "count": "integer"
        }
      }
    ],
    "totalItems": "integer",
    "currentPage": "integer",
    "totalPages": "integer"
  }
  ```

#### POST /products
- Description: Add a new product
- Request Body:
  ```json
  {
    "title": "string",
    "price": "number",
    "description": "string",
    "category": "string",
    "image": "string",
    "rating": {
      "rate": "number",
      "count": "integer"
    }
  }
  ```
- Response: 
  ```json
  {
    "id": "integer",
    "title": "string",
    "price": "number",
    "description": "string",
    "category": "string",
    "image": "string",
    "rating": {
      "rate": "number",
      "count": "integer"
    }
  }
  ```

#### GET /products/{id}
- Description: Retrieve a specific product by ID
- Path Parameters:
  - `id`: Product ID
- Response: 
  ```json
  {
    "id": "integer",
    "title": "string",
    "price": "number",
    "description": "string",
    "category": "string",
    "image": "string",
    "rating": {
      "rate": "number",
      "count": "integer"
    }
  }
  ```

#### PUT /products/{id}
- Description: Update a specific product
- Path Parameters:
  - `id`: Product ID
- Request Body:
  ```json
  {
    "title": "string",
    "price": "number",
    "description": "string",
    "category": "string",
    "image": "string",
    "rating": {
      "rate": "number",
      "count": "integer"
    }
  }
  ```
- Response: 
  ```json
  {
    "id": "integer",
    "title": "string",
    "price": "number",
    "description": "string",
    "category": "string",
    "image": "string",
    "rating": {
      "rate": "number",
      "count": "integer"
    }
  }
  ```

#### DELETE /products/{id}
- Description: Delete a specific product
- Path Parameters:
  - `id`: Product ID
- Response: 
  ```json
  {
    "message": "string"
  }
  ```

#### GET /products/categories
- Description: Retrieve all product categories
- Response: 
  ```json
  [
    "string"
  ]
  ```

#### GET /products/category/{category}
- Description: Retrieve products in a specific category
- Path Parameters:
  - `category`: Category name
- Query Parameters:
  - `_page` (optional): Page number for pagination (default: 1)
  - `_size` (optional): Number of items per page (default: 10)
  - `_order` (optional): Ordering of results (e.g., "price desc, title asc")
- Response: 
  ```json
  {
    "data": [
      {
        "id": "integer",
        "title": "string",
        "price": "number",
        "description": "string",
        "category": "string",
        "image": "string",
        "rating": {
          "rate": "number",
          "count": "integer"
        }
      }
    ],
    "totalItems": "integer",
    "currentPage": "integer",
    "totalPages": "integer"
  }
  ```



## Carts API

### Carts

#### GET /carts
- Description: Retrieve a list of all carts
- Query Parameters:
  - `_page` (optional): Page number for pagination (default: 1)
  - `_size` (optional): Number of items per page (default: 10)
  - `_order` (optional): Ordering of results (e.g., "id desc, userId asc")
- Response: 
  ```json
  {
    "data": [
      {
        "id": "integer",
        "userId": "integer",
        "date": "string (date)",
        "products": [
          {
            "productId": "integer",
            "quantity": "integer"
          }
        ]
      }
    ],
    "totalItems": "integer",
    "currentPage": "integer",
    "totalPages": "integer"
  }
  ```

#### POST /carts
- Description: Add a new cart
- Request Body:
  ```json
  {
    "userId": "integer",
    "date": "string (date)",
    "products": [
      {
        "productId": "integer",
        "quantity": "integer"
      }
    ]
  }
  ```
- Response: 
  ```json
  {
    "id": "integer",
    "userId": "integer",
    "date": "string (date)",
    "products": [
      {
        "productId": "integer",
        "quantity": "integer"
      }
    ]
  }
  ```

#### GET /carts/{id}
- Description: Retrieve a specific cart by ID
- Path Parameters:
  - `id`: Cart ID
- Response: 
  ```json
  {
    "id": "integer",
    "userId": "integer",
    "date": "string (date)",
    "products": [
      {
        "productId": "integer",
        "quantity": "integer"
      }
    ]
  }
  ```

#### PUT /carts/{id}
- Description: Update a specific cart
- Path Parameters:
  - `id`: Cart ID
- Request Body:
  ```json
  {
    "userId": "integer",
    "date": "string (date)",
    "products": [
      {
        "productId": "integer",
        "quantity": "integer"
      }
    ]
  }
  ```
- Response: 
  ```json
  {
    "id": "integer",
    "userId": "integer",
    "date": "string (date)",
    "products": [
      {
        "productId": "integer",
        "quantity": "integer"
      }
    ]
  }
  ```

#### DELETE /carts/{id}
- Description: Delete a specific cart
- Path Parameters:
  - `id`: Cart ID
- Response: 
  ```json
  {
    "message": "string"
  }
  ```

  ## Users API
   
### Users

#### GET /users
- Description: Retrieve a list of all users
- Query Parameters:
  - `_page` (optional): Page number for pagination (default: 1)
  - `_size` (optional): Number of items per page (default: 10)
  - `_order` (optional): Ordering of results (e.g., "username asc, email desc")
- Response: 
  ```json
  {
    "data": [
      {
        "id": "integer",
        "email": "string",
        "username": "string",
        "password": "string",
        "name": {
          "firstname": "string",
          "lastname": "string"
        },
        "address": {
          "city": "string",
          "street": "string",
          "number": "integer",
          "zipcode": "string",
          "geolocation": {
            "lat": "string",
            "long": "string"
          }
        },
        "phone": "string",
        "status": "string (enum: Active, Inactive, Suspended)",
        "role": "string (enum: Customer, Manager, Admin)"
      }
    ],
    "totalItems": "integer",
    "currentPage": "integer",
    "totalPages": "integer"
  }
  ```

#### POST /users
- Description: Add a new user
- Request Body:
  ```json
  {
    "email": "string",
    "username": "string",
    "password": "string",
    "name": {
      "firstname": "string",
      "lastname": "string"
    },
    "address": {
      "city": "string",
      "street": "string",
      "number": "integer",
      "zipcode": "string",
      "geolocation": {
        "lat": "string",
        "long": "string"
      }
    },
    "phone": "string",
    "status": "string (enum: Active, Inactive, Suspended)",
    "role": "string (enum: Customer, Manager, Admin)"
  }
  ```
- Response: 
  ```json
  {
    "id": "integer",
    "email": "string",
    "username": "string",
    "password": "string",
    "name": {
      "firstname": "string",
      "lastname": "string"
    },
    "address": {
      "city": "string",
      "street": "string",
      "number": "integer",
      "zipcode": "string",
      "geolocation": {
        "lat": "string",
        "long": "string"
      }
    },
    "phone": "string",
    "status": "string (enum: Active, Inactive, Suspended)",
    "role": "string (enum: Customer, Manager, Admin)"
  }
  ```

#### GET /users/{id}
- Description: Retrieve a specific user by ID
- Path Parameters:
  - `id`: User ID
- Response: 
  ```json
  {
    "id": "integer",
    "email": "string",
    "username": "string",
    "password": "string",
    "name": {
      "firstname": "string",
      "lastname": "string"
    },
    "address": {
      "city": "string",
      "street": "string",
      "number": "integer",
      "zipcode": "string",
      "geolocation": {
        "lat": "string",
        "long": "string"
      }
    },
    "phone": "string",
    "status": "string (enum: Active, Inactive, Suspended)",
    "role": "string (enum: Customer, Manager, Admin)"
  }
  ```

#### PUT /users/{id}
- Description: Update a specific user
- Path Parameters:
  - `id`: User ID
- Request Body:
  ```json
  {
    "email": "string",
    "username": "string",
    "password": "string",
    "name": {
      "firstname": "string",
      "lastname": "string"
    },
    "address": {
      "city": "string",
      "street": "string",
      "number": "integer",
      "zipcode": "string",
      "geolocation": {
        "lat": "string",
        "long": "string"
      }
    },
    "phone": "string",
    "status": "string (enum: Active, Inactive, Suspended)",
    "role": "string (enum: Customer, Manager, Admin)"
  }
  ```
- Response: 
  ```json
  {
    "id": "integer",
    "email": "string",
    "username": "string",
    "password": "string",
    "name": {
      "firstname": "string",
      "lastname": "string"
    },
    "address": {
      "city": "string",
      "street": "string",
      "number": "integer",
      "zipcode": "string",
      "geolocation": {
        "lat": "string",
        "long": "string"
      }
    },
    "phone": "string",
    "status": "string (enum: Active, Inactive, Suspended)",
    "role": "string (enum: Customer, Manager, Admin)"
  }
  ```

#### DELETE /users/{id}
- Description: Delete a specific user
- Path Parameters:
  - `id`: User ID
- Response: 
  ```json
  {
    "id": "integer",
    "email": "string",
    "username": "string",
    "password": "string",
    "name": {
      "firstname": "string",
      "lastname": "string"
    },
    "address": {
      "city": "string",
      "street": "string",
      "number": "integer",
      "zipcode": "string",
      "geolocation": {
        "lat": "string",
        "long": "string"
      }
    },
    "phone": "string",
    "status": "string (enum: Active, Inactive, Suspended)",
    "role": "string (enum: Customer, Manager, Admin)"
  }
  ```

  ## Auth API
  
### Authentication

#### POST /auth/login
- Description: Authenticate a user
- Request Body:
  ```json
  {
    "username": "string",
    "password": "string"
  }
  ```
- Response: 
  ```json
  {
    "token": "string"
  }
  ```