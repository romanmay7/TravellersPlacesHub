using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravellersPlacesHub.Models
{
    public class HotelReview:IValidatableObject
    {
        public int Id { get; set; }
        [Range(1,10)]
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        public int Hotelid { get; set; }
        [Display(Name="User Name")]
        [DisplayFormat(NullDisplayText="Anonymous")]
        public string ReviewerName { get; set; }

        public IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            if(Rating < 2 && ReviewerName.ToLower().StartsWith("roman"))
            {
                yield return new ValidationResult("Sorry,Roman,this is not permitted");
            }
        }

    }
}