using System;

namespace MySimpleCar
{
    public class Car
    {
        private bool _isEnging;
        private int _speed;
        private Gear _gear;
        private Direction _direction;

        public Car()
        {
            EndingOff();
            SetSpeed( 0 );
            SetGear( 0 );
            SetDireaction();
        }

        public string GetEngingInfo()
        {
            return _isEnging ? "включен" : "выключен";
        }

        public string GetSpeed()
        {
            return _speed.ToString();
        }

        public Gear GetGrear()
        {
            return _gear;
        }

        public Direction GetDirection()
        {
            return _direction;
        }

        public bool EndingOn()
        {
            _isEnging = true;

            return _isEnging;
        }

        public string EndingOff()
        {
            if ( _speed != 0 )
            {
                return "скорость больше 0";
            }

            if ( _gear != Gear.stay )
            {
                return "передача не является нейтральной";
            }

            _isEnging = false;

            return "успешно";
        }

        public string SetGear( int newGear )
        {

            if ( !_isEnging )
            {
                return "Двигатель не включен";
            }

            Gear gear = newGear switch
            {
                -1 => Gear.back,
                0 => Gear.stay,
                1 => Gear.first,
                2 => Gear.second,
                3 => Gear.therth,
                4 => Gear.forth,
                5 => Gear.fisth,
                _ => Gear.fail,
            };

            if ( gear == Gear.fail )
            {
                return "авто не имеет такую скорость";
            }
            var border = GetBorder( gear );

            if ( _speed < border._downBorder || _speed > border._upBorder )
            {
                return "скорость авто не в диапазоне";
            }

            if ( GetGrear() == Gear.back && gear != Gear.first && GetDirection() != Direction.stay )
            {
                return "ошибка, с задней передачи можно переключить на 1 только при 0 скорости";
            }

            if ( gear == Gear.back && GetDirection() == Direction.back )
            {
                return "ошибка, задную передачу можно можно включить только с 0 скоростью";
            }

            if ( GetDirection() == Direction.back && gear == Gear.first )
            {
                return "нельзя установить 1 скорость, пока машина движется назад";
            }
            _gear = gear;

            return "успешно";
        }

        public string SetSpeed( int newSpeed )
        {
            if ( !_isEnging )
            {
                return "двигатель не запущен";
            }

            if ( GetGrear() == Gear.stay && Convert.ToInt32( GetSpeed() ) < newSpeed )
            {

                return "нейтральная передача";
            }

            var checkBorder = GetBorder( GetGrear() );

            if ( newSpeed >= checkBorder._downBorder && newSpeed <= checkBorder._upBorder )
            {
                _speed = newSpeed;
                SetDireaction();

                return String.Empty;
            }

            return newSpeed + " за пределами";
        }

        private void SetDireaction()
        {
            if ( GetSpeed() == 0.ToString() )
            {
                _direction = Direction.stay;
            }
            else if ( GetGrear() == Gear.back )
            {
                _direction = Direction.back;
            }
            else
            {
                _direction = Direction.forward;
            }
        }

        public Direction DirectionOfTravel()
        {
            return _direction;
        }

        private Border GetBorder( Gear gear )
        {
            return gear switch
            {
                Gear.back => SetBorder( 0, 20 ),
                Gear.stay => SetBorder( 0, 150 ),
                Gear.first => SetBorder( 0, 30 ),
                Gear.second => SetBorder( 20, 50 ),
                Gear.therth => SetBorder( 30, 60 ),
                Gear.forth => SetBorder( 40, 90 ),
                Gear.fisth => SetBorder( 50, 150 ),
                _ => SetBorder( 0, 0 ),
            };
        }

        private Border SetBorder(int down, int up )
        {
            return new Border { _downBorder = down, _upBorder = up };
        }

        private struct Border
        {
            public int _upBorder { get; set; }
            public int _downBorder { get; set; }
        }
    }

    public enum Direction
    {
        stay,
        back,
        forward
    }
    public enum Gear
    {
        back = -1,
        stay = 0,
        first = 1,
        second = 2,
        therth = 3,
        forth = 4,
        fisth = 5,
        fail = 6
    }
}
