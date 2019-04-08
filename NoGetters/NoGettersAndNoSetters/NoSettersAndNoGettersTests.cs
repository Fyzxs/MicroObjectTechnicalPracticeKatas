using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoGettersAndNoSetters
{
    /*
        No Getters and No Setters Refactor Kata self directed

        This technical practice is to encapsulate the behavior around the data and prevent anyone else from accessing the data.

        Once Getters are removed, let's also remove Setters
       */

    public static class FizzBuzzUtils
    {
        public static void Calculate(FizzBuzz fizzBuzz)
        {
            if (fizzBuzz.IsEvenlyDivisibleBy3())
            {
                fizzBuzz.SetResult("Fizz");
            }

            if (fizzBuzz.IsEvenlyDivisibleBy5())
            {
                if (fizzBuzz.IsResultNull())
                {
                    fizzBuzz.SetResult("Buzz");
                } else
                {
                    fizzBuzz.SetResult(fizzBuzz.AppendBuzz());
                }
            }

            if (fizzBuzz.ResultIsNullOrEmpty())
            {
                fizzBuzz.SetResult(fizzBuzz.AsString());
            }
        }
    }

    public class FizzBuzz
    {
        private int _input;
        private string _result;

        public void SetInput(int value) => _input = value;

        public void SetResult(string value) => _result = value;

        public bool IsEvenlyDivisibleBy3() => _input % 3 == 0;
        public bool IsEvenlyDivisibleBy5() => _input % 5 == 0;
        public string AsString() => _input.ToString();
        public bool IsResultNull() => _result == null;
        public bool ResultIsNullOrEmpty() => string.IsNullOrEmpty(_result);
        public string AppendBuzz() => _result + "Buzz";
        public bool IsResultEqual(string expected) => _result == expected;
    }


    [TestClass]
    public class NoGettersWalkThroughTests
    {
        [TestMethod]
        public void ShouldReturnString1GivenInt1()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(1);
            string expected = "1";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnString2GivenInt2()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(2);
            string expected = "2";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt3()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(3);
            string expected = "Fizz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt6()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(2 * 3);
            string expected = "Fizz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt5()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(5);
            string expected = "Buzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt10()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(2 * 5);
            string expected = "Buzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt15()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(3 * 5);
            string expected = "FizzBuzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt30()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.SetInput(2 * 3 * 5);
            string expected = "FizzBuzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }
    }
}