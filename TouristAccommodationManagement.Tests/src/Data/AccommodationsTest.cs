using JetBrains.Annotations;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Exceptions;
using TouristAccommodationManagement.Models;
using TouristAccommodationManagement.Services;
using Xunit;
using Xunit.Abstractions;

namespace TouristAccommodationManagement.Tests.Data;

[TestSubject(typeof(Accommodations))]
    public class AccommodationsTest
    {
        private readonly Accommodation _accommodation;

        public AccommodationsTest(ITestOutputHelper testOutputHelper)
        {
            // Clear accommodations before each test
            Accommodations.ClearAccommodations();

            // Initialize a default accommodation
            _accommodation = new Accommodation(Accommodations.GetNextId(), "Beachside Apartment", "Apartment", 130);
            Accommodations.AddAccommodation(_accommodation);  // Add default accommodation during setup
        }

        [Fact]
        public void AddAccommodation_ShouldAddAccommodation()
        {
            // Arrange
            var newAccommodation = new Accommodation(Accommodations.GetNextId(), "Mountain Cabin", "House", 200.00);

            // Act
            Accommodations.AddAccommodation(newAccommodation);

            // Assert
            var allAccommodations = Accommodations.GetAllAccommodations();
            Assert.Contains(newAccommodation, allAccommodations);
        }

        [Fact]
        public void AddAccommodation_ShouldThrowAccommodationAlreadyExistsException_WhenAccommodationAlreadyExists()
        {
            // Arrange
            var duplicateAccommodation = new Accommodation(_accommodation.GetId, "Beachside Apartment", "Apartment", 130);

            // Act & Assert
            var exception = Assert.Throws<AccommodationAlreadyExistsException>(() =>
                Accommodations.AddAccommodation(duplicateAccommodation));
            Assert.Equal($"Accommodation with ID {_accommodation.GetId} already exists.", exception.Message);
        }

        [Fact]
        public void GetAccommodation_ShouldReturnCorrectAccommodation()
        {
            // Act
            var result = Accommodations.GetAccommodation(_accommodation.GetId);

            // Assert
            Assert.Equal(_accommodation, result);
        }

        [Fact]
        public void GetAccommodation_ShouldThrowAccommodationNotFoundException_WhenAccommodationNotFound()
        {
            // Act & Assert
            var exception = Assert.Throws<AccommodationNotFoundException>(() =>
                Accommodations.GetAccommodation(999));  // ID that doesn't exist
            Assert.Equal("Accommodation with ID 999 not found.", exception.Message);
        }

        [Fact]
        public void RemoveAccommodation_ShouldRemoveCorrectAccommodation()
        {
            // Act
            Accommodations.RemoveAccommodation(_accommodation.GetId);

            // Assert
            var allAccommodations = Accommodations.GetAllAccommodations();
            Assert.DoesNotContain(_accommodation, allAccommodations);
        }

        [Fact]
        public void RemoveAccommodation_ShouldThrowAccommodationNotFoundException_WhenAccommodationToRemoveNotFound()
        {
            // Act & Assert
            var exception = Assert.Throws<AccommodationNotFoundException>(() =>
                Accommodations.RemoveAccommodation(999));  // ID that doesn't exist
            Assert.Equal("Accommodation with ID 999 not found.", exception.Message);
        }

        [Fact]
        public void GetNextId_ShouldReturnCorrectId()
        {
            // Arrange
            var initialId = Accommodations.GetNextId();
            var accommodation3 = new Accommodation(Accommodations.GetNextId(), "Mountain Cabin", "House", 200.00);

            // Act
            Accommodations.AddAccommodation(accommodation3);
            var nextId = Accommodations.GetNextId();

            // Assert
            Assert.Equal(initialId + 1, nextId);
        }

        [Fact]
        public void GetAllAccommodations_ShouldReturnAllAccommodations()
        {
            // Arrange
            var accommodation2 = new Accommodation(Accommodations.GetNextId(), "Mountain Cabin", "House", 200.00);
            Accommodations.AddAccommodation(accommodation2);  // Add a second accommodation for testing

            // Act
            var result = Accommodations.GetAllAccommodations();

            // Assert
            Assert.Contains(_accommodation, result);
            Assert.Contains(accommodation2, result);
        }
    }