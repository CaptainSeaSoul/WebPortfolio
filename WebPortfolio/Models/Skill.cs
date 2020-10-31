using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortfolio.Models
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Progress { get; set; }
    }
}
