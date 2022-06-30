using Core.Entities;


namespace Entities.Concrete
{
    public class Session : IEntity
    {
        public int SessionId { get; set; }
        public int MovieId { get; set; }
        public int SceneId { get; set; }
        public DateTime SessionTime { get; set; }
       
    }
}
