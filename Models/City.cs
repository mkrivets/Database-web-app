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
        public string Name { get; set; }

        public virtual ICollection<Cattery> Cattery { get; set; }
    }
}
