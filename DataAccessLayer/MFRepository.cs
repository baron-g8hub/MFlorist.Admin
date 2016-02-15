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
    /// Date    : February 9, 2016 
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

        public bool IsItemExist(decimal FlowerId)
        {
            throw new NotImplementedException();
        }

        public bool SaveItem(MaynoothFloristItem item)
        {
            throw new NotImplementedException();
        }


        public int LogError(string dataAreaID, decimal severityID, string statusCode, string errorMessage, string userID, DateTime logDateTime)
        {
            //var error = new P_ERROR
            //{
            //    DTA_AREA_ID = dataAreaID,
            //    SVRTY_NBR = severityID,
            //    STAT_CD = statusCode,
            //    ERR_TXT = errorMessage,
            //    CRE8_UID = userID,
            //    LST_UPDT_UID = userID,
            //    CRE8_TS = logDateTime,
            //    LST_UPDT_TS = logDateTime,
            //    DEVIC_NM = "FGT-Admin"
            //};

            //_db.tErrors.Add(error);
            //_db.SaveChanges();

            //return error.AUTO_GEN_ID; ;
            throw new NotImplementedException();
        }

        public bool IsUserExist(MaynoothFloristUser user, string userName, string passWord)
        {

           var userExist = _db.Users.Where(x => x.Username == userName && x.Password == passWord).FirstOrDefault();
            
            if (userExist != null)
            {
                user.FirstName = userExist.Firstname;
                user.LastName = userExist.Lastname;
              
                return true;
            }

            return false;
        }

       
    }
}

