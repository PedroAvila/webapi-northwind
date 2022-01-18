using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Persistencia
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<List<Customer>> GetAll()
        {
            using (var context = new Northwind())
            {
                return await context.Customers.ToListAsync();
            }
        }
    }
}
