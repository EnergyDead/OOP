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

            Assert.AreEqual( "��������� ��������. ����������� - �����. ��������: 0. ��������: stay", car.Info() );
        }

        [TestMethod]
        public void StepGearInOffEngingCar()
        {
            Car car = new();

            car.EndingOff();

            Assert.AreEqual( "��������� �� �������", car.SetGear(-1) );
            Assert.AreEqual( "��������� �� �������", car.SetGear(0) );
            Assert.AreEqual( "��������� �� �������", car.SetGear(1) );
            Assert.AreEqual( "��������� �� �������", car.SetGear(2) );
            Assert.AreEqual( "��������� �� �������", car.SetGear(3) );
            Assert.AreEqual( "��������� �� �������", car.SetGear(4) );
            Assert.AreEqual( "��������� �� �������", car.SetGear(5) );
            
            Assert.AreEqual( "��������� �� �������", car.SetGear(-12) );
            Assert.AreEqual( "��������� �� �������", car.SetGear(12) );
        }

        [TestMethod]
        public void StepGearInOnEnging()
        {
            Car car = new();

            car.EndingOn();

            Assert.AreEqual( "�������", car.SetGear( -1 ) );
            Assert.AreEqual( "�������", car.SetGear( 0 ) );
            Assert.AreEqual( "�������", car.SetGear( 1 ) );
            Assert.AreEqual( "�������� ���� �� � ���������", car.SetGear( 2 ) );
            Assert.AreEqual( "�������� ���� �� � ���������", car.SetGear( 3 ) );
            Assert.AreEqual( "�������� ���� �� � ���������", car.SetGear( 4 ) );
            Assert.AreEqual( "�������� ���� �� � ���������", car.SetGear( 5 ) );

            Assert.AreEqual( "��������� �� �������", car.SetGear( -12 ) );
            Assert.AreEqual( "��������� �� �������", car.SetGear( 12 ) );

        }
    }
}
