using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebdriverSecond.Pages
{
    class LoginPage
    {
        private const string BASE_URL = "https://www.rzd.ru/timetable/logon/ru";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='j_username']")]
        private IWebElement inputLogin;

        [FindsBy(How = How.XPath, Using = "//*[@id='j_password']")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/table/tbody/tr/td/div[2]/form/table/tbody/tr[4]/td[2]/button")]
        private IWebElement buttonSubmit;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        {
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
        }
    }
}
