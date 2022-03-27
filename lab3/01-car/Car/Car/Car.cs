namespace CarSimulator
{
    public class Car
    {
        private readonly Dictionary<Gear, (int, int)> _gears;

        // положить в массив

        private int _speed;
        private bool _isEngineRunning;
        private Gear _gear;
        private Direction _direction;

        public int Speed
        {
            get
            {
                return _speed;
            }
        }
        public bool IsEngineRunning
        {
            get
            {
                return _isEngineRunning;
            }
        }
        public Gear Gear
        {
            get
            {
                return _gear;
            }
        }
        public Direction Direction
        {
            get
            {
                return _direction;
            }
        }

        public Car()
        {
            _speed = 0;
            _isEngineRunning = false;
            _gear = Gear.Neutral;
            _direction = Direction.OnPlace;
            _gears = SetGears(); // new Dictionary<Gear, (int, int)>();
        }

        public bool TurnOnEngine()
        {
            return _isEngineRunning ? _isEngineRunning : _isEngineRunning = true;
        }

        public bool TurnOffEngine()
        {
            if ( !_isEngineRunning )
            {
                return true;
            }

            if ( _direction == Direction.OnPlace && _gear == Gear.Neutral )
            {
                _isEngineRunning = false;

                return true;
            }

            return false;
        }
        public bool SetGear( int gear )
        {
            if ( (Gear)gear == _gear )
            {
                return true;
            }

            if ( !_isEngineRunning )
            {
                return (Gear)gear == Gear.Neutral;
            }

            if ( (Gear)gear == Gear.Neutral )
            {
                _gear = Gear.Neutral;

                return true;
            }

            if ( (Gear)gear == Gear.Reverse && _direction != Direction.OnPlace )
            {
                return false;
            }

            if ( GearInRange( (Gear)gear ) && _direction != Direction.Backward )
            {
                _gear = (Gear)gear;

                return true;
            }

            return false;
        }

        public bool SetSpeed( int speed )
        {
            if ( !SpeedInRange( speed ) )
            {
                return false;
            }

            if ( _gear == Gear.Neutral && speed >= _speed )
            {
                return false;
            }

            _speed = speed;
            SetDirection( speed );

            return true;
        }

        private bool SpeedInRange( int speed )
        {
            return speed >= _gears[ _gear ].Item1 && speed <= _gears[ _gear ].Item2;
        }

        private bool GearInRange( Gear gear )
        {
            return _speed >= _gears[ gear ].Item1 && _speed <= _gears[ gear ].Item2;
        }

        private static Dictionary<Gear, (int, int)> SetGears()
        {
            return new()
            {
                { Gear.Reverse, (0, 20) },
                { Gear.First, (0, 30) },
                { Gear.Second, (20, 50) },
                { Gear.Third, (30, 60) },
                { Gear.Fourth, (40, 90) },
                { Gear.Fifth, (50, 150) },
                { Gear.Neutral, (0, 150) }
            };
        }

        private void SetDirection( int speed )
        {
            // todo:при движении назад направление не должно изменятся
            if ( speed == 0 )
            {
                _direction = Direction.OnPlace;
            }
            else if ( _direction == Direction.Backward || _gear == Gear.Reverse )
            {
                _direction = Direction.Backward;
            }
            else
            {
                _direction = Direction.Forward;
            }
        }
    }
}
