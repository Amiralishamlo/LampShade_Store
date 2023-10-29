using System.Collections.Generic;
using _0_Framework.Application;

namespace DiscountManagement.Application.Contract.CustomerDiscount;

public interface ICustomerDiscountApplication
{
    OperationResult Define(DefineCustomerDiscount command);
    OperationResult Edit(EditCustoemrDiscount command);
    EditCustoemrDiscount GetDetails(long id);
    List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
}