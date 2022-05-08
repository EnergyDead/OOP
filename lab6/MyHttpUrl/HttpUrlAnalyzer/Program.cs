using MyHttpUrl;

Console.WriteLine( "Привет! Это анализатор Url." );
Console.WriteLine( "Чтобы выйти введите пустую строку." );

string command;
do
{
    Console.Write( "Введите url: " );
    command = Console.ReadLine();
    if ( string.IsNullOrEmpty( command ) ) return;
    try
    {
        HttpUrl url = new( command );
        Console.WriteLine( $"Введенный url: {url}" );
        Console.WriteLine( $"Протокол: {url.Protocol}" );
        Console.WriteLine( $"Домейн: {url.Domain}" );
        Console.WriteLine( $"Порт: {url.Port}" );
        Console.WriteLine( $"Документ: {url.Document}" );
    }
    catch ( Exception err )
    {
        Console.WriteLine( err.Message );
    }
} while ( true );
