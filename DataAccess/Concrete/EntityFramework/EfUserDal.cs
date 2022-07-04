using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, DatabaseContext>, IUserDal
    {
        public List<Role> GetRoles(User user)
        {
            using (var context = new DatabaseContext())
            {
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                             on role.id equals userRole.id
                             where userRole.Userid == user.id
                             select new Role { id = role.id, Name = role.Name };
                return result.ToList();

            }
        }
    }
}
