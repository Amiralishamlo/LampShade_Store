using System.Collections.Generic;
using _0_Framework.Application;

namespace AccountManagement.Application.Contracts.Account;

public interface IAccountApplication
{
    AccountViewModel GetAccountBy(long id);
    OperationResult Register(RegisterAccount command);
    OperationResult Edit(EditAccount command);
    OperationResult ChangePassword(ChangePassword command);
    OperationResult Login(Login command);
    EditAccount GetDetails(long id);
    List<AccountViewModel> Search(AccountSearchModel searchModel);
    void Logout();
    List<AccountViewModel> GetAccounts();
}