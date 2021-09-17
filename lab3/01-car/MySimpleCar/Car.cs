using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleCar
{
    public class Car
    {
        private bool _isEnging;
        private int _speed;
        private Gear _gear;
        private List<Transmission> _transmissions = new();

        public Car()
        {
            _isEnging = false;
            _speed = 0;
            _gear = Gear.stay;
            SetTransmission();
        }

        public string GetEngingInfo()
        {
            return _isEnging ? "включен" : "выключен";
        }

        public string GetSpeed()
        {
            return _speed.ToString();
        }

        public string GetGrear()
        {
            return _gear.ToString();
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

            var transmissions = _transmissions.Select( t => t ).Where( t => t._gear == gear );

            if ( transmissions.Count() != 1 )
            {
                return "авто не имеет такую скорость";
            }

            var transmission = transmissions.First();

            if ( _speed < transmission._downBorder || _speed > transmission._upBorder )
            {
                return "скорость авто не в диапазоне";
            }

            if ( GetGrear() == Gear.back.ToString() && transmission._gear != Gear.stay )
            {
                return "ошибка, с задней передачи можно переключить только на нейтральную";
            }

            if ( transmission._gear == Gear.back && GetGrear() != Gear.stay.ToString() )
            {
                return "ошибка, задную передачу можно можно включить только с нейтральной";
            }

            _gear = gear;

            return "успешно";


        }


        private Transmission error( Gear gear )
        {
            var transmissions = _transmissions.Select( t => t ).Where( t => t._gear == gear );

            if ( transmissions.Count() != 1 )
            {
            }

            return transmissions.First();
        }

        public string SetSpeed( int newSpeed )
        {
            if ( !_isEnging )
            {
                return "двигатель не запущен";
            }

            if ( GetGrear() == Gear.stay.ToString() && Convert.ToInt32( GetSpeed() ) < newSpeed )
            {

                return "нейтральная передача";
            }

            var checkBorder = _transmissions.Select( t => t ).Where( t => t._gear == _gear ).First();

            if ( newSpeed >= checkBorder._downBorder && newSpeed <= checkBorder._upBorder )
            {
                _speed = newSpeed;

                return String.Empty;
            }

            return newSpeed + " за пределами";
        }

        public string DirectionOfTravel()
        {
            if ( _speed == 0 )
            {
                return "стоит";
            }

            if ( _gear == Gear.back )
            {
                return "назад";
            }

            return "вперед";
        }

        private struct Transmission
        {
            public Gear _gear { get; set; }
            public int _upBorder { get; set; }
            public int _downBorder { get; set; }

            public Transmission( Gear gear, int downBorder, int upBorder )
            {
                _gear = gear;
                _downBorder = downBorder;
                _upBorder = upBorder;
            }
        }

        private void SetTransmission()
        {
            _transmissions.Add( new Transmission( Gear.back, 0, 20 ) );
            _transmissions.Add( new Transmission( Gear.stay, 0, 150 ) );
            _transmissions.Add( new Transmission( Gear.first, 0, 30 ) );
            _transmissions.Add( new Transmission( Gear.second, 20, 50 ) );
            _transmissions.Add( new Transmission( Gear.therth, 30, 60 ) );
            _transmissions.Add( new Transmission( Gear.forth, 40, 90 ) );
            _transmissions.Add( new Transmission( Gear.fisth, 50, 150 ) );
        }
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
