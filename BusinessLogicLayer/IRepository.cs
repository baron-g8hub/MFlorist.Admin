using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist Item)
    /// Date    : February 9, 2016 
    /// 
    /// An interface for the data store. This will be implemented based on the scenario using Dependency Injection
    /// 
    /// Scenario 1: Unit Tests - No need actual connection to datastore or database
    /// Scenario 2: Actual usage of Database or datastore
    /// </summary>
    public interface IRepository
    {
        IQueryable<MaynoothFloristItem> GetItemList();
             
        bool SaveItem(MaynoothFloristItem item);
        bool IsItemExist(decimal FlowerId);
    }
}
