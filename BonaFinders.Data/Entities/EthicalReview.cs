using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Data.Entities
{
    public class EthicalReview
    {
        [Key]
        public int EthicalReviewId { get; set; }

        [Required]
        public Guid Id { get; set; }    
        [ForeignKey(nameof(ApplicationUser))]   
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(EthicalOrganization))]
        public int EthicalOrganizationId { get; set; }
        public virtual EthicalOrganization EthicalOrganization { get; set; }

        [Required]
        public string EthicalReviewTitle { get; set; }

        public string EthicalReviewText { get; set; }
    }
}
