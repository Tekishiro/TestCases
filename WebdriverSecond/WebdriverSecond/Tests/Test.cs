using NUnit.Framework;

namespace WebdriverSecond.Tests
{
    [TestFixture]
    class Test
    {
        private Steps.Steps steps = new Steps.Steps();
        private static string username = "TestingLogin";
        private static string password = "OFZtW";
        private static string userNSn = "Антон Косинский";
        private static string defaultDeparture = "МИНСК";
        private static string defaultDestination = "МОСКВА";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void OneCanLoginSite()
        {
            steps.LoginSite(username, password);
            Assert.True(steps.IsLoggedIn(userNSn));
        }

        [Test]
        public void OneCanChangeLanguageAndLogin()
        {
            steps.ChangeLanguage();
            Assert.AreEqual(false, steps.IsLoginButtonExists());
        }

        [Test]
        public void EmptyDepartureAndDestination()
        {
            steps.SearchTicket(string.Empty, string.Empty);
            Assert.AreEqual(false, steps.IsSubmitEnabled());
        }

        [Test]
        public void MatchingDepartureAndDestination()
        {
            steps.SearchTicket(defaultDeparture, defaultDeparture);
            Assert.AreEqual(false, steps.IsSubmitEnabled());
        }

        [Test]
        public void WrongDate()
        {
            steps.SearchTicketWithDate(defaultDeparture, defaultDestination, -2);
            Assert.AreEqual(false, steps.IsSubmitEnabled());
        }

        [Test]
        public void WrongTimeInterval()
        {
            steps.LoginSite(username, password);
            steps.SearchTicketWithDate(defaultDeparture, defaultDestination, 2);
            steps.SetWrongTimeInterval();
            Assert.AreEqual(false, steps.IsPassengersSubmitEnabled());
        }

        [Test]
        public void BackTicketInPast()
        {
            steps.LoginSite(username, password);
            steps.SearchTicketWithDate(defaultDeparture, defaultDestination, 2);
            steps.SetWrongBackTimeInterval();
            Assert.AreEqual(true, steps.IsPassengersSubmitEnabled());
        }
    }
}
