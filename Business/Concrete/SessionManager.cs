using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Concrete
{
    public class SessionManager : ISessionService
    {
        ISessionDal _sessionDal;
        IMovieService _movieService;

        public SessionManager(ISessionDal sessionDal, IMovieService movieService)
        {
            _sessionDal = sessionDal;
            _movieService = movieService;
        }
        [SecuredOperation("session.add,admin")]
        [ValidationAspect(typeof(SessionValidator))]
        [CacheRemoveAspect("ISessionService.Get")]//ISessionService deki tüm get ile başlayan metotlardaki cache aspectleri sil
        public IResult Add(Session session)
        {
            IResult result=BusinessRules.Run(CheckSessionCountOfScene(session.SceneId),
                                             CheckIfMovieLimitExceded());
            if(result!=null)
            {
                return result;
            }
            _sessionDal.Add(session);
            return new SuccessResult(Messages.SessionAdded);
        }
        [CacheAspect]
        public IDataResult<List<Session>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Session>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Session>>(_sessionDal.GetAll(),Messages.SessionsListed);
        }
        [CacheAspect]
        public IDataResult<Session> GetById(int id)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(s => s.SessionId == id));
        }

        public IDataResult<List<SessionDetailDto>> GetSessionDetails()
        {
            return new SuccessDataResult<List<SessionDetailDto>>(_sessionDal.GetSessionDetails());
        }
        [ValidationAspect(typeof(SessionValidator))]
        [CacheRemoveAspect("ISessionService.Get")]//ISession service deki tüm get ile başlayan metotlardaki aspectleri sil
        public IResult Update(Session session)
        {
            throw new NotImplementedException();
        }
        private IResult CheckSessionCountOfScene(int sessionId)
        {
            var result = _sessionDal.GetAll(s => s.SceneId == sessionId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.SessionCountOfSceneError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfMovieLimitExceded()
        {
            var result = _movieService.GetAll();
            if(result.Data.Count>15)
            {
                return new ErrorResult(Messages.MovieLimitExceed);
            }
            return new SuccessResult();
        }
    }
}
