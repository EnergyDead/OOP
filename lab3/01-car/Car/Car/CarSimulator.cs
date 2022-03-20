using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class CarSimulator : ICarSimulator
    {
        private readonly Car _car;

        public CarSimulator( Car car )
        {
            _car = car;
        }
        public bool EngineOff()
        {
            return _car.TurnOffEngine();
        }

        public bool EngineOn()
        {
            return _car.TurnOnEngine();
        }

        public void Info()
        {
            // todo: сделать по нормальному
            Console.WriteLine( "Информация о машине." );
            Console.WriteLine( $"Состояние двигателя: {_car.IsEngineRunning}" );
            Console.WriteLine( $"Направление движения: {_car.Direction}" );
            Console.WriteLine( $"Скорость: {_car.Speed}" );
            Console.WriteLine( $"Передача: {_car.Gear}" );
        }

        public bool SetGear( int gear )
        {
            return _car.SetGear( gear );
        }

        public bool SetSpeed( int speed )
        {
            return _car.SetSpeed( speed );
        }
    }
}
