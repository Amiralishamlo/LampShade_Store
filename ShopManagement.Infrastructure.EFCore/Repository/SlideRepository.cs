using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slides;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository:RepositoryBase<long,Slide>,ISlideRepository
    {
        private readonly ShopContext _shopContext;

        public SlideRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditSlide GetDetails(long id)
        {
            return _shopContext.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title=x.Title,
                Link=x.Link,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _shopContext.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                Picture = x.Picture,
                Title = x.Title,
                IsRemoved = x.IsRemove,
                CreationDate = x.CreationDate.ToString(),
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
