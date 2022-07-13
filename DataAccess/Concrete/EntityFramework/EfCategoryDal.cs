using Core.DataAccess.EntityFramework;
using DataAccess.Abstact;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Category, DatabaseContext>, ICategoryDal
    {
    }
}
