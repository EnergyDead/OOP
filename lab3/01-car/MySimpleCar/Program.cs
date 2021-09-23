using System;
using System.Linq;
using System.Text;

namespace MySimpleCar
{
    public class Program
    {
        static void Main( string[] args )
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string startInfo = "Симулятор машинки.\n";
            const string stepInfo = "Чтобы продолжить введите комманду:\n" +
                " Info - Выводит состояние двигателя автомобиля, направление движения, скорость и передачу\n" +
                " EngineOn - Включает двигатель\n" +
                " EngineOff - Выключает двигатель\n" +
                " SetGear <передача> - Включает заданную передачу. В случае ошибки сообщает о причине невозможности переключения передачи\n" +
                " SetSpeed <скорость> - Устанавливает указанную скорость движения. В случае невозможности изменения скорости сообщает о причине невозможности изменить скорость на указанную.\n";

            string inputText = " ";
            Car car = new Car();
            Console.WriteLine( startInfo );

            while ( inputText != String.Empty )
            {
                Console.WriteLine( stepInfo );

                Console.WriteLine( "Для выхода введите пустую сторку. \n" );
                inputText = Console.ReadLine().ToLower().Trim();

                if ( inputText == "info" )
                {
                    Console.WriteLine( CarInfo( car ) );
                }
                else if ( inputText == "engineon" )
                {
                    Console.WriteLine( EndingInfo( car.EndingOn() ) );
                }
                else if ( inputText == "engineoff" )
                {
                    Console.WriteLine( car.EndingOff() );
                }
                else if ( inputText.Contains( "setgear" ) )
                {
                    if ( GetVelueInInput( inputText, out int value ) )
                    {
                        Console.WriteLine( car.SetGear( value ) );
                    }
                    else
                    {
                        Console.WriteLine( "Неизвестная команда." );
                    }
                }
                else if ( inputText.Contains( "setspeed" ) )
                {
                    if ( GetVelueInInput( inputText, out int value ) )
                    {
                        Console.WriteLine( car.SetSpeed( value ) );
                    }
                    else
                    {
                        Console.WriteLine( "Неизвестная команда." );
                    }
                }
                else
                {
                    Console.WriteLine( "Неизвестная команда." );
                }
            }
        }

        private static bool GetVelueInInput( string comand, out int value )
        {
            string[] commands = comand.Split( ' ' );
            if ( commands.Length == 2 )
            {
                return int.TryParse( commands[ 1 ], out value );
            }

            value = 0;
            return false;
        }

        private static string CarInfo( Car car )
        {
            return "Двигатель " + car.GetEngingInfo() + ". Направление - " + car.DriveDirection() + ". Скорость: " + car.GetSpeed() + ". Передача: " + car.GetGrear();
        }

        private static string EndingInfo( bool result )
        {
            return result ? "Успешно!" : "Ошибка!";
        }
    }
}
