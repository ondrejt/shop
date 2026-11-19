using Microsoft.Playwright;

namespace PrestashopTesena.ObjectModel
{
    public class CartPage(IPage page)
    {
        public ILocator Body => page.Locator("body");
        public ILocator ProductLinks => page.Locator(".cart-item .product-line-info a.label");
        public ILocator ContinueShoppingLink => page.Locator(".cart-grid-body > a.label");

        // Link of a specific product in the cart, matched by its name
        public ILocator ProductLink(string productName) => ProductLinks.Filter(new() { HasText = productName });
    }
}
