using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBodyTests
{
    [TestClass]
    public class CylinderTests
    {
        [TestMethod]
        public void CreateCylinder_CorrectArguments_Create()
        {
            var body = new Cylinder( 10, 10, 10 );

            double baseRadius = body.GetBaseRadius();
            double height = body.GetHeight();
            string info = body.ToString();

            Assert.AreEqual( 10, baseRadius );
            Assert.AreEqual( 10, height );
            Assert.AreEqual( "Цилиндр\nМасса: 31415.926535897932\nОбъем: 3141.5926535897934\nПлотность: 10", info );
        }
    }
}
