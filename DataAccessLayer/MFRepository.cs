using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
namespace DataAccessLayer
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist)
    /// Date    : Februaru 9, 2016 
    /// 
    /// Concrete implementation of IRepository using EntityFramework/SQL Server datastore
    /// </summary>
    public class MFRepository : IRepository
    {
        private readonly FlowersDbEntities _db = new FlowersDbEntities();

        public IQueryable<MaynoothFloristItem> GetItemList()
        {
            var items = (from x in _db.Products
                         select new MaynoothFloristItem
                         {
                             FlowerId = x.Id,
                             FlowerName = x.Name,
                             FlowerPrice = x.Price,
                             FlowerDescription = x.Description,
                             FlowerImageUrl = x.Image
                         });

            return items;

        }

        public IQueryable<MaynoothFloristUser> GetUsers()
        {
            var getUser = (from x in _db.Users
                           select new MaynoothFloristUser
                           {
                               Username = x.Username,
                               Password = x.Password,
                               FirstName = x.Firstname,
                               LastName = x.Lastname,
                               Email = x.Email,
                               RegDate = x.RegDate.ToString()

                           });

            return getUser;
        }
        
        public bool IsItemExist(decimal FlowerId)
        {
            throw new NotImplementedException();
        }

        public bool SaveItem(MaynoothFloristItem item)
        {
            throw new NotImplementedException();
        }


    }
}
