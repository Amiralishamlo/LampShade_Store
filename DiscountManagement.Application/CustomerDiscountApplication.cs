using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _repository;

        public CustomerDiscountApplication(ICustomerDiscountRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var opertion = new OperationResult();
            if(_repository.Exists(x=>x.ProductId==command.ProductId&&x.DiscountRate==command.DiscountRate))
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);
            var startTime=command.StartDate.ToGeorgianDateTime();
            var EndTime=command.EndDate.ToGeorgianDateTime();
            var customdsicount = new CustomerDiscount(command.ProductId,command.DiscountRate, startTime, EndTime,command.Reason);
            _repository.Create(customdsicount);
            _repository.SaveChanges();
            return opertion.Succedded();


        }
         
        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation = new OperationResult();
            var customerDiscount = _repository.Get(command.Id);

            if (customerDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_repository.Exists(x => x.ProductId == command.ProductId
            && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            customerDiscount.Edit(command.ProductId, command.DiscountRate, startDate, endDate, command.Reason);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(SearchCustomerDiscount command)
        {
            return _repository.Search(command);
        }
    }
}
