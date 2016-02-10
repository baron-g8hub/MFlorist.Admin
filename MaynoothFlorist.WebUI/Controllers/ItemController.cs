using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using MaynoothFlorist.WebUI.ViewModels;
using DataAccessLayer;

namespace MaynoothFlorist.WebUI.Controllers
{
    public class ItemController : Controller
    {
        private readonly MaynoothFloristItem _mfItem = new MaynoothFloristItem();

        private readonly FlowersDbEntities _db = new FlowersDbEntities();

        public int PageSize = 10;

        public ItemController(IRepository repository)
        {
            _mfItem.Repository = repository;
        }

        // GET: Item
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int page = 1)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ItemIDSortParm = string.IsNullOrEmpty(sortOrder) ? "itemid_desc" : "";
            ViewBag.ItemDescSortParm = sortOrder == "ItemDescription" ? "itemdesc_desc" : "ItemDescription";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var itemList = _mfItem.Get(); //returns IQueryable<MaynoothFloristItem> representing an unknown number of products. a thousand maybe?

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    itemList = itemList.Where(s => s.ItemDescription.Contains(searchString));
            //}

            //switch (sortOrder)
            //{
            //    case "itemdesc_desc":
            //        itemList = itemList.OrderByDescending(s => s.ItemDescription);
            //        break;
            //    case "ItemDescription":
            //        itemList = itemList.OrderBy(s => s.ItemDescription);
            //        break;
            //    case "itemid_desc":
            //        itemList = itemList.OrderByDescending(s => s.ItemID);
            //        break;
            //    default:  // Name ascending 
            //        itemList = itemList.OrderBy(s => s.ItemID);
            //        break;
            //}

            ViewBag.sortOderValue = sortOrder;

            var viewModel = new ItemListViewModel
            {
                Items = itemList.Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = itemList.Count()
                }
            };

            return View(viewModel);
        }

    }
}


////var list = _mfItem.Get().ToList();
////return View(_db.Products.ToList());
////return View(_mfItem.Get().ToList());
////return Json(list, JsonRequestBehavior.AllowGet);