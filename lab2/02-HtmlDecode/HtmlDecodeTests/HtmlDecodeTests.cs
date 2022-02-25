using System;
using System.Text;
using Xunit;
using HtmlDecode;

namespace HtmlDecodeTests
{
    public class HtmlDecodeTests
    {
        [Fact]
        public void HtmlDecode_CoreectDecode()
        {
            //Arrange
            string inputValue = "Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s ";
            string resultValue = "Cat <says> \"Meow\". M&M's ";

            //Act
            StringBuilder result = new StringBuilder( inputValue );
            Program.HtmlDecode( result );
            //Assert
            Assert.Equal( resultValue, result.ToString() );
        }

        [Fact]
        public void HtmlDecode_EmptyOutput_CoreectDecode()
        {
            //Arrange
            string inputValue = "";

            //Act
            StringBuilder result = new StringBuilder( inputValue );
            Program.HtmlDecode( result );
            //Assert
            Assert.Empty( result.ToString() );
        }
        [Fact]
        public void HtmlDecode_EmptyEncodeOutput_CoreectDecode()
        {
            //Arrange
            string inputValue = "Cat <says> \"Meow\". M&M's ";
            string resultValue = "Cat <says> \"Meow\". M&M's ";

            //Act
            StringBuilder result = new StringBuilder( inputValue );
            Program.HtmlDecode( result );
            //Assert
            Assert.Equal( resultValue, result.ToString() );
        }
    }
}
