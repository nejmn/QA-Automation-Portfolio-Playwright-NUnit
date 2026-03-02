using NUnit.Framework;
using QaAutomationPortfolio.Base;
using QaAutomationPortfolio.Pages;
using System.Threading.Tasks;

namespace QaAutomationPortfolio.Tests
{
    [Parallelizable(ParallelScope.None)]
    public class LoginTests : TestBase
    {
        private LoginPage _loginPage;

        [SetUp]
        public async Task TestSetup()
        {
            _loginPage = new LoginPage(Page);
            await _loginPage.Navigate();
        }

        // 🔹 DATA-DRIVEN LOGIN TEST
        [TestCase("tomsmith", "SuperSecretPassword!", true)]
        [TestCase("wrong", "wrong", false)]
        [TestCase("tomsmith", "", false)]
        [TestCase("", "SuperSecretPassword!", false)]
        [Category("Regression")]
        public async Task Login_Should_Behave_As_Expected(string username, string password, bool shouldSucceed)
        {
            await _loginPage.Login(username, password);
            var message = await _loginPage.GetFlashMessage();

            if (shouldSucceed)
                Assert.That(message, Does.Contain("You logged into a secure area!"));
            else
                Assert.That(message, Does.Contain("invalid"));
        }

        [Test, Category("Smoke")]
        public async Task LoginPage_Should_DisplayRequiredElements()
        {
            Assert.That(await Page.IsVisibleAsync("#username"), Is.True);
            Assert.That(await Page.IsVisibleAsync("#password"), Is.True);
            Assert.That(await Page.IsVisibleAsync("button[type='submit']"), Is.True);
        }

        [Test, Category("Regression")]
        public async Task Logout_Should_RedirectToLogin()
        {
            await _loginPage.Login("tomsmith", "SuperSecretPassword!");
            await Page.ClickAsync("a[href='/logout']");

            Assert.That(Page.Url, Does.Contain("/login"));
        }
    }
}