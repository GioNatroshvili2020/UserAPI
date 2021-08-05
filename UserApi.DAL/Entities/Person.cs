using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DAL.Annotations;

namespace UserApi.DAL.Entities
{
    public class Person :IDbEntity
    {
        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [PersonNameValidation(ErrorMessage ="Invalid Firstname")]
        public string Firstname{ get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [PersonNameValidation(ErrorMessage = "Invalid Lastname")]

        public string Lastname{ get; set; }

        public int Gender { get; set; }

        [Required]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only Numbers")]
        public string IdNumber { get; set; }

        [Required]

        [PersonAgeValidation(ErrorMessage ="Invalid Age")]
        public DateTime BirthDate { get; set; }


        public int? CityId { get; set; }

        public virtual City City { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public int PhoneNumberType { get; set; }

        public string ImageLink { get; set; }
        public virtual List<ConnectedPerson> ConnectedPeople { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }

    }
}
