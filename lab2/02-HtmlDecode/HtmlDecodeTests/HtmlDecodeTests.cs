using Xunit;
using HtmlDecode;

namespace HtmlDecodeTests
{
    public class HtmlDecodeTests
    {
        [Fact]
        public void HtmlDecode_CorrectDecode() // тесты не находят ошибки. дописать
        {
            //Arrange
            string inputValue = "Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s ";
            string resultValue = "Cat <says> \"Meow\". M&M's ";

            //Act
            string result = HtmlDecoder.HtmlDecode( inputValue );
            //Assert
            Assert.Equal( resultValue, result );
        }

        [Fact]
        public void HtmlDecode_EmptyOutput_CorrectDecode()
        {
            //Arrange
            string inputValue = "";

            //Act
            string result = HtmlDecoder.HtmlDecode( inputValue );
            //Assert
            Assert.Empty( result );
        }
        [Fact]
        public void HtmlDecode_EmptyEncodeOutput_CorrectDecode()
        {
            //Arrange
            string inputValue = "Cat <says> \"Meow\". M&M's ";
            string resultValue = "Cat <says> \"Meow\". M&M's ";

            //Act
            string result = HtmlDecoder.HtmlDecode( inputValue );
            //Assert
            Assert.Equal( resultValue, result );
        }

        [Fact]
        public void HtmlDecode_CorrectOutput_CorrectDecode()
        {
            //Arrange
            string inputValue = "&amp;lt; &amp;gt;; &amp;&lt; &amp;lt; &amp;&apos; &amp;apos; &amp;&quot; &amp;quot;";
            string resultValue = "&lt; &gt;; &< &lt; &' &apos; &\" &quot;";

            //Act
            string result = HtmlDecoder.HtmlDecode( inputValue );
            //Assert
            Assert.Equal( resultValue, result );
        }

        [Fact]
        public void HtmlDecode_ManySame_CorrectDecode()
        {
            //Arrange
            string inputValue = "&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;&quot;&quot;&quot;&quot;&quot;&quot;&quot;";
            string resultValue = "&&&&&&&&&&&&&\"\"\"\"\"\"\"";

            //Act
            string result = HtmlDecoder.HtmlDecode( inputValue );
            //Assert
            Assert.Equal( resultValue, result );
        }
    }
}
