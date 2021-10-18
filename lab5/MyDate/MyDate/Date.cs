namespace MyDate
{
    public class Date
    {
        private static readonly int MIN_DAY = 1;
        private static readonly int MIN_MONTH = 1;
        private static readonly int MAX_MONTH = 12;
        private static readonly int MIN_YEAR = 1970;
        private static readonly int MAX_YEAR = 9999;

        private static readonly int MIN_DAYS = 0;
        private static readonly int MAX_DAYS = 2932898;

        private int _days;
        private bool _isValid = true;

        public Date( int day = 0 )
        {
            _days = day;
        }

        public Date( int day, Month month, int year )
        {
            if (year < MIN_YEAR || year > MAX_YEAR)
            {
                _isValid = false;
            }

            if ((int)month < MIN_MONTH || (int)month > MAX_MONTH)
            {
                _isValid = false;
            }

            if (day < MIN_DAY || day > DayInMonth( month, year ))
            {
                _isValid = false;
            }

            DaysInDate( day, month, year );
        }

        private void DaysInDate( int day, Month month, int year )
        {
            while (year > MIN_YEAR)
            {
                if (IsLeapYear( year ))
                {
                    day += 366;
                }
                else
                {
                    day += 365;
                }

                year--;
            }

            while ((int)month > 1)
            {
                day += DayInMonth( month, year );

                month--;
            }

            _days = day;
        }

        public int GetDay()
        {
            var days = _days;
            var month = Month.JANUARY;
            Counter( ref days, ref month );

            if (days == 0)
            {
                return MIN_DAY;
            }

            return days;
        }

        public Month GetMonth()
        {
            var days = _days;
            var month = Month.JANUARY;
            Counter( ref days, ref month );

            return month;
        }

        public int GetYear()
        {
            var days = _days;
            var year = MIN_YEAR;

            while (days > dayInYear( year ))
            {
                days -= dayInYear( year );
                year++;
            }

            return year;
        }

        private void Counter( ref int days, ref Month month )
        {
            int dayInCurrentMonth;
            int year = MIN_YEAR;

            while (days > ( dayInCurrentMonth = DayInMonth( month, year ) ))
            {
                days -= dayInCurrentMonth;
                if ((int)++month > MAX_MONTH)
                {
                    month = Month.JANUARY;
                    year++;
                }
            }
        }

        private int dayInYear( int year )
        {
            return IsLeapYear( year ) ? 366 : 365;
        }

        public WeekDay GetWeekDay()
        {
            int day = ( _days + 3 ) % 7;

            return (WeekDay)day;
        }

        public bool IsValid()
        {
            return ( _days < MAX_DAYS ) && ( _days >= MIN_DAYS ) && _isValid;
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
            int days = subtrahendDate._days;
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
            _days -= downDay;
        }

        private void AddDays( int days )
        {
            this._days += days;
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
