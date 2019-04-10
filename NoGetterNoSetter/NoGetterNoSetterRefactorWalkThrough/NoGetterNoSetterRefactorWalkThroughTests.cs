using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoGetterNoSetterRefactorWalkThrough
{
    /*
        No Setters and No Getters Refactor Kata self directed

        This technical practice is to encapsulate the behavior around the data and prevent anyone else from accessing the data.

        Once both are removed, let's look at what we have

        Our Calculate method ONLY interacts with the FizzBuzz object.
        Technically this would also apply to the original form of Calculate, but then we wouldn't have gotten to practice.

        When we can isolate interactions to a single class, the method can be lifted into that class.

        + Isolate contents of Calculate into a new method (Result)
        + make method non-static
        + inline each method call in the Result method
        + inline Calculate
        + delete FizzBuzzUtils

        FizzBuzz should now have two methods - IsResultEqual and Result.

        Refactoring legacy code will often take these round about ways to encapsulate smaller pieces and later put them back together.
        It's a process that you shouldn't skip. The small steps are how we know we're doing it right.
        Refactoring is just like TDD - do the smallest step you can, then repeat.

       */

    public static class FizzBuzzUtils
    {
        public static void Calculate(FizzBuzz fizzBuzz)
        {
            if (fizzBuzz.IsEvenlyDivisibleBy3())
            {
                fizzBuzz.ResultIsFizz();
            }

            if (fizzBuzz.IsEvenlyDivisibleBy5())
            {
                if (fizzBuzz.IsResultNull())
                {
                    fizzBuzz.ResultIsBuzz();
                } else
                {
                    fizzBuzz.ResultIsFizzBuzz();
                }
            }

            if (fizzBuzz.ResultIsNullOrEmpty())
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
        public void ResultIsFizz() => _result = "Fizz";
        public void ResultIsBuzz() => _result = "Buzz";
        public void ResultIsFizzBuzz() => _result += "Buzz";
        public void ResultIsInt() => _result = _input.ToString();
        public bool IsEvenlyDivisibleBy3() => _input % 3 == 0;
        public bool IsEvenlyDivisibleBy5() => _input % 5 == 0;
        public bool IsResultNull() => _result == null;
        public bool ResultIsNullOrEmpty() => string.IsNullOrEmpty(_result);
        public bool IsResultEqual(string expected) => _result == expected;
    }

    [TestClass]
    public class NoGetterNoSetterRefactorWalkThroughTests
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
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
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
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
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
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }

        [TestMethod]
        public void ShouldReturnFizzGivenInt6()
        {
            //Arrange
            FizzBuzz fizzBuzz = new FizzBuzz(6);
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
            FizzBuzz fizzBuzz = new FizzBuzz(5);
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
            FizzBuzz fizzBuzz = new FizzBuzz(10);
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
            FizzBuzz fizzBuzz = new FizzBuzz(15);
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
            FizzBuzz fizzBuzz = new FizzBuzz(30);
            string expected = "FizzBuzz";

            //Act
            FizzBuzzUtils.Calculate(fizzBuzz);

            //Assert
            Assert.IsTrue(fizzBuzz.IsResultEqual(expected));
        }
    }
}
