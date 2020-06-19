using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cats
{
    public partial class Temper
    {
        public Temper()
        {
            CatTemper = new HashSet<CatTemper>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The lenght of the name should be between 2 and 100")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "The lenght of the name should be between 2 and 200")]
        public string Info { get; set; }

        public virtual ICollection<CatTemper> CatTemper { get; set; }
    }
}
