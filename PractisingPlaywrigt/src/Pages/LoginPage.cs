using Microsoft.Playwright;
using PracticingPlaywright.src.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IPage page) : base(page)
        {
        }

        private ILocator EmailInput =>
            Page.Locator("[name='email']");

        private ILocator PasswordInput =>
            Page.Locator("[name='password']");

        private ILocator LoginButton =>
            Page.GetByTestId("auth-form-log-in-button");

        public async Task EnterEmailAsync(string email)
        {
            await EmailInput.FillAsync(email);
        }

        public async Task EnterPasswordAsync(string password)
        {
            await PasswordInput.FillAsync(password);
        }

        public async Task ClickLoginAsync()
        {
            await LoginButton.ClickAsync();
        }
    }
}
