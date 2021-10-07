using System;

namespace MyDate
{
    public class Date
    {
        private static readonly int  MIN_DAY = 1;
        private static readonly int MIN_MONTH = 1;
        private readonly int MAX_MONTH = 12;
        private static readonly int MIN_YEAR = 1970;

        private readonly int ticks;
        private int _day;
        private Month _month = (Month)MIN_MONTH;
        private int _year = MIN_YEAR;
        private bool _isValid = true;


        public Date( int day = 0 )
        {
            if (day == 0)
            {
                day++;
            }

            ticks = day;

            AddDays( day );
        }

        public Date( int day, Month month, int year )
        {
            ticks = TicksInDate( day, month, year );

            AddDays( ticks );

            if (year < MIN_YEAR)
            {
                _isValid = false;
            }

            if ((int)month < MIN_MONTH || (int)month > MAX_MONTH)
            {
                _isValid = false;
            }

            if (day < MIN_DAY || day > DayInMonth( month ))
            {
                _isValid = false;
            }

            if (IsValid())
            {
                _day = day;
                _month = month;
                _year = year;
            }
        }

        private int TicksInDate( int day, Month month, int year )
        {
            while (year > MIN_YEAR)
            {
                //упростить
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
                day += DayInMonth( month );

                month--;
            }

            return day;
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
            int day = ticks % 7;
            return (WeekDay)day;
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

        public static Date operator ++( Date date )
        {
            date.AddDays( date.GetDay() + 1 );

            return date;
        }

        public static Date operator -( Date oldDate, int day )
        {
            Date newDate = new Date( oldDate._day, oldDate._month, oldDate._year );
            newDate.MinusDays( day );

            return newDate;
        }

        public static Date operator -( Date oldDate, Date subtrahendDate )
        {
            Date newDate = new Date( oldDate._day, oldDate._month, oldDate._year );
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
            //переписать
            int day = _day;
            day -= downDay;
            while (day < 1)
            {
                if ((int)--_month < 1)
                {
                    _month = Month.DECEMBER;
                    _year--;

                    if (_year < MIN_YEAR)
                    {
                        _isValid = false;
                    }
                }

                day += DayInMonth( _month );
            }

            _day = day;
        }

        private void AddDays( int days )
        {
            int dayInCurrentMonth;
            while (days > ( dayInCurrentMonth = DayInMonth( _month ) ))
            {
                days -= dayInCurrentMonth;
                CheckMonth();

            }

            _day = days;
        }

        private void CheckMonth()
        {
            if ((int)++_month > 12)
            {
                _month = Month.JANUARY;

                CheckYear();
            }
        }

        private void CheckYear()
        {
            _year++;

            if (_year > 9999)
            {
                _isValid = false;
            }
        }

        private int DayInMonth( Month month )
        {
            return month switch
            {
                Month.FEBRUARY => IsLeapYear( _year ) ? 29 : 28,
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
