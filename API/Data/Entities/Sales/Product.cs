using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities.Sales;

public class Product
{
	public string Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	
	public ICollection<Order> Orders { get; set; }
}
