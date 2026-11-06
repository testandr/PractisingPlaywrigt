using Microsoft.Playwright;
using PracticingPlaywright.src.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IPage page, StepLogger steps) : base(page, steps)
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
            await Steps.RunAsync("FIll in the Email field", async step =>
            {
                await EmailInput.FillAsync(email);
            });
        }

        public async Task EnterPasswordAsync(string password)
        {
            await Steps.RunAsync("FIll in the Password field", async step =>
            {
                await PasswordInput.FillAsync(password);
            });
        }

        public async Task ClickLoginAsync()
        {
            await Steps.RunAsync("Click the Login button", async step =>
            {
                await LoginButton.ClickAsync();
            });
        }
    }
}
