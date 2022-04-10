namespace ThreeDimensionalBody;

internal static class BodyController
{
    public static Sphere? TryCreateSphere()
    {
        try
        {
            Console.Write( "Введите радиус сферы:" );
            var radius = double.Parse( Console.ReadLine() );

            Console.Write( "Введите плотность сферы:" );
            var density = double.Parse( Console.ReadLine() );

            return new Sphere( radius, density );
        }
        // todo: сделать несколько catch
        catch ( Exception ex )
        {
            if ( ex is not ArgumentOutOfRangeException )
            {
                Console.WriteLine( "Некорректное значение." );
            }
            Console.WriteLine( "Ошибка при создании Сферы." );
            return null;
        }
    }

    public static Parallelepiped? TryCreateParallelepiped()
    {
        try
        {
            Console.Write( "Введите ширину Параллелепипеда:" );
            var width = double.Parse( Console.ReadLine() );

            Console.Write( "Введите высоту Параллелепипеда:" );
            var heigth = double.Parse( Console.ReadLine() );

            Console.Write( "Введите глубину Параллелепипеда:" );
            var depth = double.Parse( Console.ReadLine() );

            Console.Write( "Введите плотность Параллелепипеда:" );
            var density = double.Parse( Console.ReadLine() );

            return new Parallelepiped( width, heigth, depth, density );
        }
        catch ( Exception ex )
        {
            if ( ex is not ArgumentOutOfRangeException )
            {
                Console.WriteLine( "Некорректное значение." );
            }
            Console.WriteLine( "Ошибка при создании Параллелепипеда." );
            return null;
        }
    }

    public static Cone? TryCreateCone()
    {
        try
        {
            Console.Write( "Введите базоый радиус конуса:" );
            var baseRadius = double.Parse( Console.ReadLine() );

            Console.Write( "Введите высоту конуса:" );
            var heigth = double.Parse( Console.ReadLine() );

            Console.Write( "Введите плотность конуса:" );
            var density = double.Parse( Console.ReadLine() );

            return new Cone( baseRadius, heigth, density );
        }
        catch ( Exception ex )
        {
            if ( ex is not ArgumentOutOfRangeException )
            {
                Console.WriteLine( "Некорректное значение." );
            }
            Console.WriteLine( "Ошибка при создании Конуса." );
            return null;
        }
    }

    public static Cylinder? TryCreateCylinder()
    {
        try
        {
            Console.Write( "Введите базоый радиус цилиндра:" );
            var baseRadius = double.Parse( Console.ReadLine() );

            Console.Write( "Введите высоту цилиндра:" );
            var heigth = double.Parse( Console.ReadLine() );

            Console.Write( "Введите плотность цилиндра:" );
            var density = double.Parse( Console.ReadLine() );

            return new Cylinder( baseRadius, heigth, density );
        }
        catch ( Exception ex )
        {
            if ( ex is not ArgumentOutOfRangeException )
            {
                Console.WriteLine( "Некорректное значение." );
            }
            Console.WriteLine( "Ошибка при создании Цилиндра." );
            return null;
        }
    }

    public static Compound? TryCreateCompound()
    {
        try
        {
            Compound compound = new();

            var command = -1;
            while ( command != 0 )
            {
                Console.WriteLine( "Выберите какое тело хотите добавить:" );
                Console.WriteLine( "9 - для остановки добавления тел." );
                if ( !int.TryParse( Console.ReadLine(), out command ) )
                {
                    Console.WriteLine( "Неизвестная комманда." );
                    continue;
                }
                Body? body = null;
                switch ( command )
                {
                    case 1:
                        body = TryCreateSphere();
                        if ( body != null ) compound.AddChildBody( body );
                        break;
                    case 2:
                        body = TryCreateParallelepiped();
                        if ( body != null ) compound.AddChildBody( body );
                        break;
                    case 3:
                        body = TryCreateCone();
                        if ( body != null ) compound.AddChildBody( body );
                        break;
                    case 4:
                        body = TryCreateCylinder();
                        if ( body != null ) compound.AddChildBody( body );
                        break;
                    case 5:
                        body = TryCreateCompound();
                        if ( body != null ) compound.AddChildBody( body );
                        break;
                    case 9:
                        command = 0;
                        break;
                    default:
                        Console.WriteLine( "Неизвестная комманда." );
                        break;
                }
            }
            return compound;
        }
        catch ( Exception ex )
        {
            if ( ex is not ArgumentOutOfRangeException )
            {
                Console.WriteLine( "Некорректное значение." );
            }
            Console.WriteLine( "Ошибка при создании Цилиндра." );
            return null;
        }
    }

    public static void Print( List<Body> bodies )
    {
        foreach ( var item in bodies )
        {
            Console.WriteLine( item.ToString() );
            Console.WriteLine();
        }
        PrintMaxMass( bodies );
        PrintMinInWhater( bodies );
    }

    static void PrintMaxMass( List<Body> bodies )
    {
        Console.WriteLine( "Тело с наибольшей массой:" );
        Console.WriteLine( bodies.MaxBy( b => b.GetMass() ) );
    }

    static void PrintMinInWhater( List<Body> bodies )
    {
        Console.WriteLine( "Тело которое будет легче всего весить, будучи полностью погруженным в воду:" );
        Console.WriteLine( bodies.MinBy( b => CalculateMassInWater( b ) ) );

    }

    static double CalculateMassInWater( Body body )
    {
        const double g = 9.81;
        const int waterDensity = 1000;

        return ( body.GetDensity() - waterDensity ) * g * body.GetVolume();
    }
}


