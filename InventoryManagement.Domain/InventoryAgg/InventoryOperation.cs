using System;

namespace InventoryManagement.Domain.InventoryAgg;

public class InventoryOperation
{
    protected InventoryOperation()
    {
    }

    public InventoryOperation(bool operation, long count, long operatorId, long currentCount,
        string description, long orderId, long invetoryId)
    {
        Operation = operation;
        Count = count;
        OperatorId = operatorId;
        CurrentCount = currentCount;
        Description = description;
        OrderId = orderId;
        InventoryId = invetoryId;
        OperationDate = DateTime.Now;
    }

    public long Id { get; private set; }
    public bool Operation { get; }
    public long Count { get; }
    public long OperatorId { get; }
    public DateTime OperationDate { get; }
    public long CurrentCount { get; }
    public string Description { get; }
    public long OrderId { get; }
    public long InventoryId { get; }
    public Inventory Inventory { get; private set; }
}