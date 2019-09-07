using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellersPlacesHub.Models;

namespace TravellersPlacesHub.Tests.Features
{
    class HotelRater
    {
        private Hotel test_data;

        public HotelRater(Hotel test_data)
        {
            // TODO: Complete member initialization
            this.test_data = test_data;
        }

        public RatingResult ComputeRate(int p)
        {
            var result= new RatingResult();
            result.Rating = 4;
            return result;
        }
    }
}
