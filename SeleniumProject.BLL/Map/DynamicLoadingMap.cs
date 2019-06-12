using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.BLL
{
    public class DynamicLoadingMap
    {
        public IWebDriver _driver;
        public DynamicLoadingMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement StartButton => _driver.FindElement(By.CssSelector("#start > button"));

        public IWebElement MessageTextBox => isAjaxComplete("#finish > h4");


        public IWebElement isAjaxComplete(string cssSelector)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(cssSelector)));
        }

    }
}
