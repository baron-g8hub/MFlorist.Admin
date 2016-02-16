using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class UserRepository : IUserRepository
    {
        private readonly ProductsDbEntities _db = new ProductsDbEntities();

        public IList<MaynoothFloristUser> GetUsers()
        {
            return (from x in _db.Users
                    select new MaynoothFloristUser
                    {
                        Id = x.Id,
                        UserName = x.Username,
                        PassWord = x.Password,
                        //RegDate = x.RegDate.Date,
                        Email = x.Email,
                        FirstName = x.Firstname,
                        LastName = x.Lastname
                    }).ToList();
        }
    }    
}
