namespace ThreeDimensionalBody;

internal class BodyCreater
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
        catch ( Exception ex ) when ( ex is ArgumentNullException ||
                                      ex is FormatException ||
                                      ex is OverflowException )
        {
            Console.WriteLine( "Некорректное значение." );
            return null;
        }
        catch ( ArgumentOutOfRangeException )
        {
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
        catch ( Exception ex ) when ( ex is ArgumentNullException ||
                                      ex is FormatException ||
                                      ex is OverflowException )
        {
            Console.WriteLine( "Некорректное значение." );
            return null;
        }
        catch ( ArgumentOutOfRangeException )
        {
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
        catch ( Exception ex ) when ( ex is ArgumentNullException ||
                                      ex is FormatException ||
                                      ex is OverflowException )
        {
            Console.WriteLine( "Некорректное значение." );
            return null;
        }
        catch ( ArgumentOutOfRangeException )
        {
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
        catch ( Exception ex ) when ( ex is ArgumentNullException ||
                                      ex is FormatException ||
                                      ex is OverflowException )
        {
            Console.WriteLine( "Некорректное значение." );
            return null;
        }
        catch ( ArgumentOutOfRangeException )
        {
            Console.WriteLine( "Ошибка при создании Цилиндра." );
            return null;
        }
    }

    public static Compound? TryCreateCompound()
    {
        int exitCommand = 9;
        try
        {
            Compound compound = new();

            var command = -1;
            while ( command != exitCommand )
            {
                Console.WriteLine( "Выберите какое тело хотите добавить:" );
                Console.WriteLine( "9 - для остановки добавления тел." );
                if ( !int.TryParse( Console.ReadLine(), out command ) )
                {
                    Console.WriteLine( "Неизвестная комманда." );
                    continue;
                }
                Body? body = BodyController.CreateBody( command );
                if ( body != null ) compound.AddChildBody( body );
            }
            return compound;
        }
        catch ( Exception ex ) when ( ex is ArgumentNullException ||
                                      ex is FormatException ||
                                      ex is OverflowException )
        {
            Console.WriteLine( "Некорректное значение." );
            return null;
        }
        catch ( ArgumentOutOfRangeException )
        {
            Console.WriteLine( "Ошибка при создании Составного тела." );
            return null;
        }
    }
}
