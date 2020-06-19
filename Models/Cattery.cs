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
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The lenght of the name should be between 2 and 100")]
        public string Name { get; set; }

        [StringLength(200, MinimumLength = 2, ErrorMessage = "The lenght of the name should be between 2 and 200")]
        [Required(ErrorMessage = "This field can't be empty")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]

        [Range(1, 2000, ErrorMessage = "Enter the capacity from 1 to 2000 ")]

        public int Capacity { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Cat> Cat { get; set; }
    }
}
