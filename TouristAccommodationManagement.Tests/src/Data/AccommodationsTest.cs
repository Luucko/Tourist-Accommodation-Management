using JetBrains.Annotations;
using TouristAccommodationManagement.Data;
using TouristAccommodationManagement.Models;
using Xunit;

namespace TouristAccommodationManagement.Tests.Data;

[TestSubject(typeof(Accommodations))]
public class AccommodationsTest
{

    private readonly Accommodation _accommodation;

        public AccommodationsTest()
        {
            // Common test setup
            _accommodation = new Accommodation(Accommodations.GetNextId(), "Beachside Apartment", "Apartment", 150.00);
        }

        [Fact]
        public void AddAccommodation_ShouldAddAccommodation()
        {
            // Act
            Accommodations.AddAccommodation(_accommodation);

            // Assert
            Assert.Contains(_accommodation, Accommodations.GetAllAccommodations());
        }

        [Fact]
        public void GetAccommodation_ShouldReturnCorrectAccommodation()
        {
            // Arrange
            Accommodations.AddAccommodation(_accommodation);

            // Act
            var result = Accommodations.GetAccommodation(_accommodation.ID);

            // Assert
            Assert.Equal(_accommodation, result);
        }

        [Fact]
        public void RemoveAccommodation_ShouldRemoveCorrectAccommodation()
        {
            // Arrange
            Accommodations.AddAccommodation(_accommodation);

            // Act
            Accommodations.RemoveAccommodation(_accommodation.ID);

            // Assert
            Assert.DoesNotContain(_accommodation, Accommodations.GetAllAccommodations());
        }

        [Fact]
        public void GetNextId_ShouldReturnCorrectId()
        {
            // Arrange
            var initialId = Accommodations.GetNextId();
            Accommodations.AddAccommodation(_accommodation);

            // Act
            var nextId = Accommodations.GetNextId();

            // Assert
            Assert.Equal(initialId + 1, nextId);
        }

        [Fact]
        public void GetAllAccommodations_ShouldReturnAllAccommodations()
        {
            // Arrange
            var accommodation2 = new Accommodation(Accommodations.GetNextId(), "Mountain Cabin", "House", 200.00);
            Accommodations.AddAccommodation(_accommodation);
            Accommodations.AddAccommodation(accommodation2);

            // Act
            var result = Accommodations.GetAllAccommodations();

            // Assert
            Assert.Contains(_accommodation, result);
            Assert.Contains(accommodation2, result);
        }

}