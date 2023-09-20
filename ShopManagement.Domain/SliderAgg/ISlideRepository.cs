using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Slides;

namespace ShopManagement.Domain.SliderAgg
{
    public  interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
