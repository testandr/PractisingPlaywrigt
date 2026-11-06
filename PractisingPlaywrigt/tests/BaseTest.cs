using PracticingPlaywright.src;
using PracticingPlaywright.src.Flows;
using PracticingPlaywright.tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Playwright;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using PracticingPlaywright.src.Core;
using System.IO;

namespace PracticingPlaywright.tests
{
    public abstract class BaseTest : IClassFixture<BrowserFixture>, IAsyncLifetime
    {
        private readonly BrowserFixture _fixture;
        protected IBrowserContext Context = null!;
        protected IPage Page = null!;
        protected PageManager Pages = null!;
        protected AuthFlow AuthFlow = null!; 
        protected string BaseUrl => _fixture.Config.BaseUrl;
        private ExtentReports _extent = null!;

        protected StepLogger Steps = null!;
        protected BaseTest(BrowserFixture fixture)
        {
            _fixture = fixture;
        }


        public async ValueTask InitializeAsync()
        {
            // Create report
            var testName = TestContext.Current.Test?.TestDisplayName
                           ?? GetType().Name;

            var reportsDirectory = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Reports"
            );

            Directory.CreateDirectory(reportsDirectory);

            var safeName = string.Join(
                "_",
                testName.Split(Path.GetInvalidFileNameChars())
            );

            var reportPath = Path.Combine(
                reportsDirectory,
                $"{safeName}_{Guid.NewGuid():N}.html"
            );

            var sparkReporter = new ExtentSparkReporter(reportPath);

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);

            var extentTest = _extent.CreateTest(testName);

            Steps = new StepLogger(extentTest);

            // Initialize Playwright
            Context = await _fixture.CreateContextAsync();
            Page = await Context.NewPageAsync();

            Pages = new PageManager(Page, Steps);
            AuthFlow = new AuthFlow(Pages, Steps);
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                if (Context != null)
                    await Context.CloseAsync();
            }
            finally
            {
                _extent?.Flush();
            }
        }


    }
}
