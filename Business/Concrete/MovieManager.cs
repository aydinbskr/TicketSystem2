using Business.Abstract;
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

        public List<Movie> GetAll()
        {
            return _movieDal.GetAll();
        }

        public List<Movie> GetAllByCategoryId(int id)
        {
            return _movieDal.GetAll(m => m.MovieCategoryId == id);
        }

        public List<Movie> GetByVisionDate(DateTime min, DateTime max)
        {
            return _movieDal.GetAll(m=>m.MovieVisionDate>=min && m.MovieVisionDate<=max);
        }
    }
}
