using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Data.Entities
{
    public class Tip
    {
        [Key]
        public int TipId { get; set; }

        [Required]
        public Guid Id { get; set; }    
        [ForeignKey(nameof(ApplicationUser))]   
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string Title { get; set; }

        public string Text { get; set; }
    }
}
