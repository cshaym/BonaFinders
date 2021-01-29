using BonaFinders.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.UnethicalReviewModels
{
    public class URDetail
    {
        public int UnethicalReviewId { get; set; }

        public string Id { get; set; }

        public int UnethicalOrganizationId { get; set; }

        [Display(Name = "Title")]
        public string UnethicalReviewTitle { get; set; }

        [Display(Name = "Text")]
        public string UnethicalReviewText { get; set; }
    }
}
