using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities.Sales;

public class Order
{
	public int Id { get; set; }
	public DateTime OrderDate { get; set; }
	
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }
	public string ProductId { get; set; }
	public Product Product { get; set; }
	
	public int Quantity { get; set; }
	public decimal Total { get; set; }
}
