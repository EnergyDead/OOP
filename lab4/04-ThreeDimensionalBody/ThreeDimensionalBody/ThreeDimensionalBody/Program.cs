using ThreeDimensionalBody;

const int Exit = 9;

Console.WriteLine( "Симулятор обьемных тел." );
Console.WriteLine( "1 - Сфера," );
Console.WriteLine( "2 - Параллелепипед," );
Console.WriteLine( "3 - Конус," );
Console.WriteLine( "4 - Цилиндор," );
Console.WriteLine( "5 - Составное тело," );
Console.WriteLine( "9 - Выход." );

List<Body> _bodies = new();

int command = 0;
while ( command != Exit )
{
    Console.WriteLine( "Выберите какое тело хотите создать:" );
    if ( !int.TryParse( Console.ReadLine(), out command ) )
    {
        Console.WriteLine( "Неизвестная комманда." );
        continue;
    }
    if ( BodyController.TryAddBody( _bodies, BodyController.CreateBody( command ) ) )
    {
        Console.WriteLine( "Успешно!." );
    }
}

BodyController.Print( _bodies );