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
            Assert.Equal( 12, date.GetDay() );
            Assert.Equal( Month.JANUARY, date.GetMonth() );
            Assert.Equal( 2000, date.GetYear() );
        }
    }
}