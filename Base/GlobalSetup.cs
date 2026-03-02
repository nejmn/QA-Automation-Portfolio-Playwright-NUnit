using Microsoft.Playwright;
using NUnit.Framework;
using QaAutomationPortfolio.Configuration;
namespace QaAutomationPortfolio
{
    [SetUpFixture]
    public class GlobalSetup
    {
        public static IPlaywright Playwright = null!;
        public static IBrowser Browser = null!;

        [OneTimeSetUp]
        public async Task GlobalStart()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(
      new BrowserTypeLaunchOptions
      {
          Headless = ConfigManager.Headless
      });
        }

        [OneTimeTearDown]
        public async Task GlobalStop()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}