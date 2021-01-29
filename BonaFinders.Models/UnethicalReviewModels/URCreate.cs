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
    public class URCreate
    {
        public int UnethicalReviewId { get; set; }

        public string Id { get; set; }

        [ForeignKey(nameof(UnethicalOrganization))]
        public int UnethicalOrganizationId { get; set; }
        public virtual UnethicalOrganization UnethicalOrganization { get; set; }

        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Please use 50 or less characters in this field.")]
        [Display(Name = "Title")]
        public string UnethicalReviewTitle { get; set; }

        [Display(Name = "Text")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(5000, ErrorMessage = "Please use 5000 or less characters in this field.")]
        public string UnethicalReviewText { get; set; }
    }
}
