using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void GetStatistics()
        {
            var book = new InMemoryBook();
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            var statistics = book.GetStatitics();

            Assert.Equal(85.6, statistics.Average, 1);
            Assert.Equal(77.3, statistics.Low);
            Assert.Equal(90.5, statistics.High);
            Assert.Equal('B', statistics.Letter);
        }
    }
}
