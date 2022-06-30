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
        List<Movie> GetAll();
        List<Movie> GetAllByCategoryId(int id);
        List<Movie> GetByVisionDate(DateTime min,DateTime max);
    }
}
