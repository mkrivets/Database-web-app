using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cats
{
    public partial class Cat
    {
        public Cat()
        {
            CatTemper = new HashSet<CatTemper>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public int YearOfBirth { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Display(Name = "Breed")]
        public int BreedId { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Display(Name = "Cattery")]
        public int CatteryId { get; set; }

        public virtual Breed Breed { get; set; }
        public virtual Cattery Cattery { get; set; }
        public virtual ICollection<CatTemper> CatTemper { get; set; }
    }
}
