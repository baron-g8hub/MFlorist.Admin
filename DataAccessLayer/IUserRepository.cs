using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist User)
    /// Date    : February 9, 2016 
    /// 
    /// An interface for the data store. This will be implemented based on the scenario using Dependency Injection
    /// 
    /// -----
    /// -------
    /// </summary>

    public interface IUserRepository
    {
        IList<MaynoothFloristUser> GetUsers();
    }
}
