using PrestashopTesena.ObjectModel;

namespace PrestashopTesena.TestPlan
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class IndexPageTests : TestBase
    {
        private IndexPage View;
        [SetUp]
        public void CreatePageObject()
        {
            View = new(Page);
        }

        [Test]
        public async Task IndexPageLoadsTest() { }

        [Test]
        public async Task CheckControlsExists()
        {
            await Expect(View.ClothesLink).ToBeVisibleAsync();
            await Expect(View.AccessoriesLink).ToBeVisibleAsync();
            await Expect(View.ArtLink).ToBeVisibleAsync();
            await Expect(View.SignInLink).ToBeVisibleAsync();
            await Expect(View.LanguageDropdown).ToBeVisibleAsync();
            await Expect(View.SearchTextbox).ToBeVisibleAsync();
            await Expect(View.ShoppingCart).ToBeVisibleAsync();
            await Expect(View.ContactUsLink).ToBeVisibleAsync();
            await Expect(View.CarouselPrevious).ToBeVisibleAsync();
            await Expect(View.CarouselNext).ToBeVisibleAsync();
            await Expect(View.FirstProductLink).ToBeVisibleAsync();
        }
    }
}