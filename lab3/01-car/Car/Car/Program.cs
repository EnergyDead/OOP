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
var carSimulator = new CarSimulator.CarSimulator( car );

string command = string.Empty;
while ( command != "closed" )
{
    // больше информации об ошибке.
    Console.WriteLine();
    Console.Write( "Введите команду: " );

    string[] arguments = Console.ReadLine().Split( ' ' );
    if ( arguments.Length == 0 )
    {
        continue;
    }

    command = arguments.First().ToLower();

    // todo: перенести в CarSimulator
    switch ( command )
    {
        case "info":
            carSimulator.Info();
            break;
        case "engineon":
            EngineOn();
            break;
        case "engineoff":
            EngineOff();
            break;
        case "setgear":
            SetGear( arguments[ 1 ] );
            break;

        case "setspeed":
            SetSpeed( arguments[ 1 ] );
            break;
        default:
            Console.WriteLine( "Ошибка. Неизвестная команда." );
            break;
    }
}

// todo: перенести в CarSimulator
#region command

void EngineOn()
{
    if ( carSimulator.EngineOn() )
    {
        Console.WriteLine( "Успешно! Автомобиль заведен." );
    }
    else
    {
        Console.WriteLine( "Ошибка. Не удалось завести авто." );
    }
}

void EngineOff()
{
    if ( carSimulator.EngineOff() )
    {
        Console.WriteLine( "Успешно! Автомобиль выключен." );
    }
    else
    {
        Console.WriteLine( "Ошибка. Не удалось заглушить авто." );
    }
}

void SetGear( string newGear )
{
    if ( int.TryParse( newGear, out int value ) && carSimulator.SetGear( value ) )
    {
        Console.WriteLine( $"Успешно! Установлена передача {value}." );
    }
    else
    {
        Console.WriteLine( "Ошибка. Не удалось установить передачу." );
    }
}

void SetSpeed( string newSpeed )
{
    if ( int.TryParse( newSpeed, out int value ) && carSimulator.SetSpeed( value ) )
    {
        Console.WriteLine( $"Успешно! Установлена скорость {value}." );
    }
    else
    {
        Console.WriteLine( "Ошибка.Не удалось установить скорость." );
    }
}

#endregion command