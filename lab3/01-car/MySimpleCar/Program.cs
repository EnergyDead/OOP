using System;
using System.Linq;

namespace MySimpleCar
{
    public class Program
    {
        static void Main( string[] args )
        {
            const string startInfo = "Симулятор машинки.\n";
            const string stepInfo = "Чтобы продолжить введите комманду:\n" +
                " Info - Выводит состояние двигателя автомобиля, направление движения, скорость и передачу\n" +
                " EngineOn - Включает двигатель\n" +
                " EngineOff - Выключает двигатель\n" +
                " SetGear <передача> - Включает заданную передачу. В случае ошибки сообщает о причине невозможности переключения передачи\n" +
                " SetSpeed <скорость> - Устанавливает указанную скорость движения. В случае невозможности изменения скорости сообщает о причине невозможности изменить скорость на указанную.\n";

            string comand = " ";
            Car car = new Car();
            Console.WriteLine( startInfo );

            while ( comand != String.Empty )
            {
                Console.WriteLine( stepInfo );
                comand = Console.ReadLine().ToLower();
                switch ( comand )
                {
                    case "Info":
                        Console.WriteLine( CarInfo( car ) );
                        break;
                    case "EngineOn":
                        Console.WriteLine( EndingInfo( car.EndingOn() ) );
                        break;
                    case "EngineOff":
                        Console.WriteLine( EndingInfo( car.EndingOn() ) );
                        break;
                    default:
                        break;
                }
                
                if ( comand.Contains( "SetGear" ) )
                {
                    string[] commands = comand.Split( ' ' );
                    if (commands.Length >= 1 )
                    {
                        car.SetGear( Convert.ToInt32(commands[ 1 ]) );
                    }
                }

               if ( comand.Contains( "SetSpeed" ) )
                {
                    string[] commands = comand.Split( ' ' );
                    if ( commands.Length >= 1 )
                    {
                        car.SetSpeed( Convert.ToInt32( commands[ 1 ] ) );
                    }
                }
            }
        }

        private static string CarInfo( Car car )
        {
            return "Двигатель " + car.GetEngingInfo() + ". Направление - " + car.DirectionOfTravel() + ". Скорость: " + car.GetSpeed() + ". Передача: " + car.GetGrear();
        }

        private static string EndingInfo( bool result )
        {
            return result ? "Успешно!" : "Ошибка!";
        }
    }
}
