namespace TravellersPlacesHub.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using TravellersPlacesHub.Models;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<TravellersPlacesHub.Models.TravellersPlacesHubDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TravellersPlacesHub.Models.TravellersPlacesHubDB context)
        {
            context.Hotels.AddOrUpdate(h => h.Name,
              new Hotel { Name = "Meridian", City = "Toronto", Country = "Canada" },
              new Hotel { Name = "White Orchid", City = "Paris", Country = "France" },
              new Hotel
              {
                  Name = "Sunny Inn",
                  City = "Melburn",
                  Country = "Australia",
                  Reviews = new List<HotelReview> { new HotelReview{Rating=7,Body="Good Service!Nice Food"}
              }

              });

            for (int i = 0; i < 1000; i++)
            {
                context.Hotels.AddOrUpdate(h => h.Name, new Hotel { Name = i.ToString(), City = "Somewhere", Country = "Canada" });
            }

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if(membership.GetUser("roman-admin",false)==null)
            {
                membership.CreateUserAndAccount("roman-admin", "1234567");
            }
            if(!roles.GetRolesForUser("roman-admin").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "roman-admin" }, new[] {"admin"});
            }
        }


    }
}
