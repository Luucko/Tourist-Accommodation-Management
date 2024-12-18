# Tourist Accommodation Management System

This is a console application for managing a tourist accommodation system. It allows users to manage customers, accommodations, and reservations, with features such as adding, removing, and updating entries. It also checks for overlapping reservations to avoid double-booking.

The system is designed using **N-tier architecture**, separating functionality into distinct layers for better maintainability and scalability. The application structure is modular and will soon transition into separate library projects for each component.

## Project Structure

The system is divided into the following folders and projects:

1. **Models**: Core entities of the application (e.g., `Accommodation`, `Customer`, `Reservation`, etc.).
2. **Data**: Manages storage and retrieval of customers, accommodations, and reservations.
3. **Rules**: Contains business logic and validation rules (e.g., ensuring no overlapping reservations).
4. **Exceptions**: Library to define custom exceptions used throughout the whole system to provide robust error management and clear feedback for invalid operations.
5. **Tests**: A separate project containing unit tests for all major features.
6. **ConsoleApp**: The entry point of the application that simulates user interaction.

Each component (Data, Rules, Models, Exceptions & ConsoleApp) will be transitioned into separate library projects to improve modularity.

## Features

- **Customer Management**: Add, update, and remove customers with information such as name, email, and contact info.
- **Accommodation Management**: Add and remove accommodations.
- **Reservation Management**: Manage reservations with features to avoid overlapping bookings.
- **Exception Handling**: Handle errors gracefully with custom exceptions for scenarios like invalid reservations, duplicate customers, or unavailable accommodations.
- **Unit Tests**: Validate the integrity and correctness of the application using comprehensive test coverage.

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
