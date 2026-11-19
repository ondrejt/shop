using Microsoft.Playwright;

namespace PrestashopTesena.TestPlan
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class IndexPageTests : TestBase
    {
        [Test]
        public async Task IndexPageLoadsTest() { }

        [Test]
        public async Task CheckControlsExists()
        {
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Clothes" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Accessories" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Art" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = " Sign in" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Language dropdown" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Textbox, new() { Name = "Search" })).ToBeVisibleAsync();
            await Expect(Page.GetByText("shopping_cart")).ToBeVisibleAsync();
            await Expect(Page.Locator("#contact-link").GetByRole(AriaRole.Link, new() { Name = "Contact us" })).ToBeVisibleAsync();

            await Page.Locator("a[aria-label='Předchozí']").HoverAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Předchozí" })).ToBeVisibleAsync();

            await Page.Locator("a[aria-label='Další']").HoverAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Další" })).ToBeVisibleAsync();
            await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Hummingbird printed t-shirt" }).First).ToBeVisibleAsync();
        }
    }
}