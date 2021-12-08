using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Persistencia
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<List<CategoryExtend>> GetAll()
        {
            using (var context = new Northwind())
            {
                var result = from c in context.Categories
                             select new CategoryExtend()
                             {
                                 CategoryID = c.CategoryID,
                                 CategoryName = c.CategoryName,
                                 Description = c.Description
                             };

                return await result.ToListAsync();
            }
        }

        public async Task<Category> Single(int id)
        {
            using (var context = new Northwind())
            {
                //return await context.Categories.FindAsync(id);
                return await context.Categories.FirstOrDefaultAsync(x => x.CategoryID == id);
            }
        }
    }
}
