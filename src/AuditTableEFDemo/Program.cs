using System;
using System.Threading.Tasks;

namespace AuditTableEFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeleteCustomers().Wait();
            //EditCustomer().Wait();
            //AddCustomer().Wait();
            Console.WriteLine("Fim");
            Console.ReadLine();
        }

        private static async Task AddCustomer()
        {
            var customer1 = new Customer() { FirstName = "Fabiano", LastName = "Alberto" };
            var customer2 = new Customer() { FirstName = "Priscila", LastName = "Mitui" };

            using (var ctx = new SampleContext())
            {

                ctx.Customers.Add(customer1);
                ctx.Customers.Add(customer2);

                await ctx.SaveChangesAsync();

            }
        }

        private static async Task EditCustomer()
        {

            using (var ctx = new SampleContext())
            {

                var c1 = ctx.Customers.Find(1);
                c1.FirstName = "Change";
                c1.LastName = "Silva";

                await ctx.SaveChangesAsync();

            }
        }

        private static async Task DeleteCustomers()
        {

            using (var ctx = new SampleContext())
            {

                var c1 = ctx.Customers.Find(1);
                var c2 = ctx.Customers.Find(2);

                ctx.Customers.RemoveRange(c1, c2);


                await ctx.SaveChangesAsync();

            }
        }
    }
}
