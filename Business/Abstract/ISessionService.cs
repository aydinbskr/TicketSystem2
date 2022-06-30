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
        List<Session> GetAll();
  
        List<SessionDetailDto> GetSessionDetails();

        Session GetById(int id);

        void Add(Session session);
    }
}
