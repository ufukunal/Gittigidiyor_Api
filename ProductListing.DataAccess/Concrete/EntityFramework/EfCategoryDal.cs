using ProductListining.DataAccess.Abstract;
using ProductListining.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListining.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ProductListiningContext>, ICategoryDal
    {
        
    }
}
