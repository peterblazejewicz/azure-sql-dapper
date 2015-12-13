using System;

namespace AdventureWorks.App.Models
{
    public class Product
    {
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string ProductNumber { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ProductModel Model { get; set; }
    }
}
