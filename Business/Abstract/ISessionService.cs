using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISessionService
    {
        IDataResult<List<Session>> GetAll();

        IDataResult<List<SessionDetailDto>> GetSessionDetails();

        IDataResult<Session> GetById(int id);

        IResult Add(Session session);
    }
}
