using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravellersPlacesHub.Models
{
    public class TravellersPlacesHubDB:DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelReview> Reviews { get; set; }

    }
}