

using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategorys;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication:IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryApplication(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var opertion = new OperationResult();
            var slug= command.Slug.Slugify();
            if (_repository.Exists(x=>x.Name==command.Name))
                return opertion.Failed(ApplicationMessages.RecordNotFound);
            var productCategory = new ProductCategory(command.Name,command.Description,command.Picture,
                command.PictureAlt,command.PictureTitle,command.Keywords,command.MetaDescription,slug);
            _repository.Create(productCategory);
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _repository.Get(command.Id);

            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, slug);

            _repository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategorys()
        {
            return _repository.GetProductCategorys();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel seachModel)
        {
            return _repository.Search(seachModel);
        }
    }
}
