using GradeBook;
using System;
using Xunit;

namespace GradeBookTest
{
    public class BookTests
    {
        [Fact]
        public void BookDoesNotAddTooHighGrades()
        {
            // arrange
            var book = new InMemoryBook("");
            try
            {
                book.AddGrade(105);
            }
            catch (ArgumentException)
            {
            }

            // act
            var count = book.GetGradeCount();

            // asserts
            Assert.Equal(0, count);
        }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
