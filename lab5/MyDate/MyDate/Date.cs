using System;

namespace MyDate
{
    public class Date
    {
        private readonly int MIN_YEAR = 1970;
        private readonly int MIN_MONTH = 1;
        private readonly int MAX_MONTH = 12;
        private readonly int MIN_DAY = 1;

        private int _day;
        private Month _month;
        private int _year;
        private bool _isValid;


        public Date( int day = 0 )
        {
            _day = MIN_DAY;
            _month = (Month)MIN_MONTH;
            _year = MIN_YEAR;

            AddDays( day );
        }

        public Date( int day, Month month, int year )
        {
            _isValid = true;

            if ( year < MIN_YEAR )
            {
                _isValid = false;
            }

            if ( MIN_MONTH > (int)month || MAX_MONTH < (int)month )
            {
                _isValid = false;
            }

            if ( MIN_DAY > day || DayInMonth( month ) < day )
            {
                _isValid = false;
            }

            if ( IsValid() )
            {
                _day = day;
                _month = month;
                _year = year;
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

        public static Date operator +( Date ob, int days )
        {
            Date result = new Date( ob._day, ob._month, ob._year );
            result.AddDays( days );

            return result;
        }

        public void AddDays( int days )
        {
            _day += days;
            int dayInCurrentMonth;
            while ( _day > ( dayInCurrentMonth = DayInMonth( _month ) ) )
            {
                _day -= dayInCurrentMonth;

                if ( (int)++_month > 12 )
                {
                    _month = Month.JANUARY;

                    _year++;
                }
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
