using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MySimpleCar.Tests
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void InfoAboutCar()
        {
            Car car = new();

            Assert.AreEqual( "выключен", car.GetEngingInfo() );
            Assert.AreEqual( "0", car.GetSpeed() );
            Assert.AreEqual( "stay", car.GetGrear() );
            Assert.AreEqual( "стоит", car.DirectionOfTravel() );
        }

        [TestMethod]
        public void StepGearInOffEngingCar()
        {
            Car car = new();

            car.EndingOff();

            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(-1) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(0) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(1) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(2) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(3) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(4) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(5) );
            
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(-12) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear(12) );
        }

        [TestMethod]
        public void StepGearInOnEnging()
        {
            Car car = new();

            car.EndingOn();

            Assert.AreEqual( "óñïåøíî", car.SetGear( -1 ) );
            Assert.AreEqual( "óñïåøíî", car.SetGear( 0 ) );
            Assert.AreEqual( "óñïåøíî", car.SetGear( 1 ) );
            Assert.AreEqual( "ñêîðîñòü àâòî íå â äèàïàçîíå", car.SetGear( 2 ) );
            Assert.AreEqual( "ñêîðîñòü àâòî íå â äèàïàçîíå", car.SetGear( 3 ) );
            Assert.AreEqual( "ñêîðîñòü àâòî íå â äèàïàçîíå", car.SetGear( 4 ) );
            Assert.AreEqual( "ñêîðîñòü àâòî íå â äèàïàçîíå", car.SetGear( 5 ) );

            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear( -12 ) );
            Assert.AreEqual( "Äâèãàòåëü íå âêëþ÷åí", car.SetGear( 12 ) );

        }
    }
}
