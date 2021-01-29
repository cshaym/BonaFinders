using BonaFinders.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.UnethicalModels
{
    public class UListItem
    {
        public int UnethicalOrganizationId { get; set; }
        public string Id { get; set; }

        [Display(Name = "Name of Organization")]
        public string UnethicalOrganizationName { get; set; }

        [Display(Name = "Is Fast Fashion")]
        public bool FastFashion { get; set; }

        [Display(Name = "Exploitation of Labour")]
        public bool Exploitation { get; set; }

        [Display(Name = "Sweatshop Labour/ Child Labour")]
        public bool Sweatshop { get; set; }

        [Display(Name = "Copyright Infringement/ Stolen Designs")]
        public bool Copyright { get; set; }

        [Display(Name = "Based In")]
        public string UCountry { get; set; }

        [Display(Name = "Needs Improvement")]
        public string UImprove { get; set; }

        [Display(Name = "Review")]
        public virtual ICollection<UnethicalReview> UnethicalReviews { get; set; }
    }
}
