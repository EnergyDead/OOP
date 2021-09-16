using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MySimpleCar.Tests
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void CreateCar()
        {
            Car car = new();

            Assert.AreEqual( "Двигатель выключен. Направление - стоит. Скорость: 0. Передача: stay", car.Info() );
        }

        [TestMethod]
        public void StepGearInOffEngingCar()
        {
            Car car = new();

            car.EndingOff();

            Assert.AreEqual( "Двигатель не включен", car.SetGear(-1) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear(0) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear(1) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear(2) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear(3) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear(4) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear(5) );
            
            Assert.AreEqual( "Двигатель не включен", car.SetGear(-12) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear(12) );
        }

        [TestMethod]
        public void StepGearInOnEnging()
        {
            Car car = new();

            car.EndingOn();

            Assert.AreEqual( "успешно", car.SetGear( -1 ) );
            Assert.AreEqual( "успешно", car.SetGear( 0 ) );
            Assert.AreEqual( "успешно", car.SetGear( 1 ) );
            Assert.AreEqual( "скорость авто не в диапазоне", car.SetGear( 2 ) );
            Assert.AreEqual( "скорость авто не в диапазоне", car.SetGear( 3 ) );
            Assert.AreEqual( "скорость авто не в диапазоне", car.SetGear( 4 ) );
            Assert.AreEqual( "скорость авто не в диапазоне", car.SetGear( 5 ) );

            Assert.AreEqual( "Двигатель не включен", car.SetGear( -12 ) );
            Assert.AreEqual( "Двигатель не включен", car.SetGear( 12 ) );

        }
    }
}
