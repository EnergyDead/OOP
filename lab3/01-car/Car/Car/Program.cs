using CarSimulator;

Console.WriteLine( "Привет! Это симулятор автомобиля!" );
Console.WriteLine( "Выбери команду:" );
Console.WriteLine( "Info. Выводит состояние двигателя автомобиля, направление движения, скорость и передачу." );
Console.WriteLine( "EngineOn. Включает двигатель." );
Console.WriteLine( "EngineOff. Выключает двигатель." );
Console.WriteLine( "SetGear передача. Включает заданную передачу, заданную числом от -1 до 5. В случае ошибки сообщает о причине невозможности переключения передачи." );
Console.WriteLine( "SetSpeed скорость. Устанавливает указанную скорость движения, заданную неотрицательным числом. В случае невозможности изменения скорости сообщает о причине невозможности изменить скорость на указанную." );
Console.WriteLine( "Closed для выхода." );

Car car = new();
ICarSimulator carSimulator = new CarSimulator.CarSimulator( car );

string command = string.Empty;
while ( command != "closed" )
{
    Console.WriteLine();
    Console.Write( "Введите команду: " );

    string[] arguments = Console.ReadLine().Split( ' ' );
    if ( arguments.Length == 0 )
    {
        continue;
    }

    command = arguments.First().ToLower();

    if ( command == "info" )
    {
        carSimulator.Info();
    }

    if ( command == "engineon" )
    {
        if ( carSimulator.EngineOn() )
        {
            Console.WriteLine( "Успешно! Автомобиль заведен." );
            continue;
        }
        Console.WriteLine( "Ошибка." );
    }

    if ( command == "engineoff" )
    {
        if ( carSimulator.EngineOff() )
        {
            Console.WriteLine( "Успешно! Автомобиль выключен." );
            continue;
        }
        Console.WriteLine( "Ошибка." );
    }

    if ( command == "setgear" )
    {
        if ( int.TryParse( arguments[ 1 ], out int value ) )
        {
            if ( carSimulator.SetGear( value ) )
            {
                Console.WriteLine( $"Успешно! Установлена передача {value}." );
                continue;
            }
        }
        Console.WriteLine( "Ошибка." );
    }

    if ( command == "setspeed" )
    {
        if ( int.TryParse( arguments[ 1 ], out int value ) )
        {
            if ( carSimulator.SetSpeed( value ) )
            {
                Console.WriteLine( $"Успешно! Установлена скорость {value}." );
                continue;
            }
        }
        Console.WriteLine( "Ошибка." );
    }
}