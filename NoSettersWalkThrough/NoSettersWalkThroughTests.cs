using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoSettersWalkThrough
{
    [TestClass]
    public class NoSettersWalkThroughTests

    {
        /*
                NoSGetters Refactor Kata Walk Through
        
                This technical practice is to encapsulate behavior around the data and prevent anyone else from setting the data.
                
                STEPS:
                    Change Result from Property to Methods
                    Isolate fizzBuzz.Result = "Fizz"
                    Make ResultIsFizz non-static and move into FizzBuzz
                    Isolate fizzBuzz.Result = "Buzz"
                    Make ResultIsBuzz non-static and move into FizzBuzz
                    Isolate fizzBuzz.Result += "Buzz"
                    Make ResultIsFizzBuzz non-static and move into FizzBuzz
                    Isolate fizzBuzz.Result == fizzBuzz.Input.ToString()
                    Make ResultIsInput non-static and move into FizzBuzz
                    Make SetResult private
                    Inline SetResult
                    
                No More Result Setter
        
                    Change Input from Property to Methods
                    Modify ctor to take an input with default value = 0;
                    update ctor to set incoming value to input
                    update each test individually to pass teh value into the constructor and remove setting it from the test
                    Make SetInput private
                    inline SetInput
        
                No More Input Setter
        
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
}
