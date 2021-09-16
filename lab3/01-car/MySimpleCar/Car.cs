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

            return String.Empty;
        }

        public string SetGear( int newGear )
        {

            if ( !_isEnging )
            {
                return "Двигатель не включен";
            }

            Gear gear = Gear.fail;
            switch ( newGear )
            {
                case -1:
                    gear = Gear.back;
                    break;
                case 0:
                    gear = Gear.stay;
                    break;
                case 1:
                    gear = Gear.first;
                    break;
                case 2:
                    gear = Gear.second;
                    break;
                case 3:
                    gear = Gear.therth;
                    break;
                case 4:
                    gear = Gear.forth;
                    break;
                case 5:
                    gear = Gear.fisth;
                    break;
                default:
                    break;
            }

            Transmission transmission = _transmissions.Select( t => t).Where( t => t._gear == gear).First();

            if ( _speed >= transmission._downBorder && _speed <= transmission._upBorder ) 
            {
                _gear = gear;

                return "успешно";
            }

            return "скорость авто не в диапазоне";
        }

        public string SetSpeed( int newSpeed )
        {
            if ( !_isEnging )
            {
                return "двигатель не запущен";
            }
            var checkBorder = _transmissions.Select( t => t ).Where( t => t._gear == _gear ).First();

            if ( newSpeed > checkBorder._downBorder || newSpeed < checkBorder._upBorder )
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
