# Tourist Accommodation Management System

This is a console application for managing a tourist accommodation system. It allows users to manage customers, accommodations, and reservations, with features such as adding, removing, and updating entries. It also checks for overlapping reservations to avoid double-booking.

The system is designed using **N-tier architecture**, separating functionality into distinct layers for better maintainability and scalability. The application structure is modular and will soon transition into separate library projects for each component.

## Project Structure

The system is divided into the following folders and projects:

1. **Models**: Core entities of the application (e.g., `Accommodation`, `Customer`, `Reservation`, etc.).
2. **Data**: Manages storage and retrieval of customers, accommodations, and reservations.
3. **Services**(Before: Rules): Contains business logic and validation rules (e.g., ensuring no overlapping reservations).
4. **Exceptions**: Library to define custom exceptions used throughout the whole system to provide robust error management and clear feedback for invalid operations. Also contains FileHandlers folder for managing file I/O operations.
6. **Tests**: A separate project containing unit tests for all major features. (Known bug: clicking twice on "run all tests" will sometimes give different results. Running tests like `GetReservation_ShouldReturnCorrectReservation()` separately proves success, but running it globally can cause failures.)
7. **ConsoleApp**: The entry point of the application that simulates user interaction.

Each component (Data, Services, Models, Exceptions & ConsoleApp) will be transitioned into separate library projects to improve modularity.

## Features

- **Customer Management**: Add, update, and remove customers with information such as name, email, and contact info.
- **Accommodation Management**: Add and remove accommodations, and save/load them from files.
- **Reservation Management**: Manage reservations with features to avoid overlapping bookings. Save and load reservations from files.
- **File Handling**: Accommodations, customers, and reservations can now be saved to and loaded from text files using `|` as a delimiter.
- **Exception Handling**: Handle errors gracefully with custom exceptions for scenarios like invalid reservations, duplicate customers, or unavailable accommodations.
- **Unit Tests**: Validate the integrity and correctness of the application using comprehensive test coverage.

## File Handling Updates

- **Accommodations**: Accommodations are saved to a file located at `files/accommodations`. This includes the accommodation ID, name, type, and price per night.
- **Customers**: Customer details are saved to a file located at `files/customers`. This includes customer ID, name, and email.
- **Reservations**: Reservations are saved to a file located at `files/reservations`. This includes reservation ID, customer ID, accommodation ID, check-in date, and check-out date.

Each entity's data is saved in a timestamped text file with a `.txt` extension. The `SaveToFile` method generates these files dynamically. The data is also loaded back into the application when required using the `LoadFile` methods for each entity.

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

This will start the application and simulate adding customers, accommodations, and reservations. It will also save and load the data from text files.

## File Structure for Data Storage

- **customers**: Stored in `files/customers` as timestamped `.txt` files (e.g., `customers_12-19-2024_15-30-45.txt`).
- **accommodations**: Stored in `files/accommodations` as timestamped `.txt` files (e.g., `accommodations_12-19-2024_15-30-45.txt`).
- **reservations**: Stored in `files/reservations` as timestamped `.txt` files (e.g., `reservations_12-19-2024_15-30-45.txt`).

Each file contains data separated by a pipe (`|`) character, with each line representing a single entity.

### Known Data Persistance bug
Data files do not show up in the project structure... 
