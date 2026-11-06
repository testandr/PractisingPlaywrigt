using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Flows
{
    public class AuthFlow
    {
        private readonly PageManager Pages;

        public AuthFlow(PageManager pages)
        {
            Pages = pages;
        }
        public async Task LoginAsync(string email, string password)
        {
            await Pages.LoginPage.EnterEmailAsync(email);
            await Pages.LoginPage.EnterPasswordAsync(password);
            await Pages.LoginPage.ClickLoginAsync();
        }
    }
}
