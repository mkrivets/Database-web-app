using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cats
{
    public partial class CatTemper
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Display(Name = "Cat")]
        public int CatId { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Display(Name = "Temper")]
        public int TemperId { get; set; }

        public virtual Cat Cat { get; set; }
        public virtual Temper Temper { get; set; }
    }
}
