using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SessionManager : ISessionService
    {
        ISessionDal _sessionDal;

        public SessionManager(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }

        public IResult Add(Session session)
        {
            if(session.SessionTime<DateTime.Today)
            {
                return new ErrorResult("Session Bugünden önceki tarih olamaz");
            }
            _sessionDal.Add(session);
            return new Result(true,"Session eklendi");
        }

        public List<Session> GetAll()
        {
            throw new NotImplementedException();
        }

        public Session GetById(int id)
        {
            return _sessionDal.Get(s => s.SessionId == id);
        }

        public List<SessionDetailDto> GetSessionDetails()
        {
            return _sessionDal.GetSessionDetails();
        }
    }
}
