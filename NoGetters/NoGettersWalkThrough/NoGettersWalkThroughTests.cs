using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoGettersWalkThrough
{
    /*
        No Getters Refactor Kata Walk Through

        This technical practice is to encapsulate the behavior around the data and prevent anyone else from accessing the data.

    */

    public static class FizzBuzzUtils
    {
        public static void Calculate(FizzBuzz fizzBuzz)
        {
            StringBuilder sb = new StringBuilder();
            if (fizzBuzz.Input % 3 == 0)
            {
                sb.Append("Fizz");
            }
            else if (fizzBuzz.Input % 5 == 0)
            {
                sb.Append("Buzz");
            }

            fizzBuzz.Result = sb.Length == 0
                ? fizzBuzz.Input.ToString()
                : sb.ToString();
        }
    }

    public class FizzBuzz
    {
        public int Input { get; set; }
        public string Result { get; set; }
    }

    [TestClass]
    public class NoGettersWalkThroughTests
    {
        [TestMethod]
        public void ShouldReturnString1GivenInt1()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 1 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("1");
        }

        [TestMethod]
        public void ShouldReturnString2GivenInt2()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 2 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("2");
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt3()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 3 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("Fizz");
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt6()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 2 * 3 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("Fizz");
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt5()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 5 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("Buzz");
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt10()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 2 * 5 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("Buzz");
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt15()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 3 * 5 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("FizzBuzz");
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt30()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz { Input = 2 * 3 * 5 };

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            fizzBuzz.Result.Should().Be("FizzBuzz");
        }
    }
}