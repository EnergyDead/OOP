using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBodyTests
{
    [TestClass]
    public class SphereTests
    {
        [TestMethod]
        public void CreateSphere_CorrectArugmets_Create()
        {
            var body = new Sphere(10, 10);

            double density = body.GetDensity();
            double volume = body.GetVolume();
            double mass = body.GetMass();
            string info = body.ToString();

            Assert.AreEqual( 10, density );
            Assert.AreEqual( 4188.790204786391, volume );
            Assert.AreEqual( 41887.90204786391, mass );
            Assert.AreEqual( "Сфера\nМасса: 41887.90204786391\nОбъем: 4188.790204786391\nПлотность: 10", info );
        }
    }
}
