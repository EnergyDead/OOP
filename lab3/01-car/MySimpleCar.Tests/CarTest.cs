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
            Assert.AreEqual( Gear.stay, car.GetGrear() );
            Assert.AreEqual( Direction.stay, car.DirectionOfTravel() );
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
        public void StepGearInOnEngingCar()
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

            Assert.AreEqual( "авто не имеет такую скорость", car.SetGear( -12 ) );
            Assert.AreEqual( "авто не имеет такую скорость", car.SetGear( 12 ) );
        }

        [TestMethod]
        public void SetSpeedCar()
        {
            Car car = new();

            Assert.AreEqual( "двигатель не запущен", car.SetSpeed( 10 ) );
            Assert.AreEqual( "0", car.GetSpeed() );

            car.EndingOn();
            Assert.AreEqual( "нейтральная передача", car.SetSpeed( 10 ) );
            Assert.AreEqual( "0", car.GetSpeed() );

            Assert.AreEqual( "-10 за пределами", car.SetSpeed( -10 ) );
            Assert.AreEqual( "0", car.GetSpeed() );

            car.SetGear( 1 );
            Assert.AreEqual( "", car.SetSpeed( 1 ) );
            Assert.AreEqual( "", car.SetSpeed( 10 ) );
            Assert.AreEqual( "", car.SetSpeed( 5 ) );
            Assert.AreEqual( "", car.SetSpeed( 0 ) );
            Assert.AreEqual( "", car.SetSpeed( 30 ) );

            car.SetGear( 0 );
            Assert.AreEqual( "", car.SetSpeed( 29 ) );
            Assert.AreEqual( "", car.SetSpeed( 0 ) );
            Assert.AreEqual( "-10 за пределами", car.SetSpeed( -10 ) );
        }

        [TestMethod]
        public void OffEndingCar()
        {
            Car car = new();

            car.EndingOn();
            car.SetGear( 1 );
            car.SetSpeed( 10 );

            Assert.AreEqual( "10", car.GetSpeed() );
            Assert.AreEqual( Gear.first, car.GetGrear() );

            Assert.AreEqual( "скорость больше 0", car.EndingOff() );
            Assert.AreEqual( "включен", car.GetEngingInfo() );

            car.SetSpeed( 0 );
            Assert.AreEqual( "передача не является нейтральной", car.EndingOff() );
            Assert.AreEqual( "включен", car.GetEngingInfo() );

            car.SetGear( 0 );
            Assert.AreEqual( "успешно", car.EndingOff() );
            Assert.AreEqual( "выключен", car.GetEngingInfo() );
        }

        [TestMethod]
        public void AllGearCar()
        {
            Car car = new();

            car.EndingOn();
            car.SetGear( 1 );
            car.SetSpeed( 30 );

            Assert.AreEqual( Gear.first, car.GetGrear() );
            Assert.AreEqual( "30", car.GetSpeed() );

            car.SetGear( 2 );
            car.SetSpeed( 50 );
            Assert.AreEqual( Gear.second, car.GetGrear() );
            Assert.AreEqual( "50", car.GetSpeed() );

            car.SetGear( 3 );
            car.SetSpeed( 60 );
            Assert.AreEqual( Gear.therth, car.GetGrear() );
            Assert.AreEqual( "60", car.GetSpeed() ); car.SetGear( 3 );

            car.SetGear( 4 );
            car.SetSpeed( 90 );
            Assert.AreEqual( Gear.forth, car.GetGrear() );
            Assert.AreEqual( "90", car.GetSpeed() );
            
            car.SetGear( 5 );
            car.SetSpeed( 150 );
            Assert.AreEqual( Gear.fisth, car.GetGrear() );
            Assert.AreEqual( "150", car.GetSpeed() );

            car.SetGear( 0 );
            Assert.AreEqual( Gear.stay, car.GetGrear() );

            car.SetSpeed( 50 );
            car.SetGear( 5 );
            Assert.AreEqual( Gear.fisth, car.GetGrear() );
            Assert.AreEqual( "50", car.GetSpeed() );
        }

        [TestMethod]
        public void BackDrive()
        {
            Car car = new();

            car.EndingOn();
            car.SetGear( -1 );
            car.SetSpeed( 20 );

            Assert.AreEqual( Gear.back, car.GetGrear() );
            Assert.AreEqual( "20", car.GetSpeed() );

            car.SetSpeed( 0 );
            Assert.AreEqual( "успешно", car.SetGear( 1 ) );

            car.SetGear( 0 );
            car.SetGear( 1 );
            Assert.AreEqual( "успешно", car.SetGear( -1 ) );

            Assert.AreEqual( "30 за пределами", car.SetSpeed( 30 ) );
            Assert.AreEqual( "скорость авто не в диапазоне", car.SetGear( 3 ) );
            Assert.AreEqual( "успешно", car.SetGear( -1 ) );

            Assert.AreEqual( "скорость авто не в диапазоне", car.SetGear( 2 ) );
            Assert.AreEqual( "", car.SetSpeed( 20 ) );
            Assert.AreEqual( "ошибка, с задней передачи можно переключить на 1 только при 0 скорости", car.SetGear( -1 ) );
        }
    }
}
