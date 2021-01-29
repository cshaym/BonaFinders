using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonaFinders.Models.TipModels
{
    public class TCreate
    {
        public string Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use 100 or less characters in this field.")]
        public string Title { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(5000, ErrorMessage = "Please use 5000 or less characters in this field.")]
        public string Text { get; set; }
    }
}
