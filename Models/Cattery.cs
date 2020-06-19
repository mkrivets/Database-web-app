using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cats
{
    public partial class Cattery
    {
        public Cattery()
        {
            Cat = new HashSet<Cat>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public int Capacity { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Cat> Cat { get; set; }
    }
}
