namespace ThreeDimensionalBody;

internal static class BodyController
{
    public static Body? CreateBody( int command )
    {
        Body? body = null;
        switch ( (Command) command )
        {
            case Command.CreateSphere:
                body = BodyCreater.TryCreateSphere();
                break;
            case Command.CreateParallelepiped:
                body = BodyCreater.TryCreateParallelepiped();
                break;
            case Command.CreateCone:
                body = BodyCreater.TryCreateCone();
                break;
            case Command.CreateCylinder:
                body = BodyCreater.TryCreateCylinder();
                break;
            case Command.CreateCompound:
                body = BodyCreater.TryCreateCompound();
                break;
            case Command.Exit:
                break;
            default:
                Console.WriteLine( "Неизвестная комманда." );
                break;
        }
        return body;
    }

    public static bool TryAddBody( List<Body> bodies, Body? body )
    {
        if ( body == null )
        {
            return false;
        }
        bodies.Add( body );
        return true;
    }

    public static void Print( List<Body> bodies )
    {
        if ( !bodies.Any() )
        {
            Console.WriteLine( "Нет тел." );
            return;
        }

        foreach ( var item in bodies )
        {
            Console.WriteLine( item.ToString() );
            Console.WriteLine();
        }
        PrintMaxMass( bodies );
        Console.WriteLine();
        PrintMinInWhater( bodies );
    }

    enum Command : int
    {
        unknown,
        CreateSphere,
        CreateParallelepiped,
        CreateCone,
        CreateCylinder,
        CreateCompound,
        Exit = 9
    }

    #region Print
    private static void PrintMaxMass( List<Body> bodies )
    {
        Console.WriteLine( "Тело с наибольшей массой:" );
        Console.WriteLine( bodies.MaxBy( b => b.GetMass() ) );
    }

    private static void PrintMinInWhater( List<Body> bodies )
    {
        Console.WriteLine( "Тело которое будет легче всего весить, будучи полностью погруженным в воду:" );
        Console.WriteLine( bodies.MinBy( b => CalculateMassInWater( b ) ) );

    }

    private static double CalculateMassInWater( Body body )
    {
        const double g = 9.81;
        const int waterDensity = 1000;

        return ( body.GetDensity() - waterDensity ) * g * body.GetVolume();
    }
    #endregion
}