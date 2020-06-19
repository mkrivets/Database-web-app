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
        public string Name { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public string Info { get; set; }

        public virtual ICollection<CatTemper> CatTemper { get; set; }
    }
}
