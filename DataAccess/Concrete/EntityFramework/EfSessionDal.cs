using DataAccess.Abstact;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSessionDal : EfRepositoryBase<Session, DatabaseContext>, ISessionDal
    {
        public List<SessionDetailDto> GetSessionDetails()
        {
            using(DatabaseContext context=new DatabaseContext())
            {
                var result = from s in context.Sessions
                             join m in context.Movies
                             on s.MovieId equals m.MovieId
                             select new SessionDetailDto
                             {
                                 SessionId = s.SessionId,
                                 MovieName = m.MovieName,
                                 SessionTime = s.SessionTime
                             };
                return result.ToList();
            }
            
        }
    }
}
