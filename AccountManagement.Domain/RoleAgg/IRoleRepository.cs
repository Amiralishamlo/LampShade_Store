﻿using System.Collections.Generic;
using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Role;

namespace AccountManagement.Domain.RoleAgg;

public interface IRoleRepository : IRepository<long, Role>
{
    List<RoleViewModel> List();
    EditRole GetDetails(long id);
    List<int> GetRolePermissions(long id);
}