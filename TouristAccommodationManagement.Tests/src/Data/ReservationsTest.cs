using System;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;
using Xunit;

namespace TouristAccommodationManagement.Tests.src.Data;

public class ReservationsTest
{
    private Customer _customer;
    private Accommodation _accommodation;
    private Reservation _reservation;

    public ReservationsTest()
    {
        // Common setup for all tests
        var idCust1 = CustomerRules.GetNextId();
        _customer = new Customer(idCust1, "John Doe", "john.doe@email.com", "555-1234");
        CustomerRules.AddCustomer(_customer);

        var idAcc1 = AccommodationRules.GetNextId();
        _accommodation = new Accommodation(idAcc1, "Beachside Apartment", "Apartment", 120.50);
        AccommodationRules.AddAccommodation(_accommodation);

        var idRes1 = ReservationRules.GetNextId();
        _reservation = new Reservation(idRes1, _customer, _accommodation, new DateTime(2024, 12, 20), new DateTime(2024, 12, 24));
    }

    [Fact]
    public void AddReservation()
    {
        // Act
        Reservations.AddReservation(_reservation);

        // Assert
        Assert.Contains(_reservation, Reservations.GetAllReservations());
    }
    
   
    [Fact]
    public void AddReservationInvalidDates()
    {
        // Arrange
        var reservation = new Reservation(ReservationRules.GetNextId(), _customer, _accommodation, new DateTime(2024, 12, 24), new DateTime(2024, 12, 20));

        // Act
        var success = Reservations.AddReservation(reservation);

        // Assert
        Assert.False(success);
    }
    
    [Fact] 
    public void AddReservation_OverlappingDates()
    {
        // Arrange
        var reservation2 = new Reservation(
            ReservationRules.GetNextId(), 
            _customer, 
            _accommodation, 
            new DateTime(2024, 12, 22), 
            new DateTime(2024, 12, 26));
    
        Reservations.AddReservation(_reservation);

        // Act
        var success = Reservations.AddReservation(reservation2); 

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void GetReservation()
    {
        // Arrange
        Reservations.AddReservation(_reservation);

        // Act
        var result = Reservations.GetReservation(_reservation.GetId);

        // Assert
        Assert.Equal(_reservation, result);
    }

    [Fact]
    public void RemoveReservation()
    {
        // Arrange
        Reservations.AddReservation(_reservation);

        // Act
        Reservations.RemoveReservation(_reservation);

        // Assert
        Assert.DoesNotContain(_reservation, Reservations.GetAllReservations());
    }

    [Fact]
    public void UpdateStatus_UpdatesTheStatusCorrectly()
    {
        // Arrange
        Reservations.ClearReservations();
        Reservations.AddReservation(_reservation);
        var newStatus = ReservationStatus.CheckedIn;

        // Act
        _reservation.UpdateStatus(newStatus);

        // Assert
        var updatedReservation = Reservations.GetReservation(_reservation.GetId);
        Assert.Equal(newStatus, updatedReservation.GetStatus);
    }


    [Fact]
    public void GetAllReservations()
    {
        // Arrange
        var idRes2 = ReservationRules.GetNextId();
        var reservation2 = new Reservation(idRes2, _customer, _accommodation, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30));

        Reservations.AddReservation(_reservation);
        Reservations.AddReservation(reservation2);

        // Act
        var reservations = Reservations.GetAllReservations();

        // Assert
        Assert.Contains(_reservation, reservations);
        Assert.Contains(reservation2, reservations);
    }
    
    //simulate failing test for teacher
}
