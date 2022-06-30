
using Core.Entities;

namespace Entities.Concrete
{
    public class Movie:IEntity
    {
        public int MovieId { get; set; }
        public int EmployeeId { get; set; }
        public string MovieName { get; set; }
        public DateTime MovieVisionDate { get; set; }
  
        public int MovieCategoryId { get; set; }
       
        public string? MovieReview { get; set; }
        
    }
}
