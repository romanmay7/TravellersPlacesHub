﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersPlacesHub.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<HotelReview> Reviews { get; set; }
    }
}