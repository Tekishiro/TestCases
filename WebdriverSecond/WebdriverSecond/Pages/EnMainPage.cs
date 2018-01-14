using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebdriverSecond.Pages
{
    class EnMainPage
    {
        private const string BASE_URL = "http://www.eng.rzd.ru/";
        private IWebDriver driver;

        private static string LogInButtonXPath = "/html/body/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/a[2]";

        public EnMainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsLoginButtonExists()
        {
            try
            {
                driver.FindElement(By.XPath(LogInButtonXPath));
                return true;
            }
            catch(NoSuchElementException e)
            {
                System.Console.WriteLine("Login button not exists");
                return false;
            }
        }
    }
}
