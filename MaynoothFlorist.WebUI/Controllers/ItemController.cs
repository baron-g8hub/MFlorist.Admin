using System.Web.Mvc;
using BusinessLogicLayer;
using MaynoothFlorist.WebUI.ViewModels;
using System;
using MaynoothFlorist.WebUI.AppHelpers;

namespace MaynoothFlorist.WebUI.Controllers
{
    /// <summary>
    /// Author  : Baron Lugtu (Maynooth Florist)
    /// Date    : February 10, 2016 
    /// 
    /// Item Controller - this can be accessed only by authenticated user
    /// </summary>
    [Authorize]
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

        // GET: Item
        public ViewResult Index(string sortOrder)
        {

            var itemList = _mfItem.GetItemList(); //returns IQueryable<MaynoothFloristItem> representing an unknown number of products. a hundreds maybe?

            ViewBag.sortOderValue = sortOrder;

            var viewModel = new ItemListViewModel
            {
                Items = itemList
            };

            return View(viewModel);
        }
    }
}
