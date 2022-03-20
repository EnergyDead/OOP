using Xunit;
using CarSimulator;

namespace CarTests
{
    public class CarTests
    {
        [Fact]
        public void Car_CreateCar_CreatesCorrectCar()
        {
            //arrange
            Car car;

            //act
            car = new();

            //assert
            Assert.NotNull( car );
            Assert.False( car.IsEngineRunning, "При инициализцаии машина не заведена." );
            Assert.True( car.Speed == 0, "При инициализцаии сокорость равна 0." );
            Assert.True( car.Gear == Gear.Neutral, "При инициализцаии машина на нейтальной передаче." );
            Assert.True( car.Direction == Direction.OnPlace, "При инициализцаии машина стоит на месте." );
        }

        [Fact]
        public void Car_TurnOnEngine_ReturnsTrueAndSetIsEngineRunning()
        {
            //arrange
            Car car = new();

            //act
            bool result = car.TurnOnEngine();

            //assert
            Assert.True( result );
            Assert.True( car.IsEngineRunning, "авто успешно завелся" );
            Assert.True( car.Speed == 0, "Скорость после запуска авто не изменяется." );
            Assert.True( car.Direction == Direction.OnPlace, "Наравление после запуска авто не изменяется." );
            Assert.True( car.Gear == Gear.Neutral, "Скорость после запуска авто не изменяется." );
        }

        [Fact]
        public void Car_TurnOffEngineWhenAlready_ResultsTrue()
        {
            //arrange
            Car car = new();

            //act
            bool result = car.TurnOffEngine();

            //assert
            Assert.True( result );
            Assert.False( car.IsEngineRunning, "авто не заведено." );
            Assert.True( car.Speed == 0, "После выключения авто скорость не изменяется и остается равной 0." );
            Assert.True( car.Direction == Direction.OnPlace, "После выключения, авто не двигается." );
            Assert.True( car.Gear == Gear.Neutral, "После выключения, авто остается на нейтральной передаче." );
        }

        [Fact]
        public void Car_TurnOffEngineWhenCarTurnOnEngine_ResultsTrue()
        {
            //arrange
            Car car = GetTurnOnEngineCar();

            //act
            bool result = car.TurnOffEngine();

            //assert
            Assert.True( result );
            Assert.False( car.IsEngineRunning, "авто не заведено." );
            Assert.True( car.Speed == 0, "После выключения авто скорость не изменяется и остается равной 0." );
            Assert.True( car.Direction == Direction.OnPlace, "После выключения, авто не двигается." );
            Assert.True( car.Gear == Gear.Neutral, "После выключения, авто остается на нейтральной передаче." );
        }

        [Fact]
        public void Car_SetGearWhenCarTurnOnEngine_ResultTrue()
        {
            //arrange
            var carGear = 1;
            Car car = GetTurnOnEngineCar();

            //act
            bool result = car.SetGear( carGear );

            //assert
            Assert.True( result );
            Assert.Equal( (Gear)carGear, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Speed == 0, "После включения передачи авто, скорость не изменяется." );
            Assert.True( car.Direction == Direction.OnPlace, "После включения передачи, авто не двигается." );

        }

        [Fact]
        public void Car_SetGearWhenCarTurnOffEngine_ResultFalse()
        {
            //arrange
            var oldCarGear = 0;
            var newCarGear = 1;
            Car car = new();

            //act
            bool result = car.SetGear( newCarGear );

            //assert
            Assert.False( result );
            Assert.Equal( (Gear)oldCarGear, car.Gear );
            Assert.False( car.IsEngineRunning, "авто не заведено." );
            Assert.True( car.Speed == 0, "После не успешного переключения передачи авто, скорость не изменяется." );
            Assert.True( car.Direction == Direction.OnPlace, "После не успешного переключения передачи, авто не двигается." );

        }

        [Fact]
        public void Car_SetGearNeutralWhenCarTurnOffEngine_ResultTrue()
        {
            //arrange
            var carGear = 0;
            Car car = new();

            //act
            bool result = car.SetGear( carGear );

            //assert
            Assert.True( result );
            Assert.Equal( (Gear)carGear, car.Gear );
            Assert.False( car.IsEngineRunning, "авто не заведено." );
            Assert.True( car.Speed == 0, "После включения передачи авто, скорость не изменяется." );
            Assert.True( car.Direction == Direction.OnPlace, "После включения передачи, авто не двигается." );
        }

        [Fact]
        public void Car_SetGearReverseWhenCarTurnOnEngine_ResultTrue()
        {
            //arrange
            var carGear = -1;
            Car car = GetTurnOnEngineCar();

            //act
            bool result = car.SetGear( carGear );

            //assert
            Assert.True( result );
            Assert.Equal( (Gear)carGear, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Speed == 0, "После включения передачи авто, скорость не изменяется." );
            Assert.True( car.Direction == Direction.OnPlace, "После включения передачи, авто не двигается." );
        }

        [Fact]
        public void Car_SetSpeedWhenCarTurnOnEngineAndGearFirst_ResultTrue()
        {
            //arrange
            var speed = 10;
            Car car = GetTurnOnEngineCarAndSetGearFirst();

            //act
            bool result = car.SetSpeed( speed );

            //assert
            Assert.True( result );
            Assert.Equal( speed, car.Speed );
            Assert.Equal( Gear.First, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetSpeedWhenCarTurnOnEngineAndGearReverse_ResultTrue()
        {
            //arrange
            var speed = 10;
            Car car = GetTurnOnEngineCarAndSetGearReverse();

            //act
            bool result = car.SetSpeed( speed );

            //assert
            Assert.True( result );
            Assert.Equal( speed, car.Speed );
            Assert.Equal( Gear.Reverse, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Backward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetGearSecondWhenCarTurnOnEngineAndGearFirst_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearFirstAndMove();

            //act
            bool result = car.SetGear( 2 );

            //assert
            Assert.True( result );
            Assert.Equal( 20, car.Speed );
            Assert.Equal( Gear.Second, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetSpeedWhenCarTurnOnEngineAndGearSecond_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearSecondAndMove();

            //act
            bool result = car.SetSpeed( 50 );

            //assert
            Assert.True( result );
            Assert.Equal( 50, car.Speed );
            Assert.Equal( Gear.Second, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetGearThirdWhenCarTurnOnEngineAndGearSecond_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearSecondAndMove();

            //act
            bool result = car.SetGear( 3 );

            //assert
            Assert.True( result );
            Assert.Equal( 40, car.Speed );
            Assert.Equal( Gear.Third, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetSpeedWhenCarTurnOnEngineAndGearThird_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearThirdAndMove();

            //act
            bool result = car.SetSpeed( 60 );

            //assert
            Assert.True( result );
            Assert.Equal( 60, car.Speed );
            Assert.Equal( Gear.Third, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetGearFourthWhenCarTurnOnEngineAndGearThird_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearThirdAndMove();

            //act
            bool result = car.SetGear( 4 );

            //assert
            Assert.True( result );
            Assert.Equal( 50, car.Speed );
            Assert.Equal( Gear.Fourth, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetSpeedWhenCarTurnOnEngineAndGearFifth_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearFourthAndMove();

            //act
            bool result = car.SetSpeed( 60 );

            //assert
            Assert.True( result );
            Assert.Equal( 60, car.Speed );
            Assert.Equal( Gear.Fourth, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetGearFourthhWhenCarTurnOnEngineAndGearFifth_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearFourthAndMove();

            //act
            bool result = car.SetGear( 5 );

            //assert
            Assert.True( result );
            Assert.Equal( 50, car.Speed );
            Assert.Equal( Gear.Fifth, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_SetSpeedWhenCarTurnOnEngineAndGearFourth_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearFourthAndMove();

            //act
            bool result = car.SetSpeed( 60 );

            //assert
            Assert.True( result );
            Assert.Equal( 60, car.Speed );
            Assert.Equal( Gear.Fourth, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После выставления положительной скорости, авто двигается вперед." );
        }

        [Fact]
        public void Car_TurnOffEngingWhenCarIsMoving_ResultFalse()
        {
            //arrange
            Car car = GetCarThatGearFirstAndMove();

            //act
            bool result = car.TurnOffEngine();

            //assert
            Assert.False( result );
            Assert.True( car.IsEngineRunning, "авто останется заведенным." );
            Assert.True( car.Speed == 20, "После неуспешного выключения авто скорость не изменяется." );
            Assert.True( car.Direction == Direction.Forward, "После неуспешного выключения авто, направление не поменяется." );
            Assert.True( car.Gear == Gear.First, "После неуспешного выключения, авто остается той же передаче." );
        }

        [Fact]
        public void Car_SetGearFirstWhanCarDirectionBackward_ResultFalse()
        {
            //arrange
            Car car = GetCarThatGearReverseAndMove();

            //act
            bool result = car.SetGear( 1 );

            //assert
            Assert.False( result );
            Assert.Equal( 10, car.Speed );
            Assert.Equal( Gear.Reverse, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Backward, "После неудачной попытки переключить передачу, движение авто не изменится." );
        }

        [Fact]
        public void Car_SetGearBackwardWhanCarDirectionFirst_ResultFalse()
        {
            //arrange
            Car car = GetCarThatGearFirstAndMove();

            //act
            bool result = car.SetGear( -1 );

            //assert
            Assert.False( result );
            Assert.Equal( 20, car.Speed );
            Assert.Equal( Gear.First, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Forward, "После неудачной попытки переключить передачу, движение авто не изменится." );
        }

        [Fact]
        public void Car_SetGearBackwardWhanCarDirectionForward_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearReverseAndMove();

            //act
            bool result = car.SetGear( -1 );

            //assert
            Assert.True( result );
            Assert.Equal( 10, car.Speed );
            Assert.Equal( Gear.Reverse, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Backward, "После переключения передачи саму на себя, движение авто не изменится." );
        }

        [Fact]
        public void Car_SetGearNeutralWhanCarDirectionBackward_ResultTrue()
        {
            //arrange
            Car car = GetCarThatGearReverseAndMove();

            //act
            bool result = car.SetGear( 0 );

            //assert
            Assert.True( result );
            Assert.Equal( 10, car.Speed );
            Assert.Equal( Gear.Neutral, car.Gear );
            Assert.True( car.IsEngineRunning, "авто заведено." );
            Assert.True( car.Direction == Direction.Backward, "После переключения передачи на нейтральную, движение авто не изменится." );
        }

        #region CarFactory
        private static Car GetTurnOnEngineCar()
        {
            Car car = new();
            car.TurnOnEngine();

            return car;
        }

        private static Car GetTurnOnEngineCarAndSetGearFirst()
        {
            Car car = GetTurnOnEngineCar();
            car.SetGear( 1 );

            return car;
        }

        private static Car GetTurnOnEngineCarAndSetGearReverse()
        {
            Car car = GetTurnOnEngineCar();
            car.SetGear( -1 );

            return car;
        }

        private static Car GetCarThatGearReverseAndMove()
        {
            Car car = GetTurnOnEngineCarAndSetGearReverse();
            car.SetSpeed( 10 );

            return car;
        }

        private static Car GetCarThatGearFirstAndMove()
        {
            Car car = GetTurnOnEngineCar();
            car.SetGear( 1 );
            car.SetSpeed( 20 );

            return car;
        }

        private static Car GetCarThatGearSecondAndMove()
        {
            Car car = GetCarThatGearFirstAndMove();
            car.SetGear( 2 );
            car.SetSpeed( 40 );

            return car;
        }

        private static Car GetCarThatGearThirdAndMove()
        {
            Car car = GetCarThatGearSecondAndMove();
            car.SetGear( 3 );
            car.SetSpeed( 50 );

            return car;
        }

        private static Car GetCarThatGearFourthAndMove()
        {
            Car car = GetCarThatGearThirdAndMove();
            car.SetGear( 4 );

            return car;
        }

        private static Car GetCarThatGearFifthAndMove()
        {
            Car car = GetCarThatGearThirdAndMove();
            car.SetGear( 5 );

            return car;
        }
        #endregion CarFactory
    }
}