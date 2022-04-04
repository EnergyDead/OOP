using ThreeDimensionalBody;

Console.WriteLine( "Симулятор обьемных тел." );
Console.WriteLine( "1 - Сфера," );
Console.WriteLine( "2 - Параллелепипед," );
Console.WriteLine( "3 - Конус," );
Console.WriteLine( "4 - Цилиндор," );
Console.WriteLine( "5 - Составное тело," );
Console.WriteLine( "9 - Закончить ввод тел." );
Console.WriteLine( "0 - Выход или пустая строка." );

var command = -1;
List<Body> _bodies = new();

while ( command != 0 )
{
    Console.WriteLine( "Выберите какое тело хотите создать:" );
    int.TryParse( Console.ReadLine(), out command );
    Body? body;
    switch ( command )
    {
        case 1:
            body = BodyController.TryCreateSphere();
            if ( body != null ) _bodies.Add( body );
            break;
        case 2:
            body = BodyController.TryCreateParallelepiped();
            if ( body != null ) _bodies.Add( body );
            break;
        case 3:
            body = BodyController.TryCreateCone();
            if ( body != null ) _bodies.Add( body );
            break;
        case 4:
            body = BodyController.TryCreateCylinder();
            if ( body != null ) _bodies.Add( body );
            break;
        case 5:
            body = BodyController.TryCreateCompound();
            if ( body != null ) _bodies.Add( body );
            break;
        case 0 or 9:
            command = 0;
            break;
        default:
            Console.WriteLine( "Неизвестная комманда." );
            break;
    }
}

BodyController.Print( _bodies );