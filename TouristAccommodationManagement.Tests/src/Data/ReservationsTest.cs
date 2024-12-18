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
        Reservations.AddReservation(_reservation);
        Assert.Contains(_reservation, Reservations.GetAllReservations());
    }

    [Fact]
    public void AddReservationInvalidDates()
    {
        var reservation = new Reservation(ReservationRules.GetNextId(), _customer, _accommodation, new DateTime(2024, 12, 24), new DateTime(2024, 12, 20));
        var success = ReservationRules.AddReservation(reservation);
        Assert.False(success);
    }

    [Fact]
    public void AddReservation_OverlappingDates()
    {
        var reservation2 = new Reservation(
            ReservationRules.GetNextId(),
            _customer,
            _accommodation,
            new DateTime(2024, 12, 22),
            new DateTime(2024, 12, 26));

        Reservations.AddReservation(_reservation);
        var success = ReservationRules.AddReservation(reservation2);
        Assert.False(success);
    }

    [Fact]
    public void GetReservation()
    {
        Reservations.AddReservation(_reservation);
        var result = Reservations.GetReservation(_reservation.GetId);
        Assert.Equal(_reservation, result);
    }

    [Fact]
    public void RemoveReservation()
    {
        Reservations.AddReservation(_reservation);
        Reservations.RemoveReservation(_reservation);
        Assert.DoesNotContain(_reservation, Reservations.GetAllReservations());
    }

    [Fact]
    public void UpdateStatus_UpdatesTheStatusCorrectly()
    {
        Reservations.ClearReservations();
        Reservations.AddReservation(_reservation);
        var newStatus = ReservationStatus.CheckedIn;

        _reservation.UpdateStatus(newStatus);

        var updatedReservation = Reservations.GetReservation(_reservation.GetId);
        Assert.Equal(newStatus, updatedReservation.GetStatus);
    }

    [Fact]
    public void GetAllReservations()
    {
        var idRes2 = ReservationRules.GetNextId();
        var reservation2 = new Reservation(idRes2, _customer, _accommodation, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30));

        Reservations.AddReservation(_reservation);
        Reservations.AddReservation(reservation2);

        var reservations = Reservations.GetAllReservations();

        Assert.Contains(_reservation, reservations);
        Assert.Contains(reservation2, reservations);
    }

    [Fact]
    public void FailingTest_ForSimulation()
    {
        // Simulating a failing test
        Assert.False(true, "This test is designed to fail.");
    }
}
