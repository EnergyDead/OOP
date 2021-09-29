using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBody
{
    public class Program
    {
        private static readonly List<string> figuresType = new List<string> { "конус", "паралеллепипед", "cфера", "цилиндр" };
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
                command = Console.ReadLine().Trim();

                if (!figuresType.Contains( command.ToLower() ))
                {
                    Console.WriteLine( "Такого типа нет\n" );

                    continue;
                }

                Console.WriteLine( $"Введи характеристики {command}\n" );
                Console.WriteLine( FigureOptions( command ) + "\n" );
                var info = String.Join( "\n", figures.Select( f => f.ToString() ) );
                Console.WriteLine( figures.Select( f => f.ToString() ) );
                Console.WriteLine( info );
            }
        }

        private static string FigureOptions( string figure )
        {
            figure = figure.ToLower();
            if (figure == figuresType[ 0 ])
            {
                Cone cone = new Cone( 1, 1, 1 );
                figures.Add( cone );
                return "Введите высоту, радиус и плотность через пробел\n";
                
            }
            if (figure == figuresType[ 1 ])
            {
                Parallelepiped cone = new Parallelepiped( 1, 1, 1, 1 );
                figures.Add( cone );
                return "Введите высоту, длиннуб ширину и плотность через пробел\n"; 
                
            }
            if (figure == figuresType[ 2 ])
            {
                return "Введите радиу и плотность через пробел\n";
            }
            if (figure == figuresType[ 3 ])
            {
                return "Введите .. и плотность через пробел\n";
            }

            return "Какая-то ошибка";
        }
    }
}
