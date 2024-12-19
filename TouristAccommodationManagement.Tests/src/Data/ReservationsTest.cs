using System;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;
using Xunit;
using Xunit.Abstractions;

namespace TouristAccommodationManagement.Tests.src.Data;

public class ReservationsTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private Customer _customer;
        private Accommodation _accommodation;
        private Reservation _reservation;

        public ReservationsTest(ITestOutputHelper testOutputHelper)
        {
            // Common setup for all tests
            Accommodations.ClearAccommodations();
            Customers.ClearCustomers();
            Reservations.ClearReservations();
            
            var idCust1 = CustomerService.GetNextId();
            _customer = new Customer(idCust1, "John Doe", "john.doe@email.com", "555-1234");
            CustomerService.AddCustomer(_customer);

            var idAcc1 = AccommodationService.GetNextId();
            _accommodation = new Accommodation(idAcc1, "Beachside Apartment", "Apartment", 120.50);
            AccommodationService.AddAccommodation(_accommodation);

            var idRes1 = ReservationService.GetNextId();
            _reservation = new Reservation(idRes1, _customer, _accommodation, new DateTime(2024, 12, 20), new DateTime(2024, 12, 24));

            // Add the default reservation in the setup
            Reservations.AddReservation(_reservation);
        }

        [Fact]
        public void AddReservation_ShouldAddReservation()
        {
            // Arrange
            var newReservation = new Reservation(ReservationService.GetNextId(), _customer, _accommodation, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30));

            // Act
            var success = ReservationService.AddReservation(newReservation);

            // Assert
            Assert.True(success);
            Assert.Contains(newReservation, Reservations.GetAllReservations());
        }

        [Fact]
        public void AddReservation_OverlappingDates_ShouldThrowInvalidReservationException()
        {
            // Arrange
            var overlappingReservation = new Reservation(
                ReservationService.GetNextId(),
                _customer,
                _accommodation,
                new DateTime(2024, 12, 22),
                new DateTime(2024, 12, 26));

            // Act & Assert
            var exception = Assert.Throws<InvalidReservationException>(() =>
                ReservationService.AddReservation(overlappingReservation));

            // Assert
            Assert.Equal("The reservation is invalid or overlaps with an existing reservation.", exception.Message);
        }



        [Fact]
        public void GetReservation_ShouldReturnCorrectReservation()
        {
            // Arrange
            var reservation2 = new Reservation(ReservationService.GetNextId(), _customer, _accommodation, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30));
            ReservationService.AddReservation(reservation2);
            
            // Act
            var result = Reservations.GetReservation(reservation2.GetId);

            // Assert
            Assert.Equal(reservation2, result);
        }

        [Fact]
        public void RemoveReservation_ShouldRemoveCorrectReservation()
        {
            // Act
            Reservations.RemoveReservation(_reservation);

            // Assert
            Assert.DoesNotContain(_reservation, Reservations.GetAllReservations());
        }

        [Fact]
        public void UpdateStatus_ShouldUpdateTheStatusCorrectly()
        {
            // Arrange
            var newStatus = ReservationStatus.CheckedIn;

            // Act
            var result = _reservation.UpdateStatus(newStatus);

            // Assert
            Assert.True(result);
            var updatedReservation = Reservations.GetReservation(_reservation.GetId);
            Assert.Equal(newStatus, updatedReservation.GetStatus);
        }

        [Fact]
        public void GetAllReservations_ShouldReturnAllReservations()
        {
            // Arrange
            var reservation2 = new Reservation(ReservationService.GetNextId(), _customer, _accommodation, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30));
            Reservations.AddReservation(reservation2);

            // Act
            var allReservations = Reservations.GetAllReservations();

            // Assert
            Assert.Contains(_reservation, allReservations);
            Assert.Contains(reservation2, allReservations);
        }

        [Fact]
        public void FailingTest_ForSimulation()
        {
            // Simulating a failing test
            Assert.False(true, "This test is designed to fail.");
        }

        // Test for ReservationNotFoundException when trying to remove a reservation that doesn't exist
        [Fact]
        public void RemoveReservation_ShouldThrowReservationNotFoundException_WhenReservationToRemoveNotFound()
        {
            // Act & Assert
            var exception = Assert.Throws<ReservationNotFoundException>(() =>
                Reservations.RemoveReservation(new Reservation(999, _customer, _accommodation, new DateTime(2024, 12, 25), new DateTime(2024, 12, 30))));
            Assert.Equal("The reservation to remove was not found.", exception.Message);
        }
    }