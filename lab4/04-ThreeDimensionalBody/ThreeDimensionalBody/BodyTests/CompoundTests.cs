using ThreeDimensionalBody;
using Xunit;

namespace BodyTests
{
    public class CompoundTests
    {
        [Fact]
        public void Compound_ZeroCompound_CorrectResult()
        {
            //arrange
            Body body;

            //act
            body = new Compound();

            //assert
            Assert.Equal( 0, body.GetVolume() );
            Assert.Equal( 0, body.GetMass() );
            Assert.Equal( 0, body.GetDensity() );
        }

        [Fact]
        public void Compound_WithOneBody_CorrectResult()
        {
            //arrange
            var body = new Compound();
            var sphere = new Sphere( 5, 5 );

            //act
            var result = body.AddChildBody( sphere );

            //assert
            Assert.True( result );
            Assert.Equal( 523.599, body.GetVolume() );
            Assert.Equal( 2617.995, body.GetMass() );
            Assert.Equal( 5, body.GetDensity() );
        }

        [Fact]
        public void Compound_WithTwoBody_CorrectResult()
        {
            //arrange
            var body = new Compound();
            var sphere = new Sphere( 5, 5 );
            var cone = new Cone( 5, 2, 3 );

            //act
            var resultAddSphere = body.AddChildBody( sphere );
            var resultAddCone = body.AddChildBody( cone );

            //assert
            Assert.True( resultAddSphere );
            Assert.True( resultAddCone );
            Assert.Equal( 575.959, body.GetVolume() );
            Assert.Equal( 2775.075, body.GetMass() );
            Assert.Equal( 4.818, body.GetDensity() );
        }

        [Fact]
        public void Compound_AddCompoundBody_CorrectResult()
        {
            //arrange
            var body = new Compound();
            var compoundBody = GetCompoundBody();
            var sphere = new Sphere( 1, 2 );

            //act
            var resultAddSphere = body.AddChildBody( sphere );
            var resultAddCompoundBody = body.AddChildBody( compoundBody );

            //assert
            Assert.True( resultAddSphere );
            Assert.True( resultAddCompoundBody );
            Assert.Equal( 580.148, body.GetVolume() );
            Assert.Equal( 2783.453, body.GetMass() );
            Assert.Equal( 4.798, body.GetDensity() );
        }

        [Fact]
        public void Compound_AddYourself_ReturnFalse()
        {
            //arrange
            var body = GetCompoundBody();
            var compoundBody = GetCompoundBody();
            var sphere = new Sphere( 1, 2 );

            //act
            var resultAddSphere = body.AddChildBody( sphere );
            var resultAddCompoundBody = body.AddChildBody( compoundBody );

            //assert
            Assert.True( resultAddSphere );
            Assert.False( resultAddCompoundBody, "Нельзя добавить в составное тело само себя." );
        }

        #region BodyFactory
        private static Compound GetCompoundBody()
        {
            var compoundBody = new Compound();
            compoundBody.AddChildBody( new Sphere( 5, 5 ) );
            compoundBody.AddChildBody( new Cone( 5, 2, 3 ) );
            return compoundBody;
        }
        #endregion
    }
}
