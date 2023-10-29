using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace InventoryManagement.Infrastructure.Configuration.Permissions;

public class InventoryPermissionExposer : IPermissionExposer
{
    public Dictionary<string, List<PermissionDto>> Expose()
    {
        return new Dictionary<string, List<PermissionDto>>
        {
            {
                "Inventory", new List<PermissionDto>
                {
                    new(InventoryPermissions.ListInventory, "ListInventory"),
                    new(InventoryPermissions.SearchInventory, "SearchInventory"),
                    new(InventoryPermissions.CreateInventory, "CreateInventory"),
                    new(InventoryPermissions.EditInventory, "EditInventory"),
                    new(InventoryPermissions.Increase, "Increase"),
                    new(InventoryPermissions.Reduce, "Reduce"),
                    new(InventoryPermissions.OperationLog, "OperationLog")
                }
            }
        };
    }
}