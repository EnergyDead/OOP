using Calculator;

Console.WriteLine( "Првиет, это умный калькулятор!" );
Console.WriteLine( "Чтобы создать переменную введи var (название переменной)." );
Console.WriteLine( "Или let (название переменной)=(значение/название уже сущестующей переменной)." );
Console.WriteLine( "Чтобы создать функцию введи fn (название функцию)=(название уже сущестующей переменной)." );
Console.WriteLine( "или fn (название функцию)=(название уже сущестующей переменной)(операцию)(название уже сущестующей переменной)." );
Console.WriteLine( "Список доступных операции: + - / *" );
Console.WriteLine( "Чтобы выйти введи end." );

ICalculator calc = new Calculator.Calculator();

string command = string.Empty;
while ( command != "end" )
{
    command = Console.ReadLine();
    if ( command == "printvars" )
    {
        var res = calc.PrintVars();
        Console.WriteLine( res );
    }
    else if ( command == "printfns" ) 
    {
        var res = calc.PrintFns();
        Console.WriteLine( res );
    }
    else if ( command.Contains( "print" ) )
    {
        var res = calc.Print( command );
        Console.WriteLine( res );
    }
    else
    {
        if ( calc.CreateOrChangeArgument( command ) )
        {
            Console.WriteLine( "Успешно." );
        }
        else
        {
            Console.WriteLine( "Ошибка." );
        }
    }
}
