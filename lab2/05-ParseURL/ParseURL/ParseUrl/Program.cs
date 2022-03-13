using ParseUrl;

Console.WriteLine( "Введите url для разбора." );

string urlValue = Console.ReadLine();
Url url = new();
if ( ToolUrl.ParseURL( urlValue, url ) )
{
    Console.WriteLine( urlValue );
    Console.WriteLine( $"HOST: {url.Host}" );
    Console.WriteLine( $"PORT: {url.Port}" );
    Console.WriteLine( $"DOC: {url.Document}" );
}
else
{
    Console.WriteLine( "Ошибка при разборе." );
}
