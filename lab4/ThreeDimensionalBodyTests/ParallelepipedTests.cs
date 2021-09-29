using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBodyTests
{
    [TestClass]
    public class ParallelepipedTests
    {
        [TestMethod]
        public void CreateParallelepiped_CorrectArugmets_Create()
        {
            var body = new Parallelepiped( 10, 10, 10, 10);

            double density = body.GetDensity();
            double depth = body.GetDepth();
            double heigth = body.GetHeigth();
            double width = body.GetWidth();
            double volume = body.GetVolume();
            double mass = body.GetMass();
            string info = body.ToString();

            Assert.AreEqual( 10, density );
            Assert.AreEqual( 10, depth );
            Assert.AreEqual( 10, heigth );
            Assert.AreEqual( 10, width );
            Assert.AreEqual( 1000, volume );
            Assert.AreEqual( 10000, mass );
            Assert.AreEqual( "Паралеллепипед\nМасса: 10000\nОбъем: 1000\nПлотность: 10", info );
        }
    }
}
