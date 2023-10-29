using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Application.Contracts;

public class PaymentMethod
{
    private PaymentMethod(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public int Id { get; }
    public string Name { get; }
    public string Description { get; }

    public static List<PaymentMethod> GetList()
    {
        return new List<PaymentMethod>
        {
            new(1, "پرداخت اینترنتی",
                "در مدل شما به درگاه پرداخت اینترنتی هدایت شده و درلحظه پرداخت وجه را انجام خواهید داد."),
            new(2, "پرداخت نقدی",
                "در این مدل، ابتدا سفارش ثبت شده و سپس وجه به صورت نقدی در زمان تحویل کالا، دریافت خواهد شد.")
        };
    }

    public static PaymentMethod GetBy(long id)
    {
        return GetList().FirstOrDefault(x => x.Id == id);
    }
}