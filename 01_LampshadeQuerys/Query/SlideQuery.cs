using _01_LampshadeQuerys.Contract.Slide;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuerys.Query
{
    public class SlideQuery:ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides.Where(x=>x.IsRemove==false).Select(s => new SlideQueryModel
            {
                Title = s.Title,
                BtnText = s.BtnText,
                Heading = s.Heading,
                Link = s.Link,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Text = s.Text
            }).ToList();
        }
    }
}
