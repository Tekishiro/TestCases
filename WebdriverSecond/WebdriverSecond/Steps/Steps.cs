using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace WebdriverSecond.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginSite(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
        }

        public bool IsLoggedIn(string userNSn)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return (mainPage.GetLoggedInUserName().Equals(userNSn));
        }

        public void ChangeLanguage()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.ChangeLanguage();
        }

        public bool IsLoginButtonExists()
        {
            Pages.EnMainPage enMainPage = new Pages.EnMainPage(driver);
            return (enMainPage.IsLoginButtonExists());
        }

        public void SearchTicket(string departure, string destination)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FillDepartureAndDestination(departure, destination);
            mainPage.Submit();
        }

        public void SearchTicketWithDate(string departure, string destination, int offset)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FillDepartureAndDestination(departure, destination);
            if(offset < 0)
            {
                mainPage.FillDateWithMinusOffset(-offset);
            }
            else
            {
                mainPage.FillDateWithOffset(offset);
            }
            Console.WriteLine("Information entered");
            Thread.Sleep(500);
            mainPage.Submit();
        }

        public void SetWrongTimeInterval()
        {
            Pages.PassengersPage passengersPage = new Pages.PassengersPage(driver);
            passengersPage.SetWrongTimeInterval();
        }

        public void SetWrongBackTimeInterval()
        {
            Pages.PassengersPage passengersPage = new Pages.PassengersPage(driver);
            passengersPage.SetWrongBackTimeInterval();
        }

        public bool IsSubmitEnabled()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.IsSubmitEnabled();
        }

        public bool IsPassengersSubmitEnabled()
        {
            Pages.PassengersPage passengersPage = new Pages.PassengersPage(driver);
            return passengersPage.IsSubmitEnabled();
        }
    }
}
