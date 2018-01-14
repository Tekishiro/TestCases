using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace WebdriverSecond.Pages
{
    class MainPage
    {
        private const string BASE_URL = "http://www.rzd.ru/";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/a[1]")]
        private IWebElement linkLoggedInUser;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div[2]/div[3]/a[2]/img")]
        private IWebElement linkChangeLanguageToEn;

        [FindsBy(How = How.XPath, Using = "//*[@id='name0']")]
        private IWebElement inputDeparture;

        [FindsBy(How = How.XPath, Using = "//*[@id='name1']")]
        private IWebElement inputDestination;

        [FindsBy(How = How.XPath, Using = "//*[@id='Submit']")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='date0']")]
        private IWebElement inputDate;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Main Page opened");
        }

        public string GetLoggedInUserName()
        {
            return linkLoggedInUser.Text;
        }

        public void ChangeLanguage()
        {
            linkChangeLanguageToEn.Click();
        }

        public bool IsSubmitEnabled()
        {
            return submitButton.Enabled;
        }

        public void FillDepartureAndDestination(string departure, string destination)
        {
            inputDeparture.SendKeys(departure);
            inputDestination.SendKeys(destination);
        }

        public void FillDateWithMinusOffset(int offset)
        {
            ClearDate();

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (day > offset)
            {
                day -= offset;
            }
            else if(day<offset && month > 1)
            {
                offset -= day;
                day = 30 - offset;
                month--;
            }
            else if(day <= offset && month == 1)
            {
                offset -= day;
                day = 30 - offset;
                month = 12;
                year--;
            }

            inputDate.SendKeys(day + "." + month + "." + year);
        }

        public void FillDateWithOffset(int offset)
        {
            ClearDate();

            int day = DateTime.Now.Day + offset;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if(month < 10)
            {
                inputDate.SendKeys(day + ".0" + month + "." + year);
            }
            else
            {
                inputDate.SendKeys(day + "." + month + "." + year);
            }
        }

        public void ClearDate()
        {
            inputDate.Click();
            for (int i = 0; i <= 9; i++)
                inputDate.SendKeys(Keys.Backspace);
        }

        public void Submit()
        {
            if (submitButton.Enabled)
            {
                Console.WriteLine("Submit enabled");
                submitButton.Click();
            }
            else
            {
                Console.WriteLine("Submit not enabled");
            }
        }
    }
}
