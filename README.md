# SalesRecord - API for Sales Records

## Overview

This project is an API implementation for managing sales records in a retail store. It is designed using Domain-Driven Design (DDD) principles and includes features for managing sales transactions, applying discounts, and ensuring business rules are respected.

## Features

- **Sales Records**: Complete CRUD operations to manage sales records.
- **Discount Logic**: Implements discount rules based on product quantity.
- **Validation**: Ensures that business rules for sales are enforced.
- **Error Handling**: Proper error responses and logging for API errors.
- **Testing**: Unit tests for business logic and API endpoints.

## Business Rules

- **Discount Logic**:
  - 4+ items: 10% discount
  - 10-20 items: 20% discount
  - No discount for fewer than 4 items
  - Maximum of 20 identical items per sale


## API Documentation

- **Sale Records**:
  - `POST /api/salerecords`: Create a new sale record.
  - `GET /api/salerecords/{id}`: Retrieve a sale record by ID.
  - `DELETE /api/salerecords/{id}`: Delete a sale record.
  - `PUT /api/salerecords/{id}/cancel`: Update Sale status to Cancel.

## How to Run the Project

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL (database systems)
- Docker (for containerization)

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/JeffAndre0/SalesRecord
   ```

2. Install the required dependencies:
   ```bash
   cd src/WebApi
   dotnet restore
   ```

3. Set up the environment variables for PostgreSQL in your `appsettings.json` file:
   ```
   DefaultConnection="yourConnectrionString"
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. The API should now be running at `http://localhost:5119`.

### Running Tests

To run unit tests, use the following command:
```bash
dotnet test
```

## Conclusion

This API provides all the necessary endpoints and logic for managing sales records and applying discounts. The code is structured to ensure separation of concerns and maintainability, with clear testing coverage for the key business logic.
