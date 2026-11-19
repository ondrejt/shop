using Microsoft.Playwright;

namespace PrestashopTesena.ObjectModel
{
    public class ProductPage(IPage page)
    {
        // PrestaShop sets <body id="product"> on product detail pages
        public ILocator Body => page.Locator("body");
        public ILocator ProductName => page.Locator("h1.h1");
        public ILocator AddToCartButton => page.Locator("button[data-button-action='add-to-cart']");

        // Confirmation modal shown after adding a product to the cart
        public ILocator CartModal => page.Locator("#blockcart-modal");
        public ILocator ProceedToCheckoutLink => CartModal.Locator(".cart-content-btn a.btn-primary");

        // Clicks "Add to cart" and waits for the confirmation modal.
        // The page must be fully loaded first - otherwise PrestaShop's JS is not attached yet,
        // the form is submitted natively and the browser lands on an empty cart page.
        public async Task AddToCartAsync()
        {
            await page.WaitForLoadStateAsync(LoadState.Load);
            await AddToCartButton.ClickAsync();
            await Assertions.Expect(CartModal).ToBeVisibleAsync();
        }
    }
}
