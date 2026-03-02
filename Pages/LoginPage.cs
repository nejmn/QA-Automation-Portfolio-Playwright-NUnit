using Microsoft.Playwright;
using System.Threading.Tasks;

namespace QaAutomationPortfolio.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task Navigate()
        {
            await _page.GotoAsync("https://the-internet.herokuapp.com/login");
        }

        public async Task Login(string username, string password)
        {
            await _page.FillAsync("#username", username);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("button[type='submit']");
        }

        public async Task<string> GetFlashMessage()
        {
            return await _page.InnerTextAsync("#flash");
        }
    }
}