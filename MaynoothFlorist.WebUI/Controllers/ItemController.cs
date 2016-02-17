using System.Web.Mvc;
using MaynoothFlorist.WebUI.ViewModels;
using BusinessLogicLayer;
using System;
using MaynoothFlorist.WebUI.App_Start;
using MaynoothFlorist.WebUI.AppHelpers;
using System.Linq;
using DataAccessLayer;

namespace MaynoothFlorist.WebUI.Controllers
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist)
    /// Date    : February 16, 2016 
    /// 
    /// Item Controller - this can be accessed only by authenticated user
    /// 
    /// </summary>
    //[Authorize]
    [CustomHandleError]
    [SessionExpireFilter]
    [Serializable]
    public class ItemController : Controller
    {
        private readonly MaynoothFloristItem _mfItem = new MaynoothFloristItem();

        public int PageSize = 10;

        public ItemController(IRepository repository)
        {
            _mfItem.Repository = repository;
        }

        //
        // GET: /Item/
        [NoCache]
        public ViewResult Index(string sortOrder, UserSession session)
        {
                       
            var itemList = _mfItem.GetItemList(); //returns IQueryable<MaynoothFloristItem> representing an unknown number of products. a thousand maybe?

            ViewBag.sortOderValue = sortOrder;

            var viewModel = new ItemListViewModel
            {
                Items = itemList
            };

            return View(viewModel);
        }
    }
}
