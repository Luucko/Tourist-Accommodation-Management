# Tourist Accommodation Management System

This is a console application for managing a simple tourist accommodation system. It allows users to manage customers, accommodations, and reservations, with features such as adding, removing, and updating entries. It also checks for overlapping reservations to avoid double-booking.

## Project Structure

- **Models**: Contains the classes representing the core entities of the application, such as `Accommodation`, `Customer`, and `Reservation`. Also includes an enum `ReservationStatus` for managing reservation statuses (Booked, Checked-In, Checked-Out, Cancelled).
  
- **Data**: Contains classes responsible for data management. This includes handling the lists of accommodations, customers, and reservations. It includes methods for adding, removing, and retrieving these entities.
  
- **Services**: Contains business logic and rule validation for accommodations, customers, and reservations. This includes checks for overlapping reservations and updating the status of entities.

- **Program**: The entry point of the application, where customers, accommodations, and reservations are created and displayed in a simulated console environment.

## Features

- **Customer Management**: Create and manage customers with basic information (name, email, contact info).
- **Accommodation Management**: Add and remove accommodations. Update their availability.
- **Reservation Management**: Create, update, and manage reservations. Prevent overlapping bookings with the same accommodation.

## Installation

### Prerequisites

- .NET 8.0 or later
- A code editor like [Visual Studio Code](https://code.visualstudio.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)

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

4. Run the project:

   ```bash
   dotnet run
   ```

## Usage

User usage interface yet to be implemented...

## Classes and Methods

### Accommodation

- **Properties**:
  - `ID`: Unique identifier for the accommodation.
  - `Name`: Name of the accommodation (e.g., "Beachside Apartment").
  - `Type`: Type of accommodation (e.g., "Apartment", "House").
  - `PricePerNight`: Price per night for booking.
  - `IsAvailable`: Whether the accommodation is available for booking.

- **Methods**:
  - `UpdateStatus`: Updates the availability of the accommodation.

### Customer

- **Properties**:
  - `ID`: Unique identifier for the customer.
  - `Name`: Name of the customer.
  - `Email`: Customer's email address.
  - `ContactInfo`: Optional contact info.

### Reservation

- **Properties**:
  - `Id`: Unique identifier for the reservation.
  - `Customer`: The customer making the reservation.
  - `Accommodation`: The accommodation being booked.
  - `CheckInDate`: The start date of the reservation.
  - `CheckOutDate`: The end date of the reservation.
  - `Status`: Current status of the reservation (Booked, Checked-In, Checked-Out, Cancelled).

- **Methods**:
  - `UpdateStatus`: Updates the status of the reservation (e.g., "Checked-In" to "Checked-Out").

### ReservationStatus (Enum)

This enum defines the possible statuses for a reservation:

- `Booked`
- `CheckedIn`
- `CheckedOut`
- `Cancelled`

### Services

- **AccommodationRules**: Manages business rules related to accommodations.
- **CustomerRules**: Manages business rules related to customers.
- **ReservationRules**: Manages business rules related to reservations.