using NUnit.Framework.Interfaces;
using PrestashopTesena.Configuration;

namespace PrestashopTesena
{
    public class TestBase : PageTest
    {
        [SetUp]
        public async Task Setup() { await Page.GotoAsync(EshopConfiguration.DomainUrl); }

        [TearDown]
        public async Task TearDown() 
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Error && !Page.IsClosed)
            {
                await Page.ScreenshotAsync(new()
                {
                    Path = Path.Combine("fails", $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH-mm-ss}.png")
                });
            }
        }
    }
}