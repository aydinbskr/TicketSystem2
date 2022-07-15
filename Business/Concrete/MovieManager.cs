using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Caching;
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

        [SecuredOperation("movie.add,admin")]
        public IResult Add(Movie movie)
        {
            _movieDal.Add(movie);
            return new SuccessResult(Messages.MovieAdded);
        }

        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll());
        }

        public IDataResult<List<Movie>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(m => m.MovieCategoryId == id));
        }
        [CacheAspect]
        public IDataResult<Movie> GetById(int id)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(m => m.MovieId == id));
        }

        public IDataResult<List<Movie>> GetByVisionDate(DateTime min, DateTime max)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(m=>m.MovieVisionDate>=min && m.MovieVisionDate<=max));
        }

        public IResult Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
