using Microsoft.Playwright;

namespace PrestashopTesena.ObjectModel
{
    public class IndexPage(IPage page)
    {
        // All locators use ids, classes or attributes only - texts and aria-labels change with the shop language.
        // Top menu categories are identified by their category id (3 = Clothes, 6 = Accessories, 9 = Art)
        public ILocator ClothesLink => page.Locator("#top-menu > #category-3 > a");
        public ILocator AccessoriesLink => page.Locator("#top-menu > #category-6 > a");
        public ILocator ArtLink => page.Locator("#top-menu > #category-9 > a");
        public ILocator SignInLink => page.Locator(".user-info a");
        public ILocator LanguageDropdown => page.Locator(".language-selector button");
        // <body id="index"> on home page, <body id="search"> on search results page
        public ILocator Body => page.Locator("body");
        public ILocator SearchTextbox => page.Locator("#search_widget input[name='s']");
        public ILocator ShoppingCart => page.Locator("#_desktop_cart .blockcart");
        // Header cart becomes a link only when the cart is not empty
        public ILocator CartLink => page.Locator("#_desktop_cart a");
        public ILocator CartProductsCount => page.Locator("#_desktop_cart .cart-products-count");
        public ILocator ContactUsLink => page.Locator("#contact-link a");
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
