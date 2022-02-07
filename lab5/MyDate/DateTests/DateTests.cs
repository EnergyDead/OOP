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
            Date date = new( 12, (Month)4, 2222 );
            Date date1 = new( 92142 );

            Assert.NotNull( date );
            Assert.True( date.IsValid() );
            Assert.Equal( date1.GetDay(), date.GetDay() );
            Assert.Equal( date1.GetWeekDay(), date.GetWeekDay() );
            Assert.Equal( date1.GetMonth(), date.GetMonth() );
            Assert.Equal( date1.GetYear(), date.GetYear() );
        }

        [Fact]
        public void CreateDate_IncorrectInput_IsNotValid()
        {
            Date date = new( 31, (Month)12, 9999 );
            Date dateFaildYear = new( 12, (Month)4, 12222 );

            Assert.NotNull( dateFaildYear );
            Assert.False( dateFaildYear.IsValid() );

            Date dateFaildDay = new( 111, (Month)4, 4122 );

            Assert.NotNull( dateFaildDay );
            Assert.False( dateFaildDay.IsValid() );

            Date dateFaildMonth = new( 11, (Month)24, 4122 );

            Assert.NotNull( dateFaildMonth );
            Assert.False( dateFaildMonth.IsValid() );
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
        public void CheckWeekDay_CorrectDay()
        {
            // Arrange
            Date date = new();

            // Act
            WeekDay weekDay = date.GetWeekDay();

            // Assert
            Assert.NotNull( date );
            Assert.True( date.IsValid() );
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
            Assert.Equal( 31, oldDay );

            Assert.Equal( Month.JANUARY, oldMonth );
            Assert.Equal( Month.FEBRUARY, date.GetMonth() );
            Assert.Equal( oldYear, date.GetYear() );
        }

        [Fact]
        public void CheckOperandMinusOnDay_CorrectDate()
        {
            // Arrange
            Date date = new( 366 );
            DateTime dateTime = new( 365 );
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
            var weekDay = date.GetWeekDay();

            // Act
            date -= 12;

            // Assert
            Assert.NotNull( date );
            Assert.True( date.IsValid() );

            Assert.Equal( 23, date.GetDay() );
            Assert.Equal( 1, oldDay );

            Assert.Equal( Month.JANUARY, oldMonth );
            Assert.Equal( Month.DECEMBER, date.GetMonth() );
            Assert.Equal( 1971, oldYear );
            Assert.Equal( 1970, date.GetYear() );
        }

        [Fact]
        public void CheckOperandDateMinusDate_CorrectResult()
        {
            // Arrange
            Date mainDate = new( 366 );
            Date subtrahendDate = new( 22 );

            // Act
            Date date = mainDate - subtrahendDate;

            // Assert
            Assert.NotNull( mainDate );
            Assert.True( mainDate.IsValid() );
            Assert.Equal( 11, date.GetDay() );
            Assert.Equal( (Month)12, date.GetMonth() );
            Assert.Equal( 1970, date.GetYear() );
        }

        [Fact]
        public void GetDayOfWeek_CorrectInput_CorrectResult()
        {
            Date date = new( 1 );
            Date date1 = new( 8 );
            Date date2 = new( 15 );

            Assert.Equal( date.GetWeekDay(), date1.GetWeekDay() );
            Assert.Equal( date2.GetWeekDay(), date1.GetWeekDay() );
        }

        [Fact]
        public void CheckOperandPlasDays_CorrectDate()
        {
            Date date = new( 2 );
            var a = date.GetDay();
            var newDate = date + 12;

            Assert.Equal( 15, newDate.GetDay() );
            Assert.Equal( 1, date.GetDay() );
        }
    }
}
