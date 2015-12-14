using System;

namespace AdventureWorks.App.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string SalesOrderNumber { get; set; }
        public Guid rowguid { get; set; }
    }
}
