using PracticingPlaywright.src;
using PracticingPlaywright.src.Flows;
using PracticingPlaywright.tests.Fixtures;
using PracticingPlaywright.tests;
using Xunit.v3;

public class LoginTests : BaseTest
{
    public LoginTests(BrowserFixture fixture) : base(fixture)
    {
    }


    [Fact]
    public async Task Login_WithValidCredentials_ShouldOpenDashboard()
    {
        await Steps.RunAsync("Open selected site", async step =>
        {
            await Pages.LoginPage.NavigateAsync($"{BaseUrl}/login");

        });

        await Steps.RunAsync("Auth with user", async step =>
        {
            await AuthFlow.LoginAsync(email: "amiheev+5@urchinsys.com", password: "EM#@YgnHy8");
        });

        await Steps.RunAsync("Check page title", async step =>
        {
            var title = await Page.TitleAsync();

            step.Info($"Page title: {title}");

            Assert.NotEmpty(title);
        });
    }    
}
