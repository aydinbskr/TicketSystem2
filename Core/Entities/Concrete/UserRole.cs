namespace Core.Entities.Concrete
{
    public class UserRole:IEntity
    {
        public int id { get; set; }
        public int Userid { get; set; }
        public int Roleid { get; set; }
    }
}
