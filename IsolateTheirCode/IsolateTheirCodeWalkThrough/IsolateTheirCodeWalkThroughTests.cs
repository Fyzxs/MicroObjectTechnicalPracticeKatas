using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace IsolateTheirCodeWalkThrough
{ 
    /*
        Isolate Their Code Refactor Kata Walk Through

        This technical practice is to practice transformation for reshaping the method to isolate 3rd party code.

        Isolate JObject.Parse(json);
        extract new method into class (JsonParser)
        make method public
        Make class non-static
        update use of JsonParser to instantiate
        make method non-static
        create ctor on JsonParser
        create string json param in JsonParser ctor
        set json to field in ctor
        include json in JsonParser constructor in Calculate
        make JsonParser JObject.Parse use class field
        remove string json from JsonParser.Parse method signature
        create interface IParser
        Add IParser to JsonParser
        move Parse into interface, IParser
        move JsonParser instantiation to assign to a variable of IParser type

    The parse component of JObject has been isolated

        Isolate jObject.Value<int>("input");
        extract new method into class (JsonParsed)
        make method public
        Make class non-static
        update use of JsonParsed to instantiate
        make method non-static
        create ctor on JsonParsed that takes JObject
        set class field to ctor jObject param
        make IntValue use class variable
        remove param from IntValue signature
        create interface IParsed
        add IParsed to JsonParsed
        move IntValue to IParsed

    The Value component of JObject has been isolated

        create new method on IParser w/signature IParsed Parsed()
        implement on JsonParser
        copy JsonParsed instantiation into new Parsed method
        replace JsonParsed constructor jObject with Parse() method call
        update Calculate JsonParser call from Parse to Parsed
        update variable to IParsed parsed
        replace jsonParsed instantiation in Calculate with 'parsed' variable
        remove method from IParser, JObject Parse()
        inline JsonParser#Parse

    Our class now has zero knowledge of newtonsoft and json parsing
    */

    public static class FizzBuzzUtils
    {
        public static FizzBuzz Calculate(string json)
        {
            int value = JObject.Parse(json).Value<int>();

            FizzBuzz fizzBuzz = new FizzBuzz { Input = value };

            if (fizzBuzz.Input % 3 == 0)
            {
                fizzBuzz.Result = "Fizz";
            }

            if (fizzBuzz.Input % 5 == 0)
            {
                if (fizzBuzz.Result == null)
                {
                    fizzBuzz.Result = "Buzz";
                } else
                {
                    fizzBuzz.Result += "Buzz";
                }
            }

            if (string.IsNullOrEmpty(fizzBuzz.Result))
            {
                fizzBuzz.Result = fizzBuzz.Input.ToString();
            }

            return fizzBuzz;
        }
    }

    public class FizzBuzz
    {
        public int Input { get; set; }
        public string Result { get; set; }
    }

    [TestClass]
    public class IsolateTheirCodeWalkThroughTests
    {
        [TestMethod]
        public void ShouldReturnString1GivenInt1()
        {
            //Arrange
            string json = "{\"input\":1}";
            string expected = "1";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnString2GivenInt2()
        {
            //Arrange
            string json = "{\"input\":2}";
            string expected = "2";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt3()
        {
            //Arrange
            string json = "{\"input\":3}";
            string expected = "Fizz";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt6()
        {
            //Arrange
            string json = "{\"input\":6}";
            string expected = "Fizz";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt5()
        {
            //Arrange
            string json = "{\"input\":5}";
            string expected = "Buzz";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt10()
        {
            //Arrange
            string json = "{\"input\":10}";
            string expected = "Buzz";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt15()
        {
            //Arrange
            string json = "{\"input\":15}";
            string expected = "FizzBuzz";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt30()
        {
            //Arrange
            string json = "{\"input\":30}";
            string expected = "FizzBuzz";

            //Act
            FizzBuzz fizzBuzz = FizzBuzzUtils.Calculate(json);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }
    }
}