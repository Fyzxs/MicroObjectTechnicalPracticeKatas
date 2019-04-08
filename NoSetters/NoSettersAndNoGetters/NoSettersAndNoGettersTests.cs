using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoSettersAndNoGetters
{
    /*
        No Setters and No Getters Refactor Kata self directed

        This technical practice is to encapsulate the behavior around the data and prevent anyone else from accessing the data.

        Once Setters are removed, let's also remove Getters
       */

    public static class FizzBuzzUtils
    {
        public static void Calculate(FizzBuzz fizzBuzz)
        {
            if (fizzBuzz.GetInput() % 3 == 0)
            {
                fizzBuzz.ResultIsFizz();
            }

            if (fizzBuzz.GetInput() % 5 == 0)
            {
                if (fizzBuzz.GetResult() == null)
                {
                    fizzBuzz.ResultIsBuzz();
                } else
                {
                    fizzBuzz.ResultIsFizzBuzz();
                }
            }

            if (string.IsNullOrEmpty(fizzBuzz.GetResult()))
            {
                fizzBuzz.ResultIsInt();
            }
        }
    }

    public class FizzBuzz
    {
        private string _result;
        private readonly int _input;

        public FizzBuzz(int input) => _input = input;

        public int GetInput() => _input;
        public string GetResult() => _result;

        public void ResultIsFizz() => _result = "Fizz";
        public void ResultIsBuzz() => _result = "Buzz";
        public void ResultIsFizzBuzz() => _result = GetResult() + "Buzz";
        public void ResultIsInt() => _result = GetInput().ToString();
    }


    [TestClass]
    public class NoGettersWalkThroughTests
    {
        [TestMethod]
        public void ShouldReturnString1GivenInt1()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(1);
            string expected = "1";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }

        [TestMethod]
        public void ShouldReturnString2GivenInt2()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(2);
            string expected = "2";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt3()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(3);
            string expected = "Fizz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt6()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(2 * 3);
            string expected = "Fizz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt5()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(5);
            string expected = "Buzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt10()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(2 * 5);
            string expected = "Buzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt15()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(3 * 5);
            string expected = "FizzBuzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt30()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(2 * 3 * 5);
            string expected = "FizzBuzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.GetResult() == expected);
        }
    }
}