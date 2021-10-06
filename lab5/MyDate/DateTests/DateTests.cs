using MyDate;
using System;
using Xunit;

namespace DateTests
{
    public class DateTests
    {
        [Fact]
        public void CreateDate_CorrectInput_CorrectCreate()
        {
            Date date = new( 12, (Month)1, 2000 );

            Assert.NotNull( date );
            Assert.True( date.IsValid() );
            Assert.Equal( 12, date.GetDay() );
            Assert.Equal( Month.JANUARY, date.GetMonth() );
            Assert.Equal( 2000, date.GetYear() );
        }

        [Fact]
        public void CreateDate_ZeroInput_CorrectCreate()
        {
            Date date = new( 0 );
            Date date1 = new();

            Assert.NotNull( date );
            Assert.True( date.IsValid() );

            Assert.Equal( 1, date.GetDay() );
            Assert.Equal( Month.JANUARY, date.GetMonth() );
            Assert.Equal( 1970, date.GetYear() );
        }

        [Fact]
        public void CreateDate_BigInput_CorrectCreate()
        {
            Date date = new( 20000 );

            Assert.NotNull( date );
            Assert.True( date.IsValid() );

            Assert.Equal( 3, date.GetDay() );
            Assert.Equal( Month.OCTOBER, date.GetMonth() );
            Assert.Equal( 2024, date.GetYear() );
        }

        [Fact]
        public void CreateDate_IncorrectInput_FailedTrue()
        {
            Date date = new( 20000000 );

            Assert.NotNull( date );
            Assert.False( date.IsValid() );
        }

        [Fact]
        public void CheckOperandPlasOnDay_CorrectDate()
        {
            // Arrange
            Date date = new( 30 );
            int oldDay = date.GetDay();
            var oldMonth = date.GetMonth();
            int oldYear = date.GetYear();

            // Act
            date++;

            // Assert
            Assert.NotNull( date );
            Assert.True( date.IsValid() );

            Assert.Equal( 1, date.GetDay() );
            Assert.Equal( 30, oldDay );

            Assert.Equal( Month.JANUARY, oldMonth );
            Assert.Equal( Month.FEBRUARY, date.GetMonth() );
            Assert.Equal( oldYear, date.GetYear() );
        }

        [Fact]
        public void CheckOperandMinusOnDay_CorrectDate()
        {
            // Arrange
            Date date = new( 366 );
            int oldDay = date.GetDay();
            var oldMonth = date.GetMonth();
            int oldYear = date.GetYear();

            // Act
            date--;

            // Assert
            Assert.NotNull( date );
            Assert.True( date.IsValid() );

            Assert.Equal( 31, date.GetDay() );
            Assert.Equal( 1, oldDay );

            Assert.Equal( Month.JANUARY, oldMonth );
            Assert.Equal( Month.DECEMBER, date.GetMonth() );
            Assert.Equal( 1971, oldYear );
            Assert.Equal( 1970, date.GetYear() );
        }

        [Fact]
        public void CheckOperandMinusMoreDay_CorrectDate()
        {
            // Arrange
            Date date = new( 366 );
            int oldDay = date.GetDay();
            var oldMonth = date.GetMonth();
            int oldYear = date.GetYear();

            // Act
            date -= 12;

            // Assert
            Assert.NotNull( date );
            Assert.True( date.IsValid() );

            Assert.Equal( 20, date.GetDay() );
            Assert.Equal( 1, oldDay );

            Assert.Equal( Month.JANUARY, oldMonth );
            Assert.Equal( Month.DECEMBER, date.GetMonth() );
            Assert.Equal( 1971, oldYear );
            Assert.Equal( 1970, date.GetYear() );
        }
    }
}
