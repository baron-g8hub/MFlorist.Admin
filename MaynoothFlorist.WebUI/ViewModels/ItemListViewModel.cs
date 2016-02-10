using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;
using DataAccessLayer;

namespace MaynoothFlorist.WebUI.ViewModels
{
    public class ItemListViewModel
    {
        public IEnumerable<MaynoothFloristItem> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}