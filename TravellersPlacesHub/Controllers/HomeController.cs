using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersPlacesHub.Models;
using PagedList;
using System.Web.UI;

namespace TravellersPlacesHub.Controllers
{
    public class HomeController : Controller
    {

        TravellersPlacesHubDB _db = new TravellersPlacesHubDB();

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Hotels.Where(h => h.Name.StartsWith(term))
                .Take(10).Select(h => new { label = h.Name });

            return Json(model,JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration=360,VaryByHeader="X-Requested-Width",Location=OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm=null,int page=1)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //    var model = from h in _db.Hotels
            //                orderby h.Reviews.Average(review => review.Rating) descending
            //                select new HotelListViewModel
            //                {
            //                    Id = h.Id,
            //                    Name = h.Name,
            //                    City = h.City,
            //                    Country = h.Country,
            //                    CountOfReviews = h.Reviews.Count()
            //                };
            //    return View(model);
            //
            var model = _db.Hotels.OrderByDescending(h => h.Reviews.Average(review => review.Rating)).
                Where(h => searchTerm==null||h.Name.StartsWith(searchTerm)).Select(
                h => new HotelListViewModel
                          {
                              Id = h.Id,
                              Name = h.Name,
                              City = h.City,
                              Country = h.Country,
                              CountOfReviews = h.Reviews.Count()
                          }).ToPagedList(page,10);

               

            if(Request.IsAjaxRequest())
            {
                return PartialView("_Hotels", model);
            }

            return View(model);

        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            //ViewBag.Location = "Paris,France";
            var model = new AboutModel();
            model.Name = "Traveller's Places Hub";
            model.Location = "London,England";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
