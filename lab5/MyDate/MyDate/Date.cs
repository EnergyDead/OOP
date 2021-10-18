using System;

namespace MyDate
{
    public class Date
    {
        private static readonly int MIN_DAY = 1;
        private static readonly int MIN_MONTH = 1;
        private readonly int MAX_MONTH = 12;
        private static readonly int MIN_YEAR = 1970;
        private static readonly int MAX_YEAR = 9999;
        private static readonly int MAX_DAYS = 2932898;

        private int ticks;
        // private int _day;
        // private Month _month = (Month)MIN_MONTH;
        // private int _year = MIN_YEAR;
        private bool _isValid = true;


        public Date( int day = 0 )
        {
            if ( day > MAX_DAYS )
            {
                _isValid = false;
            }

            ticks = day;
        }

        public Date( int day, Month month, int year )
        {

            if ( year < MIN_YEAR || year > MAX_YEAR )
            {
                _isValid = false;
            }

            if ( (int)month < MIN_MONTH || (int)month > MAX_MONTH )
            {
                _isValid = false;
            }

            if ( day < MIN_DAY || day > DayInMonth( month, year ) )
            {
                _isValid = false;
            }

            TicksInDate( day, month, year );
        }

        private void TicksInDate( int day, Month month, int year )
        {
            while ( year > MIN_YEAR )
            {
                //упростить
                if ( IsLeapYear( year ) )
                {
                    day += 366;
                }
                else
                {
                    day += 365;
                }

                year--;
            }

            while ( (int)month > 1 )
            {
                day += DayInMonth( month, year );

                month--;
            }

            ticks = day;
        }

        public int GetDay()
        {
            var days = ticks;
            var month = Month.JANUARY;
            int dayInCurrentMonth;
            int year = MIN_YEAR;
            while ( days > ( dayInCurrentMonth = DayInMonth( month, year ) ) )
            {
                days -= dayInCurrentMonth;
                if ( (int)++month > 12 )
                {
                    month = Month.JANUARY;
                    year++;
                }
            }

            if ( days == 0 )
            {
                return MIN_DAY;
            }

            return days;
        }

        public Month GetMonth()
        {
            var days = ticks;
            var month = Month.JANUARY;
            int dayInCurrentMonth;
            int year = MIN_YEAR;
            while ( days > ( dayInCurrentMonth = DayInMonth( month, year ) ) )
            {
                days -= dayInCurrentMonth;
                if ( (int)++month > 12 )
                {
                    month = Month.JANUARY;
                    year++;
                }
            }

            return month;
        }

        public int GetYear()
        {
            var days = ticks;
            var year = 1970;
            while ( days > dayInYear( year ) )
            {
                days -= dayInYear( year );
                year++;
            }

            return year;
        }

        private int dayInYear( int year )
        {
            if ( IsLeapYear( year ) )
            {
                return 366;
            }

            return 365;
        }

        public WeekDay GetWeekDay()
        {
            int day = ( ticks + 3 ) % 7;

            return (WeekDay)day;
        }

        public bool IsValid()
        {
            return _isValid;
        }

        public static Date operator +( Date oldDate, int days )
        {
            Date newDate = new Date( oldDate.GetDay(), oldDate.GetMonth(), oldDate.GetYear() );
            newDate.AddDays( days );

            return newDate;
        }

        public static Date operator ++( Date date )
        {
            date.AddDays( 1 );

            return date;
        }

        public static Date operator -( Date oldDate, int day )
        {
            Date newDate = new Date( oldDate.GetDay(), oldDate.GetMonth(), oldDate.GetYear() );
            newDate.MinusDays( day );

            return newDate;
        }

        public static Date operator -( Date oldDate, Date subtrahendDate )
        {
            Date newDate = new Date( oldDate.GetDay(), oldDate.GetMonth(), oldDate.GetYear() );
            int days = subtrahendDate.ticks;
            newDate.MinusDays( days );

            return newDate;
        }

        public static Date operator --( Date date )
        {
            date.MinusDays( 1 );

            return date;
        }

        private void MinusDays( int downDay )
        {
            // переписать, поставить проверку на MAXTiCKs и менять isvalid если переселкло значение
            if ( ticks < downDay )
            {
                _isValid = false;

                return;
            }

            ticks -= downDay;
        }

        private void AddDays( int days )
        {
            ticks += days;

            if ( ticks > MAX_DAYS )
            {
                _isValid = false;
            }
            // переписать, поставить проверку на MAXTiCKs и менять isvalid если переселкло значение
        }

        private int DayInMonth( Month month, int year )
        {
            return month switch
            {
                Month.FEBRUARY => IsLeapYear( year ) ? 29 : 28,
                Month.APRIL or Month.JANUARY or Month.SEPTEMBER or Month.NOVEMBER => 30,
                _ => 31,
            };
        }

        private bool IsLeapYear( int year )
        {
            return ( ( year % 400 == 0 ) || ( year % 4 == 0 ) && ( year % 100 != 0 ) );
        }
    }
}
