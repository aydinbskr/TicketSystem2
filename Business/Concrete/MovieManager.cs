using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieManager:IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll());
        }

        public IDataResult<List<Movie>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(m => m.MovieCategoryId == id));
        }

        public IDataResult<List<Movie>> GetByVisionDate(DateTime min, DateTime max)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(m=>m.MovieVisionDate>=min && m.MovieVisionDate<=max));
        }
    }
}
