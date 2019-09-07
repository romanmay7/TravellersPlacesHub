using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravellersPlacesHub.Models;
using System.Collections.Generic;

namespace TravellersPlacesHub.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test_data = new Hotel();
            test_data.Reviews = new List<HotelReview>();
            test_data.Reviews.Add(new HotelReview() { Rating = 4 });

            var rater = new HotelRater(test_data);
            var result = rater.ComputeRate(10);

            Assert.AreEqual(4, result.Rating);
        }
    }
}
