using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoGettersPractice
{
    /*
           No Getters Refactor Kata self directed

           This technical practice is to encapsulate the behavior around the data and prevent anyone else from accessing the data.
       */

    public static class FooBarUtils
    {
        public static void Calculate(FooBar fooBar)
        {
            const int fooValue = 7;
            const int barValue = 9;
            const string fooResult = "Foo";
            const string barResult = "Bar";
            const string resultNotSet = null;

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
        }
    }

    public class FooBar
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
            FooBar fooBar = new FooBar();
            fooBar.Input = 1;
            string expected = "1";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnString2GivenInt2()
        {
            //Arrange
            FooBar fooBar = new FooBar();
            fooBar.Input = 2;
            string expected = "2";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFooGivenInt3()
        {
            //Arrange
            FooBar fooBar = new FooBar();
            fooBar.Input = 7;
            string expected = "Foo";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFooGivenInt6()
        {
            //Arrange
            FooBar fooBar = new FooBar();
            fooBar.Input = 2 * 7;
            string expected = "Foo";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBarGivenInt5()
        {
            //Arrange
            FooBar fooBar = new FooBar();
            fooBar.Input = 9;
            string expected = "Bar";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnBarGivenInt10()
        {
            //Arrange
            FooBar fooBar = new FooBar();
            fooBar.Input = 2 * 9;
            string expected = "Bar";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFooBarGivenInt15()
        {
            //Arrange
            FooBar fooBar = new FooBar();
            fooBar.Input = 7 * 9;
            string expected = "FooBar";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }

        [TestMethod]
        public void ShouldReturnFooBarGivenInt30()
        {
            //Arrange
            FooBar fooBar = new FooBar();
            fooBar.Input = 2 * 7 * 9;
            string expected = "FooBar";

            //Act
            FooBarUtils.Calculate(fooBar);

            //Assert
            Assert.IsTrue(fooBar.Result == expected);
        }
    }
}
