using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Data.Entities
{
    public class EthicalOrganization
    {
        [Key]
        public int EthicalOrganizationId { get; set; }

        [Required]
        public Guid Id { get; set; }   
        [ForeignKey(nameof(ApplicationUser))] 
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Name of Organization")]
        public string EthicalOrganizationName { get; set; }

        [Display(Name = "Cruelty Free/ Vegan")]
        public bool CrueltyFree { get; set; }

        [Display(Name = "Sustainable/ Eco-friendly")]
        public bool Sustainable { get; set; }

        [Display(Name = "Diverse/ Inclusive")]
        public bool Diverse { get; set; }

        [Display(Name = "Based In")]
        public string ECountry { get; set; }

        [Display(Name = "Needs Improvement")]
        public string EImprove { get; set; }

        public virtual ICollection<EthicalReview> EthicalReviews { get; set; }

    }
}
