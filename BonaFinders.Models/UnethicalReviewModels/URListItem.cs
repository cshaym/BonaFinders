using BonaFinders.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.UnethicalReviewModels
{
    public class URListItem
    {
        public int UnethicalReviewId { get; set; }

        public string Id { get; set; }

        // This name doesnt need to match the UnethicalOrganizationName in order to represent it
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Display(Name = "Title")]
        public string UnethicalReviewTitle { get; set; }

        [Display(Name = "Text")]
        public string UnethicalReviewText { get; set; }
    }
}
