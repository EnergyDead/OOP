using Calculator;
using Xunit;

namespace CalculatorTests
{
    public class FunctionTests
    {
        [Fact]
        public void Function_CreateFunction_CorrectInput()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable = new( "first", 1 );

            //act
            fn = new( nameFn, variable );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == 1, "Значение равно значению переменной first." );
        }

        [Fact]
        public void Function_CreateFunction_InccorectInput()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable = new( "first" );

            //act
            fn = new( nameFn, variable );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == null, "Значение равно значению переменной first." );
        }

        [Fact]
        public void Function_Plus_CreateFunction_ReturnValue()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first", 1 );
            Variable variable2 = new( "first", 2 );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Plus );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == 3, "Значение равно сумме двух переменных." );
        }

        [Fact]
        public void Function_Plus_SecondLetHasNull_ReturnNull()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first", 1 );
            Variable variable2 = new( "first" );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Plus );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == null, "Значение равно сумме двух переменных." );
        }

        [Fact]
        public void Function_Plus_FirstLetHasNull_ReturnNull()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first" );
            Variable variable2 = new( "first", 1 );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Plus );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == null, "Значение равно сумме двух переменных." );
        }

        [Fact]
        public void Function_Minus_FirstLetHasNull_ReturnNull()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first" );
            Variable variable2 = new( "first", 1 );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Minus );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == null, "Значение равно сумме двух переменных." );
        }

        [Fact]
        public void Function_Minus_ReturnValue()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first", 1 );
            Variable variable2 = new( "first", 1 );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Minus );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == 0, "Значение равно сумме двух переменных." );
        }

        [Fact]
        public void Function_Divide_ReturnValue()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first", 10 );
            Variable variable2 = new( "first", 3 );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Divide );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.Equal( 3.33, fn.GetValue() );
        }

        [Fact]
        public void Function_Multiply_ReturnValue()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first", 1.011 );
            Variable variable2 = new( "first", 3 );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Multiply );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.Equal( 3.03, fn.GetValue() );
        }

        [Fact]
        public void Function_Plus_FirstLetChange_ReturnNull()
        {
            //arrange
            string nameFn = "name";
            Function fn;
            Variable variable1 = new( "first", 3 );
            Variable variable2 = new( "first", 1 );

            variable1.SetValue( 5 );

            //act
            fn = new( nameFn, (variable1, variable2), Operation.Plus );

            //assert
            Assert.True( fn.Name == nameFn, "Имя функции." );
            Assert.True( fn.GetValue() == 6, "Значение равно сумме двух переменных." );
        }
    }
}
