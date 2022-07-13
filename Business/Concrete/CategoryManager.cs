using Business.Abstract;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            throw new NotImplementedException();
        }
        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetSessionDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
