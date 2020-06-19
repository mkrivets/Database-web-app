using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cats
{
    public partial class City
    {
        public City()
        {
            Cattery = new HashSet<Cattery>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The lenght of the name should be between 2 and 100")]
        public string Name { get; set; }

        public virtual ICollection<Cattery> Cattery { get; set; }
    }
}
