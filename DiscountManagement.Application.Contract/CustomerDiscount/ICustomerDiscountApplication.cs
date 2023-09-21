using _0_Framework.Application;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount command);

        OperationResult Edit(EditCustomerDiscount command);

        List<CustomerDiscountViewModel> Search(SearchCustomerDiscount command);

        EditCustomerDiscount GetDetails(long id);

    }
}
