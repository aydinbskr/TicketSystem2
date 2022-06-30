using Core.Entities;


namespace Entities.DTOs
{
    public class SessionDetailDto:IDto
    {
        public int SessionId { get; set; }
        public string MovieName { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
