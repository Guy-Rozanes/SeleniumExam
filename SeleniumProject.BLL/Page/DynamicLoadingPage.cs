using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.BLL.Page
{
    public class DynamicLoadingPage
    {
        private DynamicLoadingMap _dynamicLoadingMap;
        private IWebDriver _driver;
        public DynamicLoadingPage(IWebDriver driver)
        {
            _driver = driver;
            _dynamicLoadingMap = new DynamicLoadingMap(driver);
        }

        public string ClickOnStartButton()
        {
            _dynamicLoadingMap.StartButton.Click();
            return _dynamicLoadingMap.MessageTextBox.Text;
        }

        public void HighLightMessageBox()
        {
            var jsDriver = (IJavaScriptExecutor)_driver;
            var element = _dynamicLoadingMap.MessageTextBox;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }


    }
}
