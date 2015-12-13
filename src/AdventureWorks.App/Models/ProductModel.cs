using System;

namespace AdventureWorks.App.Models
{
    public class ProductModel
    {
        public int ProductModelID { get; set; }
		public string Name { get; set; }
		public string CatalogDescription { get; set; }
		public Guid rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }
    }
}
