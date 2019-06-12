using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.BLL;
using SeleniumProject.BLL.Page;
using System;
using System.Drawing;
using System.IO;

namespace SeleniumProject
{
    [TestClass]
    public class Tests
    {
        private IWebDriver _driver;
        private DynamicLoadingPage _dynamicLoadingPage;

    

        [TestInitialize]
        public void Init()
        {
            _driver = new ChromeDriver(@"../../../");
            _dynamicLoadingPage = new DynamicLoadingPage(_driver);
            _driver.Url = Properties.Resources.WebUrl;
        }

        [TestMethod]
        public void SuccessTest()
        {
            string messsage = _dynamicLoadingPage.ClickOnStartButton();
            Assert.AreEqual(messsage, "Hello World!");
        }

        [TestMethod]
        public void FailTest()
        {
            try
            {
                string messsage = _dynamicLoadingPage.ClickOnStartButton();
                Assert.AreEqual(messsage, "Hey World!");
            }
            catch (AssertFailedException e)
            {
                _dynamicLoadingPage.HighLightMessageBox();
                string date = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                ((ITakesScreenshot)_driver).GetScreenshot()
                    .SaveAsFile($"..\\..\\..\\Failed{date}.png", ScreenshotImageFormat.Png);
                Assert.Fail(e.Message + "Screenshot has been saved screenshots directory");

            }
        }

        [TestCleanup]
        public void TestClean()
        {
            _driver.Close();

        }

    }
}
