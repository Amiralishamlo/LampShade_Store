using _01_LampshadeQuery.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext context;
        public List<SlideQueryModel> GetSlides()
        {
            throw new NotImplementedException();
        }
    }
}
