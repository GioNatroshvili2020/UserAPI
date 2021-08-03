using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.DTOs
{
    public class CreateCityDto
    {
        [Required]
        public string Name { get; set; }
    }
}
