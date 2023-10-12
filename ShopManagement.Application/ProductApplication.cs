using _0_Framework.Application;
using ShopManagement.Application.Contracts.Products;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _repository; 

        public ProductApplication(IProductRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateProduct create)
        {
            var opertion = new OperationResult();
            var slug=create.Slug.Slugify();
            if(_repository.Exists(x=>x.Name==create.Name))
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);
            var product = new Product(create.Name, create.Code, create.ShortDescription, create.Description, create.Picture, create.PictureAlt, create.PictureTitle, create.CategoryId, slug, create.Keywords, create.MetaDescription);
            _repository.Create(product);
            _repository.SaveChanges();
            return opertion.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _repository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription);

            _repository.SaveChanges();
            return operation.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _repository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}
