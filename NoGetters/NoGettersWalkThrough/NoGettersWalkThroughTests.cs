using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoGettersWalkThrough
{
    /*
        No Getters Refactor Kata Walk Through

        This technical practice is to encapsulate the behavior around the data and prevent anyone else from accessing the data.

        STEPS:
            Change Input from Property to Methods
            Isolate Divisible By Three
            Make DivisibleByThree non-static
            Isolate Divisible By Five
            Make DivisibleByFive non-static
            Isolate Input to string
            Make InputToString non-static
            Make GetInput private
            Inline GetInput
            
        No More Input Getter
        
            Change Result from Property to Methods
            Isolate fizzBuzz.Result == null
            Make IsResultNull non-static
            Isolate string.IsNullOrEmpty(fizzBuzz.Result)
            Make IsResultNullOrEmpty non-static
            Isolate fizzBuzz.Result  + "Buzz"
            Make AppendBuzz non-static
            Isolate fizzBuzz.Result == expected
            Make ResultEquals non-static
            Make GetResult private
            Inline GetResult

        No More Result Getter

    */

    public static class FizzBuzzUtils
    {
        public static void Calculate(FizzBuzz fizzBuzz)
        {
            if (fizzBuzz.Input % 3 == 0)
            {
                fizzBuzz.Result = "Fizz";
            }

            if (fizzBuzz.Input % 5 == 0)
            {
                if (fizzBuzz.Result == null)
                {
                    fizzBuzz.Result = "Buzz";
                }
                else
                {
                    fizzBuzz.Result += "Buzz";
                }
            }

            if (string.IsNullOrEmpty(fizzBuzz.Result))
            {
                fizzBuzz.Result = fizzBuzz.Input.ToString();
            }
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
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 1;
            string expected = "1";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnString2GivenInt2()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 2;
            string expected = "2";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt3()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 3;
            string expected = "Fizz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt6()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 2 * 3;
            string expected = "Fizz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt5()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 5;
            string expected = "Buzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBuzzGivenInt10()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 2 * 5;
            string expected = "Buzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt15()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 3 * 5;
            string expected = "FizzBuzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFizzBuzzGivenInt30()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.Input = 2 * 3 * 5;
            string expected = "FizzBuzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.Result == expected);
        }
    }
}