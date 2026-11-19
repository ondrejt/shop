using PrestashopTesena.ObjectModel;

namespace PrestashopTesena.TestPlan
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CartTests : TestBase
    {
        private IndexPage IndexPage;
        private ProductPage ProductPage;
        private CartPage CartPage;

        [SetUp]
        public void CreatePageObjects()
        {
            IndexPage = new(Page);
            ProductPage = new(Page);
            CartPage = new(Page);
        }

        [TestCase("shirt")]
        [TestCase("sweater")]
        public async Task AddProductToCartAndCheckItThereTest(string searchTerm)
        {
            await IndexPage.SearchAsync(searchTerm);

            var productName = (await IndexPage.FirstProductTitle.TextContentAsync())!.Trim();
            var namePrefix = productName.EndsWith("...") ? productName[..^3] : productName;

            await IndexPage.FirstProductLink.ClickAsync();

            await Expect(ProductPage.Body).ToHaveIdAsync("product");
            await Expect(ProductPage.ProductName).ToContainTextAsync(namePrefix);
            var fullProductName = (await ProductPage.ProductName.TextContentAsync())!.Trim();

            await ProductPage.AddToCartAsync();
            await ProductPage.ProceedToCheckoutLink.ClickAsync();

            await Expect(CartPage.Body).ToHaveIdAsync("cart");
            await Expect(CartPage.ProductLink(fullProductName)).ToBeVisibleAsync();

            await CartPage.ContinueShoppingLink.ClickAsync();
            await Expect(IndexPage.CartProductsCount).ToHaveTextAsync("(1)");
            await IndexPage.CartLink.ClickAsync();

            await Expect(CartPage.Body).ToHaveIdAsync("cart");
            await Expect(CartPage.ProductLink(fullProductName)).ToBeVisibleAsync();
        }
    }
}
