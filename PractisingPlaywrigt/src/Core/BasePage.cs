using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingPlaywright.src.Core
{
    public abstract class BasePage
    {
        protected readonly IPage Page;

        protected BasePage(IPage page)
        {
            Page = page;
        }
        public async Task NavigateAsync(string url)
        {
            await Page.GotoAsync(url);
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
