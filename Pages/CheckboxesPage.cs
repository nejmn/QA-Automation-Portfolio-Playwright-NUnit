using Microsoft.Playwright;
using System.Threading.Tasks;
using QaAutomationPortfolio.Configuration;
namespace QaAutomationPortfolio.Pages
{
    public class CheckboxesPage
    {
        private readonly IPage _page;

        public CheckboxesPage(IPage page)
        {
            _page = page;
        }

        public async Task Navigate()
        {
            await _page.GotoAsync($"{ConfigManager.BaseUrl}/checkboxes");
        }

        public async Task<bool> IsCheckboxChecked(int index)
        {
            return await _page.IsCheckedAsync($"#checkboxes input:nth-of-type({index})");
        }

        public async Task ToggleCheckbox(int index)
        {
            await _page.ClickAsync($"#checkboxes input:nth-of-type({index})");
        }
    }
}