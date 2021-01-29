using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Data.Entities
{
    public class UnethicalOrganization
    {
        [Key]
        public int UnethicalOrganizationId { get; set; }

        public Guid Id { get; set; }    
        [ForeignKey(nameof(ApplicationUser))]   
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
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
        public virtual ICollection<UnethicalReview> UnethicalReviews { get; set; }
    }
}
