using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.DTOs
{
    public class PersonReadDto
    {
        public int ID { get; set; }

      
        public string Firstname { get; set; }


        public string Lastname { get; set; }

        public string Gender { get; set; }

      
        public string IdNumber { get; set; }

        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberType { get; set; }

        public string ImageLink { get; set; }

        public List<PersonReadDto> ConnectedPeople { get; set; }
    }
}
