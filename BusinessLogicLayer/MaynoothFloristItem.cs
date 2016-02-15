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
        [Required]
        public decimal FlowerId { get; set; }

        [Required]
        public string FlowerName { get; set; }


        public decimal? FlowerPrice { get; set; }


        public string FlowerDescription { get; set; }


        public string FlowerImageUrl { get; set; }


        public IRepository Repository { get; set; }

        /// <summary>
        /// Get the item list from DB and can be queryable
        /// </summary>
        /// <returns></returns>
        public IQueryable<MaynoothFloristItem> GetItemList()
        {
            return Repository.GetItemList();
        }

    }
}
