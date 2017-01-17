using System;

namespace LearnUnitTest.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool In(this DateTime date, DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException($"{nameof(endDate)} must be greater than {nameof(startDate)}", nameof(endDate));
            }

            return startDate <= date && date <= endDate;
        }
    }
}
