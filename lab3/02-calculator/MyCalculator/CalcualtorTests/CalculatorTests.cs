using Calculator;
using Xunit;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Fact]
        public void ICalculator_CreateVarAndPrint_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string commandCreateVar = "var radius";
            //act
            var result = calc.CreateOrChangeArgument( commandCreateVar );
            var printResult = calc.Print( "print radius" );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "null", printResult );
        }

        [Fact]
        public void Calculator_CreateVar_Incorrect()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            //act
            var printResult = calc.Print( "print radius" );

            //assert
            Assert.Equal( "Неизвестная перемерная", printResult );
        }

        [Fact]
        public void Calculator_CreateLetWithValue_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string commandCreateLet = "let radius=1";
            string letName = "radius";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateLet );
            var printResult = calc.Print( $"print {letName}" );

            //assert
            Assert.True( result, "Успешно создалась переменная." );
            Assert.Equal( "1", printResult );
        }

        [Fact]
        public void Calculator_CreateVarWithAlreadyUsedName_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameVar = "radius";
            string commandCreateVar = $"var {nameVar}";
            calc.CreateOrChangeArgument( commandCreateVar );

            //act
            var result = calc.CreateOrChangeArgument( commandCreateVar );
            var printResult = calc.Print( $"print {nameVar}" );

            //assert
            Assert.False( result, "Имя уже используется." );
            Assert.Equal( "null", printResult );
        }

        [Fact]
        public void Calculator_CreateLetWithAlreadyUsedName_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameVar = "radius";
            string commandCreateVar = $"let {nameVar}";
            calc.CreateOrChangeArgument( commandCreateVar );

            //act
            var result = calc.CreateOrChangeArgument( commandCreateVar );
            var printResult = calc.Print( $"print {nameVar}" );

            //assert
            Assert.False( result, "Имя уже используется." );
            Assert.Equal( "null", printResult );
        }

        [Fact]
        public void Calculator_CreateFn_ReturnFalse()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameFn = "NewFn";
            string commandCreateFn = $"fn {nameFn}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateFn );

            //assert
            Assert.False( result, "Функция не может быть пустой." );
        }

        [Fact]
        public void Calculator_CreateFnWithValue_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameVar = "radius";
            string commandCreateVar = $"let {nameVar}";
            calc.CreateOrChangeArgument( commandCreateVar );
            string nameFn = "newFn";
            string commandCreateFn = $"fn {nameFn}={nameVar}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateFn );
            var resultFnName = calc.Print( $"print {nameFn}" );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "null", resultFnName );
        }

        [Fact]
        public void Calculator_CreateFnWithTwoLet_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string nameLet2 = "second";
            string commandCreateLet1 = $"let {nameLet1}=1";
            string commandCreateLet2 = $"let {nameLet2}=1";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            calc.CreateOrChangeArgument( commandCreateLet2 );
            string nameFn = "newFn";
            string commandCreateFn = $"fn {nameFn}={nameLet1}+{nameLet2}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateFn );
            var resultFnName = calc.Print( $"print {nameFn}" );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "2", resultFnName );
        }

        [Fact]
        public void Calculator_CreateFnWithTwoLetWithOneHasNull_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string nameLet2 = "second";
            string commandCreateLet1 = $"let {nameLet1}=1";
            string commandCreateLet2 = $"var {nameLet2}";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            calc.CreateOrChangeArgument( commandCreateLet2 );
            string nameFn = "newFn";
            string commandCreateFn = $"fn {nameFn}={nameLet1}+{nameLet2}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateFn );
            var resultFnName = calc.Print( $"print {nameFn}" );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "null", resultFnName );
        }

        [Fact]
        public void Calculator_CreateFnWithTwoLetHasNull_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string nameLet2 = "second";
            string commandCreateLet1 = $"var {nameLet1}";
            string commandCreateLet2 = $"var {nameLet2}";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            calc.CreateOrChangeArgument( commandCreateLet2 );
            string nameFn = "newFn";
            string commandCreateFn = $"fn {nameFn}={nameLet1}+{nameLet2}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateFn );
            var resultFnName = calc.Print( $"print {nameFn}" );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "null", resultFnName );
        }

        [Fact]
        public void Calculator_CreateFnWithLetHasNull_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string commandCreateLet1 = $"var {nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string nameFn = "newFn";
            string commandCreateFn = $"fn {nameFn}={nameLet1}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateFn );
            var resultFnName = calc.Print( $"print {nameFn}" );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "null", resultFnName );
        }

        [Fact]
        public void Calculator_CreateLetWithLetHasNull_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string commandCreateLet1 = $"var {nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string nameLet = "nameLet";
            string commandCreateLet = $"let {nameLet}={nameLet1}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateLet );
            var resultFnName = calc.Print( $"print {nameLet}"  );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "null", resultFnName );
        }

        [Fact]
        public void Calculator_CreateLetAndChangeValue_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string commandCreateLet1 = $"var {nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string commandCreateLet = $"let {nameLet1}=12";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateLet );
            var resultFnName = calc.Print( $"print {nameLet1}"  );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "12", resultFnName );
        }

        [Fact]
        public void Calculator_CreateLetAndChangeValueOnLet_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string nameLet2 = "second";
            string commandCreateLet1 = $"let {nameLet1}=1";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string commandCreateLet2 = $"let {nameLet2}={nameLet1}";

            //act
            var result = calc.CreateOrChangeArgument( commandCreateLet2 );
            var resultFnName = calc.Print( $"print {nameLet2}" );

            //assert
            Assert.True( result, "Успешно." );
            Assert.Equal( "1", resultFnName );
        }

        [Fact]
        public void Calculator_PrintFnWithNull_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string commandCreateLet1 = $"var {nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string nameLet = "nameLet";
            string commandCreateLet = $"let {nameLet}={nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet );
            string nameFn = "newFn";
            string commandCreateFn = $"fn {nameFn}={nameLet1}";
            calc.CreateOrChangeArgument( commandCreateFn );

            //act
            var resultFnsPrint = calc.PrintFns();

            //assert
            Assert.Equal( "newFn:null\r\n", resultFnsPrint );
        }

        [Fact]
        public void Calculator_PrintFnWithValue_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string commandCreateLet1 = $"let {nameLet1}=1";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string nameLet2 = "nameLet";
            string commandCreateLet = $"let {nameLet2}={nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet );
            string nameFn = "newFn";
            string commandCreateFn = $"fn {nameFn}={nameLet1}+{nameLet2}";
            calc.CreateOrChangeArgument( commandCreateFn );

            //act
            var resultFnsPrint = calc.PrintFns();

            //assert
            Assert.Equal( "newFn:2\r\n", resultFnsPrint );
        }

        [Fact]
        public void Calculator_PrintFnsWithValue_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string commandCreateLet1 = $"let {nameLet1}=1";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string nameLet2 = "nameLet";
            string commandCreateLet = $"let {nameLet2}={nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet );
            string nameFn = "newFn";
            string nameFn2 = "newFn2";
            string commandCreateFn = $"fn {nameFn}={nameLet1}+{nameLet2}";
            string commandCreateFn2 = $"fn {nameFn2}={nameFn}+{nameLet2}";
            calc.CreateOrChangeArgument( commandCreateFn );
            calc.CreateOrChangeArgument( commandCreateFn2 );

            //act
            var resultFnsPrint = calc.PrintFns();

            //assert
            Assert.Equal( "newFn:2\r\nnewFn2:3\r\n", resultFnsPrint );
        }

        [Fact]
        public void Calculator_PrintFnsWithValueMultiply_Correct()
        {
            //arrange
            ICalculator calc = new Calculator.Calculator();
            string nameLet1 = "first";
            string commandCreateLet1 = $"let {nameLet1}=21.112";
            calc.CreateOrChangeArgument( commandCreateLet1 );
            string nameLet2 = "nameLet";
            string commandCreateLet = $"let {nameLet2}={nameLet1}";
            calc.CreateOrChangeArgument( commandCreateLet );
            string nameFn = "newFn";
            string nameFn2 = "newFn2";
            string commandCreateFn = $"fn {nameFn}={nameLet1}*{nameLet2}";
            string commandCreateFn2 = $"fn {nameFn2}={nameFn}*{nameFn}";
            calc.CreateOrChangeArgument( commandCreateFn );
            calc.CreateOrChangeArgument( commandCreateFn2 );

            //act
            var resultFnsPrint = calc.PrintFns();

            //assert
            Assert.Equal( "newFn:445.72\r\nnewFn2:198666.32\r\n", resultFnsPrint );
        }
    }
}
