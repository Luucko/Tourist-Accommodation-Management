using JetBrains.Annotations;
using TouristAccommodationManagement.Data;
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
        public void GetAccommodation_ShouldReturnCorrectAccommodation()
        {
            // Act
            var result = Accommodations.GetAccommodation(_accommodation.GetId);

            // Assert
            Assert.Equal(_accommodation, result);
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