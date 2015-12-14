using System.Collections.Generic;

namespace AdventureWorks.App.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        
        public IEnumerable<SalesOrderHeader> Sales { get; set; }
    }
}
