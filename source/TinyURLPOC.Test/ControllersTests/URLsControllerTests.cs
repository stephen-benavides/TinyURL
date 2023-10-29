using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TinyURLPOC.Controllers;
using TinyURLPOC.Data;
using TinyURLPOC.Helpers;
using TinyURLPOC.Parser;

namespace TinyURLPOC.Test.Controller
{
    internal class URLsControllerTests
    {
        private URLsController _urLsController;

        [SetUp]
        public void SetUp()
        {
            _urLsController = new URLsController(new Base64Encoding());
        }

        [Test]
        [Order(1)]
        [TestCase("a2.comasd", "https://tinyurl.com/YTIuY29tYXNk")]
        [TestCase("12a.comasd", "https://tinyurl.com/MTJhLmNvbWFzZA==")]
        [TestCase("    121a.comasd", "https://tinyurl.com/ICAgIDEyMWEuY29tYXNk")]
        [TestCase("http://sometest.comasd", "https://tinyurl.com/aHR0cDovL3NvbWV0ZXN0LmNvbWFzZA==")]
        [TestCase("http:/sometest.comasd", "https://tinyurl.com/aHR0cDovc29tZXRlc3QuY29tYXNk")]
        [TestCase("http:sometest.comasd", "https://tinyurl.com/aHR0cDpzb21ldGVzdC5jb21hc2Q=")]
        [TestCase("http://sometest.comasd", "https://tinyurl.com/aHR0cDovL3NvbWV0ZXN0LmNvbWFzZA==")]
        [TestCase("http:/sometest.comasd", "https://tinyurl.com/aHR0cDovc29tZXRlc3QuY29tYXNk")]
        [TestCase("http:sometest.comasd", "https://tinyurl.com/aHR0cDpzb21ldGVzdC5jb21hc2Q=")]
        public void AddLongUrl_ReturnEncodedBase64ShortUrlForValidInput(string input, string expected)
        {
            Console.WriteLine("Input URL: {0}", input);
            var actual = _urLsController.GetShortUrl(input);
            Console.WriteLine("Short URL: {0}", actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Order(2)]
        [TestCase("asdf  .com", null)]
        [TestCase("http asdas", null)]
        [TestCase("asdasd as  da", null)]
        [TestCase("http://     sometest.comasd", null)]
        [TestCase("https  :/sometest.comasd", null)]
        [TestCase("http:sometest   .c o m", null)]
        [TestCase("http:sometest   .com    ", null)]
        [TestCase("http:   sometest.com    ", null)]
        [TestCase("", null)]
        public void AddLongUrl_ReturnnullForInValidInput(string input, string expected)
        {
            Console.WriteLine("Input URL: {0}", input);
            var actual = _urLsController.GetShortUrl(input);
            Console.WriteLine("Short URL: {0}", actual);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase("asdf.com", "aasd123", "https://tinyurl.com/aasd123")]
        [TestCase("asdfasd.com", "aasd123", "https://tinyurl.com/aasd123")]
        [TestCase("asdf.com", "aasd1234", "https://tinyurl.com/aasd1234")]
        public void AddLongUrlWithAlias_ReturnShortUrlForValidInputAndAlias(string input, string alias, string expected)
        {
            Console.WriteLine("Input URL: {0}", input);
            Console.WriteLine("Alias: {0}", alias);
            var actual = _urLsController.GetShortUrlUsingAlias(input, alias);

            Console.WriteLine("Short URL: {0}", actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        //Adding value in URLsController.CS to check if the method also adds the data in DB successfully for validation
        [TestCase("asdf.com", "Test123.com", null)]
        public void AddLongUrlWithAlias_ReturnNullIfAliasAlreadyExistsInDb(string input, string alias, string expected)
        {
            Console.WriteLine("Input URL: {0}", input);
            Console.WriteLine("Alias: {0}", alias);
            var actual = _urLsController.GetShortUrlUsingAlias(input, alias);

            Console.WriteLine("Short URL: {0}", actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Order(3)]
        [TestCase("Test123.com", "ORIGINALURLtest.com")]
        public void GetLongUrl_ReturnLongUrl_From_ShortUrl(string input, string expected)
        {
            Console.WriteLine("Input URL: {0}", input);
            var actual = _urLsController.GetLongUrl(input);
            Console.WriteLine("Short URL: {0}", actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Order(3)]
        [TestCase("Test1aadsd23.com", null)]
        public void GetLongUrl_ReturnNullIfLongUrlDoesNotExist(string input, string expected)
        {
            Console.WriteLine("Input URL: {0}", input);
            var actual = _urLsController.GetLongUrl(input);
            Console.WriteLine("Short URL: {0}", actual);
            Assert.AreEqual(expected, actual);
        }

    }
}
