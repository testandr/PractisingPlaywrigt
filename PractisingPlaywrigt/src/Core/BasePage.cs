using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Core
{
    public abstract class BasePage
    {
        protected readonly IPage Page;
        protected StepLogger Steps { get; }

        protected BasePage(IPage page, StepLogger steps)
        {
            Page = page;
            Steps = steps;
        }
        public async Task NavigateAsync(string url)
        {
            await Steps.RunAsync("Open selected site", async step =>
            {
                await Page.GotoAsync(url);
            });
        }

        public async Task ReloadAsync()
        {
            await Page.ReloadAsync();
        }

        public async Task GoBackAsync()
        {
            await Page.GoBackAsync();
        }

        public string GetCurrentUrl()
        {
            return Page.Url;
        }
    }
}
