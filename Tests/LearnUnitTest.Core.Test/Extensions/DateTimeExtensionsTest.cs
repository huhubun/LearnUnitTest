using LearnUnitTest.Core.Extensions;
using System;
using Xunit;

namespace LearnUnitTest.Core.Test.Extensions
{
    public class DateTimeExtensionsTest
    {
        [Fact]
        public void Date_in_two_dates()
        {
            // Arrange
            var date = new DateTime(2017, 1, 27);
            var startDate = new DateTime(2017, 1, 23);
            var endDate = new DateTime(2017, 1, 29);

            // Act
            var isIn = date.In(startDate, endDate);

            // Assert
            Assert.Equal(true, isIn);
        }

        [Fact]
        public void Date_not_in_two_dates()
        {
            // Arrange
            var date = new DateTime(2017, 1, 16);
            var startDate = new DateTime(2017, 1, 23);
            var endDate = new DateTime(2017, 1, 29);

            // Act
            var isIn = date.In(startDate, endDate);

            // Assert
            Assert.Equal(false, isIn);
        }

        [Fact]
        public void EndDate_is_less_than_startDate()
        {
            // Arrange
            var date = new DateTime(2017, 1, 27);
            var startDate = new DateTime(2017, 1, 23);
            var endDate = new DateTime(2017, 1, 1);

            // Act

            // Assert
            Assert.Throws<ArgumentException>("endDate", () => date.In(startDate, endDate));
        }
    }
}
