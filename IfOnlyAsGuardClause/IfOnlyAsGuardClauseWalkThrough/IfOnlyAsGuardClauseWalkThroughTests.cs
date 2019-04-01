using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfOnlyAsGuardClauseWalkThrough
{
    /*
        If Only As a Guard Clause Refactor Kata Walk Through

        This technical practice is to practice transformation for reshaping the method to not have internal branching.

        First thing is to remove nested ifs
        include the outer if condition with each of the inner branches
        remove the outer if
        THINK ABOUT IT: What do the previously nested if's mean?
        replace fizzbuzz.Result == null with fizzBuzz.Input % 3 != 0 - we want to hit this if we aren't divisible by 3
        Add fizzBuzz.Input % 3 == 0 to the else if block
        remove the 'else' keyword to have every if evaluated
        Replace += "Buzz" with = "FizzBuzz"
        Move the "FizzBuzz" branch before the previous if block
        Again, Move the "FizzBuzz" branch before the previous if block
        add a 'return' statement at the end of the first if block
        add a 'return' statement at the end of the second if block
        Remove the %3!=0 condition
        add a 'return' statement at the end of the third if block
        remove the if block around fizzBuzz.Input.ToString()

        All conditions are guard clauses
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
                } else
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
    public class IfOnlyAsGuardClauseWalkThroughTests
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
