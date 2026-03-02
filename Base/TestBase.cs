using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace QaAutomationPortfolio.Base
{
    public class TestBase
    {
        protected IBrowserContext Context = null!;
        protected IPage Page = null!;

        [SetUp]
        public async Task Setup()
        {
            Context = await QaAutomationPortfolio.GlobalSetup.Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            foreach (var c in Path.GetInvalidFileNameChars())
            {
                testName = testName.Replace(c, '_');
            }

            try
            {
                if (status == TestStatus.Failed)
                {
                    if (Page != null && !Page.IsClosed)
                    {
                        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);

                        var path = Path.Combine(directory, $"{testName}.png");

                        await Page.ScreenshotAsync(new PageScreenshotOptions
                        {
                            Path = path,
                            FullPage = true
                        });

                        TestContext.AddTestAttachment(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Screenshot failed: {ex.Message}");
            }
            finally
            {
                if (Context != null)
                    await Context.CloseAsync();
            }
        }
    }
}