using PracticingPlaywright.src.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Flows
{
    public class AuthFlow : BaseFlow
    {
        public AuthFlow(PageManager pages, StepLogger steps): base(pages, steps)
        {
        }

        public Task LoginWithCredentialsAsync(string email, string password)
        {
            return Steps.RunAsync("Login with given user credentials", async step =>
            {
                await Pages.LoginPage.EnterEmailAsync(email);
                await Pages.LoginPage.EnterPasswordAsync(password);
                await Pages.LoginPage.ClickLoginAsync();
            });
        }
    }
}
