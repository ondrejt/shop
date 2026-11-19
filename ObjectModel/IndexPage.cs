using Microsoft.Playwright;

namespace PrestashopTesena.ObjectModel
{
    public class IndexPage(IPage page)
    {
        public ILocator ClothesLink => page.GetByRole(AriaRole.Link, new() { Name = "Clothes" });
        public ILocator AccessoriesLink => page.GetByRole(AriaRole.Link, new() { Name = "Accessories" });
        public ILocator ArtLink => page.GetByRole(AriaRole.Link, new() { Name = "Art" });
        public ILocator SignInLink => page.Locator(".user-info").GetByRole(AriaRole.Link, new() { Name = "Sign in" });
        public ILocator LanguageDropdown => page.GetByRole(AriaRole.Button, new() { Name = "Language dropdown" });
        // <body id="index"> on home page, <body id="search"> on search results page
        public ILocator Body => page.Locator("body");
        public ILocator SearchTextbox => page.GetByRole(AriaRole.Textbox, new() { Name = "Search" });
        public ILocator ShoppingCart => page.GetByText("shopping_cart");
        // Header cart becomes a link only when the cart is not empty
        public ILocator CartLink => page.Locator("#_desktop_cart a");
        public ILocator CartProductsCount => page.Locator("#_desktop_cart .cart-products-count");
        public ILocator ContactUsLink => page.Locator("#contact-link").GetByRole(AriaRole.Link, new() { Name = "Contact us" });
        // First product tile on the page (whatever product it is), located via its clickable thumbnail link
        public ILocator FirstProductLink => page.Locator("article.product-miniature a.product-thumbnail").First;
        public ILocator FirstProductTitle => page.Locator("article.product-miniature .product-title").First;
        public ILocator CarouselPrevious => page.Locator("#carousel a.carousel-control.left");
        public ILocator CarouselNext => page.Locator("#carousel a.carousel-control.right");

        // Types the term into the search box, submits it and waits for the search results page
        public async Task SearchAsync(string searchTerm)
        {
            await SearchTextbox.FillAsync(searchTerm);
            await SearchTextbox.PressAsync("Enter");
            await Assertions.Expect(Body).ToHaveIdAsync("search");
        }
    }
}
