using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBody
{
    public class Program
    {
        private static readonly List<string> figuresType = new List<string> { "конус", "паралеллепипед", "сфера", "цилиндр", "составное" };
        private static List<Body> figures = new List<Body>();

        public static void Main( string[] args )
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine( "Создавай объемные тела!\n" );
            string command = "strat";

            while (command != String.Empty)
            {
                Console.WriteLine( "Введи тип создаваемого тела\n" );
                Console.WriteLine( String.Join( ", ", figuresType ) );

                command = Console.ReadLine().Trim();

                if (command == String.Empty)
                {
                    Console.WriteLine( "Закрытие.." );

                    continue;
                }

                if (!figuresType.Contains( command.ToLower() ))
                {
                    Console.WriteLine( "Такого типа нет\n" );

                    continue;
                }

                if (CreateFigure( command ))
                {
                    Console.WriteLine( "Успешно создан:\n" + figures[ figures.Count - 1 ].ToString() + "\n" );
                }
            }

            Console.WriteLine( String.Join( "\n", figures.Select( f => f.ToString() ) ) );
        }

        private static bool CreateFigure( string figure )
        {
            if (figure == figuresType[ 0 ])
            {
                Console.WriteLine( "Введите высоту, радиус и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 3)
                {
                    var cone = new Cone( bodyArgs[ 0 ], bodyArgs[ 1 ], bodyArgs[ 2 ] );
                    figures.Add( cone );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У конуса 3 аргумента.\n" );
                }

            }
            else if (figure == figuresType[ 1 ])
            {
                Console.WriteLine( "Введите высоту, длинну, ширину и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 4)
                {
                    var parallelepiped = new Parallelepiped( bodyArgs[ 0 ], bodyArgs[ 1 ], bodyArgs[ 2 ], bodyArgs[ 3 ] );
                    figures.Add( parallelepiped );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У паралелепипеда 4 аргумента.\n" );
                }

            }
            else if (figure == figuresType[ 2 ])
            {
                Console.WriteLine( "Введите радиуc и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 2)
                {
                    var sphere = new Sphere( bodyArgs[ 0 ], bodyArgs[ 1 ] );
                    figures.Add( sphere );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У Сферы 2 аргумента.\n" );
                }
            }
            else if (figure == figuresType[ 3 ])
            {
                Console.WriteLine( "Введите  высоту, радиус и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 3)
                {
                    var cylinder = new Cylinder( bodyArgs[ 0 ], bodyArgs[ 1 ], bodyArgs[ 2 ] );
                    figures.Add( cylinder );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У Цилиндра 3 аргумента.\n" );
                }
            }
            else if (figure == figuresType[ 4 ])
            {
                var compound = new Compound();
                while (true)
                {
                    Console.WriteLine( "Введи тип создаваемого тела в составном теле\n" );
                    Console.WriteLine( "Чтобы перестать добавлять тела в составное тело введите пустую строку\n" );
                    Console.WriteLine( String.Join( ", ", figuresType ) );
                    var command = Console.ReadLine().Trim();

                    if (command == String.Empty)
                    {
                        figures.Add( compound );
                        return true;
                    }

                    if (!figuresType.Contains( command.ToLower() ))
                    {
                        Console.WriteLine( "Такого типа нет\n" );

                    }

                    if (AddFigureInCompound( command, compound ))
                    {
                        Console.WriteLine( "Успешно создан:\n" + compound.ToString() + "\n" );
                    }
                }
            }

            return false;
        }

        private static bool AddFigureInCompound( string figure, Compound compound )
        {
            if (figure == figuresType[ 0 ])
            {
                Console.WriteLine( "Введите высоту, радиус и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 3)
                {
                    var cone = new Cone( bodyArgs[ 0 ], bodyArgs[ 1 ], bodyArgs[ 2 ] );
                    compound.AddChildBody( cone );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У конуса 3 аргумента.\n" );
                }

            }
            else if (figure == figuresType[ 1 ])
            {
                Console.WriteLine( "Введите высоту, длинну, ширину и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 4)
                {
                    var parallelepiped = new Parallelepiped( bodyArgs[ 0 ], bodyArgs[ 1 ], bodyArgs[ 2 ], bodyArgs[ 3 ] );
                    compound.AddChildBody( parallelepiped );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У паралелепипеда 4 аргумента.\n" );
                }

            }
            else if (figure == figuresType[ 2 ])
            {
                Console.WriteLine( "Введите радиуc и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 2)
                {
                    var sphere = new Sphere( bodyArgs[ 0 ], bodyArgs[ 1 ] );
                    compound.AddChildBody( sphere );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У Сферы 2 аргумента.\n" );
                }
            }
            else if (figure == figuresType[ 3 ])
            {
                Console.WriteLine( "Введите  высоту, радиус и плотность через пробел\n" );
                List<int> bodyArgs = ConvertArgs();

                if (bodyArgs.Count == 3)
                {
                    var cylinder = new Cylinder( bodyArgs[ 0 ], bodyArgs[ 1 ], bodyArgs[ 2 ] );
                    compound.AddChildBody( cylinder );

                    return true;
                }
                else
                {
                    Console.WriteLine( "Ошибка! У Цилиндра 3 аргумента.\n" );
                }
            }
            else if (figure == figuresType[ 4 ])
            {
                Compound compound1 = new Compound();
                while (true)
                {
                    Console.WriteLine( "Введи тип создаваемого тела в составном теле\n" );
                    Console.WriteLine( "Чтобы перестать добавлять тела в составное тело введите пустую строку\n" );
                    Console.WriteLine( String.Join( ", ", figuresType ) );
                    var command = Console.ReadLine().Trim();

                    if (command == String.Empty)
                    {
                        compound.AddChildBody( compound1 );
                        return true;
                    }

                    if (!figuresType.Contains( command.ToLower() ))
                    {
                        Console.WriteLine( "Такого типа нет\n" );

                    }

                    if (AddFigureInCompound( command, compound1 ))
                    {
                        Console.WriteLine( "Успешно создан:\n" + compound.ToString() + "\n" );
                    }
                }
            }

            return false;
        }

        private static List<int> ConvertArgs()
        {
            string inpConeArgs = Console.ReadLine();
            var bodyArgs = new List<int>();

            foreach (var arg in inpConeArgs.Split( " " ))
            {
                if (Int32.TryParse( arg, out int convetArg ))
                {
                    bodyArgs.Add( convetArg );
                }
                else
                {
                    Console.WriteLine( $"Непрваильный аргумент {arg}\n" );
                }
            }

            return bodyArgs;
        }
    }
}
