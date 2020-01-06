using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        readonly Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            //waiting for my slow emulator to kick in
            //app.WaitForElement("X", timeout: TimeSpan.FromSeconds(1));
        }

        [Test]
        public void SimpleAdd()
        {
            //Arange
            app.Tap("5");
            app.Tap("ENTER");
            app.Tap("1");
            app.Tap("2");
            app.Tap("ENTER");

            //act
            app.Tap("+");

            //Assert
            var appResult = app.Query("XStackValue").First(result => result.Text == "17");
            Assert.IsTrue(appResult != null, "Test failed because wrong value is displayed.");
        }

        [Test]
        public void SimpleDivide()
        {
            //Arange
            app.Tap("6");
            app.Tap("2");
            app.Tap("5");
            app.Tap("ENTER");
            app.Tap("5");
            app.Tap("ENTER");

            //act
            app.Tap("/");

            //Assert
            var appResult = app.Query("XStackValue").First(result => result.Text == "125");
            Assert.IsTrue(appResult != null, "Test failed because wrong value is displayed.");
        }

        [Test]
        public void SimpleSubtrac()
        {
            //Arange
            app.Tap("5");
            app.Tap("4");
            app.Tap("ENTER");
            app.Tap("1");
            app.Tap("2");
            app.Tap("ENTER");

            //act
            app.Tap("-");

            //Assert
            var appResult = app.Query("XStackValue").First(result => result.Text == "42");
            Assert.IsTrue(appResult != null, "Test failed because wrong value is displayed.");
        }

        [Test]
        public void SimpleMultiply()
        {
            //Arange
            app.Tap("9");
            app.Tap("ENTER");
            app.Tap("4");
            app.Tap("2");
            app.Tap("ENTER");

            //act
            app.Tap("mul1");
            
            //Assert
            var appResult = app.Query("XStackValue").First(result => result.Text == "378");
            Assert.IsTrue(appResult != null, "Test failed because wrong value is displayed.");

        }

        [Test]
        public void Operations1()
        {
            //Arange
            app.Tap("5");
            app.Tap("ENTER");
            app.Tap("3");
            app.Tap("ENTER");
            app.Tap("4");
            app.Tap("ENTER");

            //act
            app.Tap("+");
            app.Tap("mul1");
            app.Tap("2");
            app.Tap("ENTER");
            app.Tap("-");


            //Assert
            var appResult = app.Query("XStackValue").First(result => result.Text == "33");
            Assert.IsTrue(appResult != null, "Test failed because wrong value is displayed.");

        }
    }
}
