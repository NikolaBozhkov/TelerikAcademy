namespace _01.NorthwindDbContext
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EntryPoint
    {
        public static void Main()
        {
            var db = new NorthwindContext();
            
            // Task 2, testing NorthwindDataAccess class
            //NorthwindDataAccess.AddCustomer("Pesho", "Peshov INC.", "104");

            var peshoCustomer = db.Customers.FirstOrDefault(customer => customer.CustomerID == "104");
            NorthwindDataAccess.ChangeCustomerContactName(peshoCustomer.CustomerID, "Pesho INC. Update");

            peshoCustomer = db.Customers.FirstOrDefault(customer => customer.CustomerID == "104");
            Console.WriteLine(peshoCustomer.ContactName + " " + peshoCustomer.CompanyName);

            // Task 3
            Console.WriteLine("\n Task 3(customers): ");
            var specialCustomers = NorthwindDataAccess.CustomersWithOrderFrom1997ToCanada();

            foreach (var customer in specialCustomers)
            {
                Console.WriteLine("{0}, {1}", customer.ContactName, customer.Country);
            }

            // Task 4
            Console.WriteLine("\n Task 4(same as above with native SQL):");

            string sqlQuery = @"SELECT c.ContactName from Customers c" +
                              " INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                              "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

            object[] parameters = { 1997, "Canada" };

            var specialCustomersTask4 = db.Database.SqlQuery<string>(sqlQuery, parameters);
            foreach (var customer in specialCustomersTask4)
            {
                Console.WriteLine("{0}", customer);
            }

            // Task 5
            Console.WriteLine("\n Task 5: ");
            var ordersBc = NorthwindDataAccess.GetAllOrdersByRegionAndPeriod("BC", 1995, 2005);

            foreach (var order in ordersBc)
            {
                Console.WriteLine("{0}, {1}", order.ShipRegion, order.ShippedDate);
            }

            // No time for more : /
        }
    }
}
