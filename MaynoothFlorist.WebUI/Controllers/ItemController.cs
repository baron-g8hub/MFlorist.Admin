using System.Web.Mvc;
using BusinessLogicLayer;
using MaynoothFlorist.WebUI.ViewModels;

namespace MaynoothFlorist.WebUI.Controllers
{
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
