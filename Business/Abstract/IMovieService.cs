using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IDataResult<List<Movie>> GetAllByCategoryId(int id);
        IDataResult<List<Movie>> GetByVisionDate(DateTime min,DateTime max);
        IDataResult<Movie> GetById(int id);

        IResult Add(Movie movie);
        IResult Update(Movie movie);
    }
}
