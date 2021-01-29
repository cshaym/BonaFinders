using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Data.Entities
{
    public class UnethicalReview
    {
        [Key]
        public int UnethicalReviewId { get; set; }

        [Required]
        public Guid Id { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(UnethicalOrganization))]
        public int UnethicalOrganizationId { get; set; }
        public virtual UnethicalOrganization UnethicalOrganization { get; set; }

        [Required]
        public string UnethicalReviewTitle { get; set; }

        public string UnethicalReviewText { get; set; }
    }
}
