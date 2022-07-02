using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(SessionValidator))]
        public IResult Add(Session session)
        {

            
            _sessionDal.Add(session);
            return new SuccessResult(Messages.SessionAdded);
        }

        public IDataResult<List<Session>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Session>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Session>>(_sessionDal.GetAll(),Messages.SessionsListed);
        }

        public IDataResult<Session> GetById(int id)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(s => s.SessionId == id));
        }

        public IDataResult<List<SessionDetailDto>> GetSessionDetails()
        {
            return new SuccessDataResult<List<SessionDetailDto>>(_sessionDal.GetSessionDetails());
        }
    }
}
