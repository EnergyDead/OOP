using System;

namespace MySimpleCar
{
    public class Program
    {
        static void Main( string[] args )
        {
            Car car = new Car();
            car.EndingOn();
            car.SetGear( 1 );
            car.SetSpeed( 10 );
            Console.WriteLine( car.Info() );
        }
    }
}
