namespace _01.NorthwindDbContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class NorthwindDataAccess
    {
        private static NorthwindContext db = new NorthwindContext();

        public static void AddCustomer(string name, string companyName, string id)
        {
            var customer = new Customer()
            {
                CompanyName = companyName,
                ContactName = name,
                CustomerID = id
            };

            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public static void ChangeCustomerContactName(string id, string newContactName)
        {
            var customerToEdit = db.Customers.FirstOrDefault(customer => customer.CustomerID == id);

            if (customerToEdit != null)
            {
                customerToEdit.ContactName = newContactName;
                db.SaveChanges();
            }
        }

        public static void DeleteCustomer(string id)
        {
            var customerToDelete = db.Customers.FirstOrDefault(customer => customer.CustomerID == id);

            db.Customers.Remove(customerToDelete);
            db.SaveChanges();
        }

        // Task 3
        public static IQueryable<Customer> CustomersWithOrderFrom1997ToCanada()
        {
            var resultCustomers = db.Customers.Where(
                customer => customer.Orders.Any(
                    order => order.OrderDate.Value.Year == 1997
                    && order.ShipCountry == "Canada"));

            return resultCustomers;
        }

        // Task 5
        public static IQueryable<Order> GetAllOrdersByRegionAndPeriod(string region, int startYear, int endYear)
        {
            var resultOrders = db.Orders.Where(
                order => order.ShipRegion == region
                && order.ShippedDate.Value.Year >= startYear
                && order.ShippedDate.Value.Year <= endYear);

            return resultOrders;
        }
    }
}
