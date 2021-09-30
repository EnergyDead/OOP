using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreeDimensionalBody.figures;

namespace ThreeDimensionalBodyTests
{
    [TestClass]
    public class ConeTests
    {
        [TestMethod]
        public void CreateCone_CorrectArguments_Create()
        {
            var body = new Cone( 10, 10, 10 );

            double baseRadius = body.GetBaseRadius();
            double height = body.GetHeight();
            string info = body.ToString();

            Assert.AreEqual( 10, baseRadius );
            Assert.AreEqual( 10, height );
            Assert.AreEqual( "Конус\nМасса: 10471.975511965977\nОбъем: 1047.1975511965977\nПлотность: 10", info );
        }
    }
}
