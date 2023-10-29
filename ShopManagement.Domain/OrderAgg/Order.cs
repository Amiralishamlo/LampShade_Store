using System.Collections.Generic;
using _0_Framework.Domain;

namespace ShopManagement.Domain.OrderAgg;

public class Order : EntityBase
{
    public Order(long accountId, int paymentMethod, double totalAmount, double discountAmount, double payAmount)
    {
        AccountId = accountId;
        TotalAmount = totalAmount;
        DiscountAmount = discountAmount;
        PayAmount = payAmount;
        PaymentMethod = paymentMethod;
        IsPaid = false;
        IsCanceled = false;
        RefId = 0;
        Items = new List<OrderItem>();
    }

    protected Order()
    {
    }

    public long AccountId { get; }
    public int PaymentMethod { get; }
    public double TotalAmount { get; }
    public double DiscountAmount { get; }
    public double PayAmount { get; }
    public bool IsPaid { get; private set; }
    public bool IsCanceled { get; private set; }
    public string IssueTrackingNo { get; private set; }
    public long RefId { get; private set; }
    public List<OrderItem> Items { get; }

    public void PaymentSucceeded(long refId)
    {
        IsPaid = true;

        if (refId != 0)
            RefId = refId;
    }

    public void Cancel()
    {
        IsCanceled = true;
    }

    public void SetIssueTrackingNo(string number)
    {
        IssueTrackingNo = number;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }
}