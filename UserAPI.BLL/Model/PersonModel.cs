using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DAL.Annotations;
using UserAPI.BLL.Enum;

namespace UserAPI.BLL.Model
{
    public class PersonModel
    {
        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [PersonNameValidation(ErrorMessage = "Invalid Firstname")]
        public string Firstname { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [PersonNameValidation(ErrorMessage = "Invalid Lastname")]

        public string Lastname { get; set; }

        public GenderEnum Gender { get; set; }

        [Required]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only Numbers")]
        public string IdNumber { get; set; }

        [Required]

        [PersonAgeValidation(ErrorMessage = "Invalid Age")]
        public DateTime BirthDate { get; set; }


        public int CityId { get; set; }

        public string  CityName { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public PhoneNumTypeEnum PhoneNumberType { get; set; }

        public string ImageLink { get; set; }

        public  List<ConnectedPersonModel> ConnectedPeople { get; set; }
       public DateTime DateCreated { get; set; }
    }
}
