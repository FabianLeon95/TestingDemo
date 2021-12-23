using System;
using TestingDemo.Application.Common.Exceptions;
using TestingDemo.Application.Common.Utils;
using Xunit;

namespace TestingDemo.Application.UnitTests.Utils
{
    public class InvoiceUtilsTests
    {
        public static readonly object[][] TheoryData =
        {
            new object[]{1000, DateTime.Now, DateTime.Now.AddHours(3), 3000 },
            new object[]{1000, DateTime.Now, DateTime.Now.AddHours(6), 5250 },
            new object[]{1000, DateTime.Now, DateTime.Now.AddHours(9), 6750 },
            new object[]{1000, DateTime.Now, DateTime.Now.AddHours(9).AddMinutes(14), 6750 },
            new object[]{1000, DateTime.Now, DateTime.Now.AddHours(9).AddMinutes(15), 7250 }
        };

        [Fact]
        public void GenerateCode_WithInvalidCode_ThrowsException()
        {
            // Arrange
            const string locationCode = "A01";
            const int consecutive = 1;

            // Act
            Action action = () => InvoiceUtils.GenerateCode(locationCode, consecutive);

            // Assert
            Assert.Throws<InvalidLocationCodeException>(action);
        }

        [Theory]
        [InlineData(1000, false, 130)]
        [InlineData(1000, true, 0)]
        public void CalculateTaxes_ReturnsCorrectValue(double price, bool isTaxExempt, double expectedValue)
        {
            // Act
            var result = InvoiceUtils.CalculateTaxes(price, isTaxExempt);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [MemberData(nameof(TheoryData))]
        public void CalculatePrice_ReturnsCorrectValue(double baseRate, DateTime checkIn, DateTime checkOut, double expectedValue)
        {
            // Act
            var result = InvoiceUtils.CalculatePrice(baseRate, checkIn, checkOut);

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
