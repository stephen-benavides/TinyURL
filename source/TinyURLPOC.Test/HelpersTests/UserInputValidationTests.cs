using NUnit.Framework;
using TinyURLPOC;
using TinyURLPOC.Helpers;

namespace TinyURLPOC.Test.HelpersTests
{
    public class UserInputValidationTests
    {
        private UserInputValidation _userInput;

        [SetUp]
        public void Setup()
        {
            _userInput = new UserInputValidation();
        }

        [Test]
        //[TestCase("asdf.com", true)]
        [TestCase("a2.comasd", true)]
        [TestCase("12a.comasd", true)]
        [TestCase("    121a.comasd", true)]
        [TestCase("http://sometest.comasd", true)]
        [TestCase("http:/sometest.comasd", true)]
        [TestCase("http:sometest.comasd", true)]
        [TestCase("http//:sometest.comasd", true)]
        [TestCase("https//:sometest.comasd", true)]
        [TestCase("https//:///sometest.comasd", true)]
        [TestCase("http:sometest@wer.com", true)]
        [TestCase("   http:sometest@wer.com   ", true)]
        [TestCase("@@@@http:sometest@wer.com", true)]
        public void IsValidUrl_ReturnTrueIfTheUrlMatchesConditions(string input, bool expected)
        {
            var actual = _userInput.IsValidUrl(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("asdf  .com", false)]
        [TestCase("http asdas", false)]
        [TestCase("asdasd as  da", false)]
        [TestCase("http://     sometest.comasd", false)]
        [TestCase("https  :/sometest.comasd", false)]
        [TestCase("http:sometest   .c o m", false)]
        [TestCase("http:sometest   .com    ", false)]
        [TestCase("http:   sometest.com    ", false)]
        [TestCase("", false)]
        public void IsValidUrl_ReturnFalseIfTheUrlDoesNOTMatchesConditions(string input, bool expected)
        {
            var actual = _userInput.IsValidUrl(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase("https://tinyurl.com/asdasdas", true)]
        [TestCase("https://tinyurl.com/asdasdas   ", true)]
        [TestCase("    https://tinyurl.com/asdasdas   ", true)]
        public void IsValidTinyUrl_CheckIfMatchesBase64(string input, bool expected)
        {
            var actual = _userInput.IsValidTinyUrl(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("https://tinyurl.com/asda  sdas", false)]
        [TestCase("   https:/  /tinyu  rl.c om/a sd a  sd as", false)]
        [TestCase("", false)]
        public void IsValidTinyUrl_CheckIfDoesNotMatchBase64(string input, bool expected)
        {
            var actual = _userInput.IsValidTinyUrl(input);
            Assert.AreEqual(expected, actual);
        }
    }
}