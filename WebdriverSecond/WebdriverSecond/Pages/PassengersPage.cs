using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebdriverSecond.Pages
{
    class PassengersPage
    {
        private const string BASE_URL = "https://pass.rzd.ru/main-pass/public/ru";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[3]/div/div[2]/div[1]/div[1]/div[1]/div/div[1]/button[1]")]
        private IWebElement buttonChangeDetails;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[3]/div/div[1]/div[1]/div[1]/form/div[1]/div[4]/div/div/div[2]/div/div/div[1]/input")]
        private IWebElement inputIntervalFirst;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[3]/div/div[1]/div[1]/div[1]/form/div[1]/div[4]/div/div/div[2]/div/div/div[2]/input")]
        private IWebElement inputIntervalSecond;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[3]/div/div[1]/div[1]/div[2]/div[3]/form/div[1]/div[1]/div/div[2]/div/div/div[1]/div/div/div[1]/input")]
        private IWebElement inputIntervalFirst2;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[3]/div/div[1]/div[1]/div[2]/div[3]/form/div[1]/div[1]/div/div[2]/div/div/div[1]/div/div/div[2]/input")]
        private IWebElement inputIntervalSecond2;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[3]/div/div[1]/div[1]/div[1]/form/div[2]/div/div[2]/input")]
        private IWebElement submitButton;

        public PassengersPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void SetWrongTimeInterval()
        {
            buttonChangeDetails.Click();
            inputIntervalFirst.SendKeys("15");
            inputIntervalSecond.SendKeys("13");
        }

        public void SetWrongBackTimeInterval()
        {
            buttonChangeDetails.Click();
            inputIntervalFirst.SendKeys("16");
            inputIntervalSecond.SendKeys("20");

            inputIntervalFirst2.SendKeys("3");
            inputIntervalSecond2.SendKeys("11");
        }

        public bool IsSubmitEnabled()
        {
            return submitButton.Enabled;
        }
    }
}
