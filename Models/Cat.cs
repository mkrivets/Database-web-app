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
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The lenght of the name should be between 2 and 100")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Range(1999,2020,ErrorMessage ="Enter the year from 1999 to 2020 ")]
        public int YearOfBirth { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [RegularExpression(@"female|male", ErrorMessage ="Choose male or female" )]
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
