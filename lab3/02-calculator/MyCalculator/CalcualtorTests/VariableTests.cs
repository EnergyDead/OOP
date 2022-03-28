using Calculator;
using Xunit;

namespace CalcualtorTests
{
    public class VariableTests
    {
        [Fact]
        public void Variable_CreateVar()
        {
            //arrange
            string varName = "Year";
            Variable var;

            //act
            var = new( varName );

            //assert
            Assert.True( var.Name == varName, "Название переменной" );
            Assert.True( var.GetValue() == null, "Т.к. не обьявлено значение, оно равно null." );
            Assert.True( var.ToString() == "null", "Т.к. не обьявлено значение, оно равно null." );
        }

        [Fact]
        public void Variable_CreateLet()
        {
            //arrange
            string letName = "Year";
            double value = 2022;
            Variable let;

            //act
            let = new( letName, value );

            //assert
            Assert.True( let.Name == letName, "Название переменной" );
            Assert.True( let.GetValue() == value, "Т.к. обьявлено значение, оно равно обьявленному." );
            Assert.Equal( "2022", let.ToString() );
        }

        [Fact]
        public void Variable_ChangeLet()
        {
            //arrange
            string letName = "Year";
            double value = 2022;
            Variable let = new( letName, 2001 );

            //act
            let.SetValue( 2022 );

            //assert
            Assert.True( let.Name == letName, "Название переменной" );
            Assert.True( let.GetValue() == value, "Т.к. обьявлено значение, оно равно обьявленному." );
            Assert.Equal( "2022", let.ToString() );
        }

        [Fact]
        public void Variable_LetPlusLet()
        {
            //arrange
            var ansewer = 22;
            Variable firstLet = new( "first", 11 );
            Variable secondLet = new( "second", 11 );

            //act
            var result = firstLet + secondLet;

            //assert
            Assert.Equal( ansewer, result );
        }

        [Fact]
        public void Variable_LetMinusLet()
        {
            //arrange
            var ansewer = 0;
            Variable firstLet = new( "first", 11 );
            Variable secondLet = new( "second", 11 );

            //act
            var result = firstLet - secondLet;

            //assert
            Assert.Equal( ansewer, result );
        }

        [Fact]
        public void Variable_LetDivideLet()
        {
            //arrange
            var ansewer = 1;
            Variable firstLet = new( "first", 11 );
            Variable secondLet = new( "second", 11 );

            //act
            var result = firstLet / secondLet;

            //assert
            Assert.Equal( ansewer, result );
        }

        [Fact]
        public void Variable_LetMultiplyLet()
        {
            //arrange
            var ansewer = 121;
            Variable firstLet = new( "first", 11 );
            Variable secondLet = new( "second", 11 );

            //act
            var result = firstLet * secondLet;

            //assert
            Assert.Equal( ansewer, result );
        }
    }
}