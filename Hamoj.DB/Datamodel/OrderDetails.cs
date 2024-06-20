

using System.ComponentModel.DataAnnotations.Schema;

namespace Hamoj.DB.Datamodel;

public class OrderDetails : basemodel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Qty { get; set; }
    public decimal Amount { get; set; }
    public decimal TotalAmounnt { get; set; }
    public int OrderStatus { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order order {  get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product product {  get; set; }


}
