using ParseUrl;

Console.WriteLine( "Введите url для разбора." );

string urlValue = Console.ReadLine();
Url url = new();
if ( ToolUrl.ParseURL( urlValue, url ) )
{
    Console.WriteLine( "yes" );
}
else
{
    Console.WriteLine( "Ошибка при разборе." );
}
