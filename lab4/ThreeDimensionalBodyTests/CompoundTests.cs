using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBodyTests
{
    [TestClass]
    public class CompoundTests
    {
        [TestMethod]
        public void CreateCompound_CorrectArguments_Create()
        {
            var body = new Compound();

            body.AddChildBody( new Cylinder( 5, 1, 10 ) );
            body.AddChildBody( new Cone( 5, 1, 20 ) );

            double mass = body.GetMass();
            double density = body.GetDensity();
            double volume = body.GetVolume();
            string info = body.ToString();

            Assert.AreEqual( 261.79938779914943, mass );
            Assert.AreEqual( 15, density );
            Assert.AreEqual( 20.943951023931955, volume );
            Assert.AreEqual( "Составное тело включающее 2 элементов.\nЦилиндр\nМасса: 157.07963267948966\nОбъем: 15.707963267948966\nПлотность: 10\n" +
                "Конус\nМасса: 104.71975511965978\nОбъем: 5.235987755982989\nПлотность: 20", info );
        }
    }
}