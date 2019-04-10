using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace IsolateTheirCodePractice
{
    /*
        Isolate Their Code Refactor Kata Walk Through

        This technical practice is to practice transformation for reshaping the method to isolate 3rd party code.
    */

    public static class FooBarUtils
    {
        public static FooBar Calculate(string json)
        {
            const int fooValue = 7;
            const int barValue = 9;
            const string fooResult = "Foo";
            const string barResult = "Bar";
            const string resultNotSet = null;
            const string inputKey = "input";

            JObject jObject = JObject.Parse(json);

            FooBar fooBar = new FooBar {Input = jObject.GetValue(inputKey).Value<int>()};

            if (fooBar.Input % fooValue == 0)
            {
                fooBar.Result = fooResult;
            }

            if (fooBar.Input % barValue == 0)
            {
                if (fooBar.Result == resultNotSet)
                {
                    fooBar.Result = barResult;
                } else
                {
                    fooBar.Result += barResult;
                }
            }

            if (string.IsNullOrEmpty(fooBar.Result))
            {
                fooBar.Result = fooBar.Input.ToString();
            }

            return fooBar;
        }
    }

    public class FooBar
    {
        public int Input { get; set; }
        public string Result { get; set; }
    }

    [TestClass]
    public class IsolateTheirCodePracticeTests
    {
        [TestMethod]
        public void ShouldReturnString1GivenInt1()
        {
            //Arrange
            string json = "{\"input\":1}";
            string expected = "1";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnString2GivenInt2()
        {
            //Arrange
            string json = "{\"input\":2}";
            string expected = "2";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt3()
        {
            //Arrange
            string json = "{\"input\":3}";
            string expected = "Fizz";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt6()
        {
            //Arrange
            string json = "{\"input\":6}";
            string expected = "Fizz";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt5()
        {
            //Arrange
            string json = "{\"input\":5}";
            string expected = "Buzz";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt10()
        {
            //Arrange
            string json = "{\"input\":10}";
            string expected = "Buzz";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFooBarGivenInt15()
        {
            //Arrange
            string json = "{\"input\":15}";
            string expected = "FooBar";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFooBarGivenInt30()
        {
            //Arrange
            string json = "{\"input\":30}";
            string expected = "FooBar";

            //Act
            FooBar fooBar = FooBarUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }
    }
}
