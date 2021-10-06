using System;

namespace MyDate
{
    public class Date
    {
        private static readonly ushort MIN_DAY = 1;
        private static readonly ushort MIN_MONTH = 1;
        private readonly ushort MAX_MONTH = 12;
        private static readonly ushort MIN_YEAR = 1970;

        private ushort _day;
        private Month _month = (Month)MIN_MONTH;
        private ushort _year = MIN_YEAR;
        private bool _isValid = true;


        public Date( int day = 0 )
        {
            if ( day == 0 )
            {
                day++;
            }

            AddDays( day );
        }

        public Date( int day, Month month, int year )
        {
            if ( year < MIN_YEAR )
            {
                _isValid = false;
            }

            if ( (ushort)month < MIN_MONTH || (ushort)month > MAX_MONTH )
            {
                _isValid = false;
            }

            if ( day < MIN_DAY || day > DayInMonth( month ) )
            {
                _isValid = false;
            }

            if ( IsValid() )
            {
                _day = (ushort)day;
                _month = month;
                _year = (ushort)year;
            }
        }

        public int GetDay()
        {
            return _day;
        }

        public Month GetMonth()
        {
            return _month;
        }

        public int GetYear()
        {
            return _year;
        }
        public WeekDay GetWeekDay()
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            return _isValid;
        }

        public static Date operator +( Date oldDate, int days )
        {
            Date newDate = new Date( oldDate._day, oldDate._month, oldDate._year );
            newDate.AddDays( days );

            return newDate;
        }

        public static Date operator +( Date date, ushort day )
        {
            date.AddDays( day );

            return date;
        }

        public static Date operator ++( Date date )
        {
            date.AddDays( 1 );

            return date;
        }

        public static Date operator -( Date date, ushort day )
        {
            date.MinusDays( day );

            return date;
        }

        public static Date operator --( Date date )
        {
            date.MinusDays( 1 );

            return date;
        }

        private void MinusDays( ushort downDay )
        {
            int day = _day;
            day -= downDay;
            while ( day < 1 )
            {
                if ( (int)--_month < 1 )
                {
                    _month = Month.DECEMBER;
                    _year--;

                    if ( _year < MIN_YEAR )
                    {
                        _isValid = false;
                    }
                }

                day += DayInMonth( _month );
            }

            _day = (ushort)day;
        }

        private void AddDays( int days )
        {
            days += _day;
            int dayInCurrentMonth;
            while ( days > ( dayInCurrentMonth = DayInMonth( _month ) ) )
            {
                days -= dayInCurrentMonth;
                CheckMonth();

            }

            _day = (ushort)days;
        }

        private void CheckMonth()
        {
            if ( (int)++_month > 12 )
            {
                _month = Month.JANUARY;

                CheckYear();
            }
        }

        private void CheckYear()
        {
            _year++;

            if ( _year > 9999 )
            {
                _isValid = false;
            }
        }

        private int DayInMonth( Month month )
        {
            return month switch
            {
                Month.FEBRUARY => IsLeapYear() ? 29 : 28,
                Month.APRIL or Month.JANUARY or Month.SEPTEMBER or Month.NOVEMBER => 30,
                _ => 31,
            };
        }

        private bool IsLeapYear()
        {
            return ( ( _year % 400 == 0 ) || ( _year % 4 == 0 ) && ( _year % 100 != 0 ) );
        }
    }
}
