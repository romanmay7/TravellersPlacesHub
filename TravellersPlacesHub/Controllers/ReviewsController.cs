using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersPlacesHub.Models;

namespace TravellersPlacesHub.Controllers
{
    public class ReviewsController : Controller
    {
        TravellersPlacesHubDB _db=new TravellersPlacesHubDB();
        // GET: /Reviews/

        public ActionResult Index([Bind(Prefix="id")]int hotelId)
        {
            var hotel = _db.Hotels.Find(hotelId);
            if (hotel!=null)
            {
              return View(hotel);       
            }
            return HttpNotFound();        
        }
        [HttpGet]
        public ActionResult Create(int hotelId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HotelReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.Id });

            }
            return View(review);
       }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = _db.Reviews.Find(Id);
            return View(model);
        }


        [HttpPost]
       //public ActionResult Edit([Bind(Exclude="ReviewerName")]HotelReview review)
       public ActionResult Edit(HotelReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.Id });

            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }


    }
}
