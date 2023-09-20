using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slides;
using ShopManagement.Domain.SliderAgg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagement.Application
{
    public class SlideApplication: ISlideApplication
    {
        private readonly ISlideRepository _repository;

        public SlideApplication(ISlideRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var opertion = new OperationResult();
            var slide=new Slide(command.Heading,command.Title,command.Text,command.Picture,command.PictureAlt,command.PictureTitle,command.BtnText);
            _repository.Create(slide);
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var opertion = new OperationResult();
            var slide = _repository.Get(command.Id);
            if (slide == null)
                return opertion.Failed(ApplicationMessages.RecordNotFound);
            slide.Edit(command.Heading, command.Title, command.Text, command.Picture, command.PictureAlt, command.PictureTitle, command.BtnText);
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public EditSlide GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _repository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var opertion = new OperationResult();
            var slide = _repository.Get(id);
            if (slide == null)
                return opertion.Failed(ApplicationMessages.RecordNotFound);
            slide.Remove();
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var opertion = new OperationResult();
            var slide = _repository.Get(id);
            if (slide == null)
                return opertion.Failed(ApplicationMessages.RecordNotFound);
            slide.Restore();
            _repository.SaveChanges();
            return opertion.Succedded();
        }
    }
}
