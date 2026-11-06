using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PracticingPlaywright.src.Configuration;


namespace PracticingPlaywright.tests.Fixtures
{
    public class BrowserFixture : IAsyncLifetime
    {
        public IPlaywright Playwright { get; private set; } = null!;
        public IBrowser Browser { get; private set; } = null!;

        public AppConfig Config { get; private set; } = null!;

        public async ValueTask InitializeAsync()
        {
            // Load configuration
            Config = ConfigurationLoader.Load();

            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Channel = "chrome",
                    Headless = Config.Headless,
                    Args = new[]
                    {
                        "--start-maximized"
                    }
                });
        }

        public async Task<IBrowserContext> CreateContextAsync()
        {
            return await Browser.NewContextAsync(
                new BrowserNewContextOptions
                {
                    ViewportSize = ViewportSize.NoViewport
                });
        }

        public async ValueTask DisposeAsync()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}
