# Tourist Accommodation Management System

This is a console application for managing a tourist accommodation system. It allows users to manage customers, accommodations, and reservations, with features such as adding, removing, and updating entries. It also checks for overlapping reservations to avoid double-booking.

The system is designed using **N-tier architecture**, separating functionality into distinct layers for better maintainability and scalability. The application structure is modular and has been organized into separate library projects for each component.

## Project Structure

The system consists of the following projects:

1. **Models**: 
   - Contains the core entities of the application (e.g., `Accommodation`, `Customer`, `Reservation`, etc.).
   - Shared by other projects as a global library.

2. **Data**: 
   - Responsible for data storage and retrieval for customers, accommodations, and reservations.
   - Implements file handling for saving and loading data.

3. **Services**: 
   - Contains business logic and validation rules (e.g., ensuring no overlapping reservations).

4. **Exceptions**: 
   - Defines custom exceptions for robust error handling.
   - Includes a `FileHandlers` folder for managing file I/O operations.

5. **Tests**: 
   - A separate project with unit tests for all major features to ensure application correctness.

6. **ConsoleApp**: 
   - The entry point of the application.
   - Simulates user interaction for managing customers, accommodations, and reservations.

---

## Features

- **Customer Management**: Add, update, and remove customers with information such as name, email, and contact info.
- **Accommodation Management**: Add and remove accommodations, and save/load them from files.
- **Reservation Management**: Manage reservations with features to avoid overlapping bookings. Save and load reservations from files.
- **File Handling**: Save and load data for accommodations, customers, and reservations using text files.
- **Exception Handling**: Handle errors gracefully with custom exceptions for scenarios like invalid reservations or unavailable accommodations.
- **Unit Tests**: Validate application integrity with comprehensive test coverage.

---

## Installation

### Prerequisites

- .NET 8.0 or later
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)

### Steps

1. Clone this repository:

   ```bash
   git clone https://gitlab.com/object-oriented-programming4472747/tourist-accommodation-management.git
   ```

2. Navigate to the project directory:

   ```bash
   cd TouristAccommodationManagement
   ```

3. Restore the project dependencies:

   ```bash
   dotnet restore
   ```

4. Run the ConsoleApp:

   ```bash
   dotnet run --project ConsoleApp
   ```

---

## Data Storage

- **File Structure**:
  - `files/customers`: Stores customer details in `.txt` files (e.g., `customers_12-19-2024_15-30-45.txt`).
  - `files/accommodations`: Stores accommodation details in `.txt` files (e.g., `accommodations_12-19-2024_15-30-45.txt`).
  - `files/reservations`: Stores reservation details in `.txt` files (e.g., `reservations_12-19-2024_15-30-45.txt`).

- **Format**: Each file contains data separated by the `|` delimiter, with each line representing a single entity.

---

## Known Issues

1. **Data Persistence Bug**:
   - Files saved by the application may not appear in the project structure, although they are saved successfully.

2. **IntelliSense Red Lines**:
   - Some library projects may show red curly lines due to IntelliSense desynchronization. Rebuilding the solution resolves this in most cases.

3. **Tests Behavior**:
   - Running all tests at once may produce inconsistent results. Running tests individually works as expected.
