using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstact
{
    public interface ICustomerDal
    {
        List<Movie> GetAll();
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
    }
}
