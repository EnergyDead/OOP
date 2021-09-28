using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBodyTests
{
    [TestClass]
    public class BodyTests
    {
        [TestMethod]
        public void TestBody()
        {
            Body body = new Body();

            double density = body.GetDensity();
            double volume = body.GetVolume();
            double mass = body.GetMass();
            string info = body.ToString();

            Assert.AreEqual( 0, density );
            Assert.AreEqual( 0, volume );
            Assert.AreEqual( 0, mass );
            Assert.AreEqual( "Пустое тело\nМасса: 0\nОбъем: 0\nПлотность: 0", info );
        }
    }
}
