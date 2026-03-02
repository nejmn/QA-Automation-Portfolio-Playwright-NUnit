using NUnit.Framework;
using QaAutomationPortfolio.Base;
using QaAutomationPortfolio.Pages;
using System.Threading.Tasks;

namespace QaAutomationPortfolio.Tests
{
    [Parallelizable(ParallelScope.None)]
    public class CheckboxesTests : TestBase
    {
        private CheckboxesPage _checkboxesPage;

        [SetUp]
        public async Task SetupTest()
        {
            _checkboxesPage = new CheckboxesPage(Page);
            await _checkboxesPage.Navigate();
        }

        [Test]
        [Category("Regression")]
        public async Task Checkbox_Should_Toggle_State()
        {
            bool initialState = await _checkboxesPage.IsCheckboxChecked(1);

            await _checkboxesPage.ToggleCheckbox(1);

            bool newState = await _checkboxesPage.IsCheckboxChecked(1);

            Assert.That(newState, Is.Not.EqualTo(initialState));
        }
    }
}