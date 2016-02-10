using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist)
    /// Date    : February 9, 2016
    /// 
    /// BLL - Maynooth Florist Item domain object
    /// </summary>
    [Serializable]
    public class MaynoothFloristItem
    {
        
        public decimal FlowerId { get; set; }

        
        public string FlowerName { get; set; }

       
        public decimal? FlowerPrice { get; set; }
        

        public string FlowerDescription { get; set; }

       
        public string FlowerImageUrl { get; set; }
        
        
        public IRepository Repository { get; set; }

        public IQueryable<MaynoothFloristItem> GetItemList()
        {
            return Repository.GetItemList();
        }

        public IEnumerable<MaynoothFloristItem> Get()
        {
            return Repository.Get();
        }
             
        public IList<MaynoothFloristItem> GetFlowersList()
        {
            return Repository.GetFlowersList();
        }
    }
}
