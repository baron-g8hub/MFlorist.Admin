using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using DataAccessLayer;
using BusinessLogicLayer;

namespace MaynoothFlorist.WebUI.ViewModels
{
    public class ItemListViewModel
    {
        public IEnumerable<MaynoothFloristItem> Items { get; set; }
        //public PagingInfo PagingInfo { get; set; }
    }
}