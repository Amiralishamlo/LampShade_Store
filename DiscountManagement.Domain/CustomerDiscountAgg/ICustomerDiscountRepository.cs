using _0_Framework.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository:IRepository<long,CustomerDiscount>
    {
        List<CustomerDiscountViewModel> Search(SearchCustomerDiscount command);

        EditCustomerDiscount GetDetails(long id);
    }
}
