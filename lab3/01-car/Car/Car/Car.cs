namespace CarSimulator
{
    public class Car
    {
        private readonly int _maxReverseSpeed = 20;
        private readonly int _minReverseSpeed = 0;
        private readonly int _maxFirstSpeed = 30;
        private readonly int _minFirstSpeed = 0;
        private readonly int _maxSecondSpeed = 50;
        private readonly int _minSecondSpeed = 20;
        private readonly int _maxThirdSpeed = 60;
        private readonly int _minThirdSpeed = 30;
        private readonly int _maxFourthSpeed = 90;
        private readonly int _minFourthSpeed = 40;
        private readonly int _maxFifthSpeed = 150;
        private readonly int _minFifthSpeed = 50;

        private int _speed;
        private bool _isEngineRunning;
        private Gear _gear;
        private Direction _direction;

        public int Speed { get { return _speed; } }
        public bool IsEngineRunning { get { return _isEngineRunning; } }
        public Gear Gear { get { return _gear; } }
        public Direction Direction { get { return _direction; } }

        public Car()
        {
            _speed = 0;
            _isEngineRunning = false;
            _gear = Gear.Neutral;
            _direction = Direction.OnPlace;
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

            if ( _direction == Direction.Backward )
            {
                return false;
            }

            if ( (Gear)gear == Gear.First )
            {
                if ( _speed >= _minFirstSpeed && _speed <= _maxFirstSpeed )
                {
                    _gear = Gear.First;

                    return true;
                }
            }

            if ( (Gear)gear == Gear.Second )
            {
                if ( _speed >= _minSecondSpeed && _speed <= _maxSecondSpeed )
                {
                    _gear = Gear.Second;

                    return true;
                }
            }

            if ( (Gear)gear == Gear.Third )
            {
                if ( _speed >= _minThirdSpeed && _speed <= _maxThirdSpeed )
                {
                    _gear = Gear.Third;

                    return true;
                }
            }

            if ( (Gear)gear == Gear.Fourth )
            {
                if ( _speed >= _minFourthSpeed && _speed <= _maxFourthSpeed )
                {
                    _gear = Gear.Fourth;

                    return true;
                }
            }

            if ( (Gear)gear == Gear.Fifth )
            {
                if ( _speed >= _minFifthSpeed && _speed <= _maxFifthSpeed )
                {
                    _gear = Gear.Fifth;

                    return true;
                }
            }

            if ( (Gear)gear == Gear.Reverse )
            {
                if ( _direction == Direction.OnPlace )
                {
                    _gear = Gear.Reverse;

                    return true;
                }
            }

            return false;
        }

        public bool SetSpeed( int speed )
        {
            if ( _gear == Gear.Neutral )
            {
                if ( speed < 0 || speed >= _speed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            if ( _gear == Gear.Reverse && _direction != Direction.Forward )
            {
                if ( speed < _minReverseSpeed || speed > _maxReverseSpeed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            if ( _gear == Gear.First && _direction != Direction.Backward )
            {
                if ( speed < _minFirstSpeed || speed > _maxFirstSpeed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            if ( _gear == Gear.First && _direction != Direction.Backward )
            {
                if ( speed < _minFirstSpeed || speed > _maxFirstSpeed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            if ( _gear == Gear.Second && _direction != Direction.Backward )
            {
                if ( speed < _minSecondSpeed || speed > _maxSecondSpeed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            if ( _gear == Gear.Third && _direction != Direction.Backward )
            {
                if ( speed < _minThirdSpeed || speed > _maxThirdSpeed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            if ( _gear == Gear.Fourth && _direction != Direction.Backward )
            {
                if ( speed < _minFourthSpeed || speed > _maxFourthSpeed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            if ( _gear == Gear.Fifth && _direction != Direction.Backward )
            {
                if ( speed < _minFifthSpeed || speed > _maxFifthSpeed )
                {
                    return false;
                }

                _speed = speed;

                SetDirection( speed );
                return true;
            }

            return false;
        }

        private void SetDirection( int speed )
        {
            if ( speed == 0 )
            {
                _direction = Direction.OnPlace;
                return;
            }

            if ( _gear == Gear.Reverse )
            {
                _direction = Direction.Backward;
                return;
            }

            _direction = Direction.Forward;
        }
    }
}
