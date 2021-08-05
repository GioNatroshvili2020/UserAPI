using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.BLL.Enum;

namespace UserAPI.BLL.DTOs
{
    public class AddConnectedPersonDto
    {
        public int PersonId { get; set; }
        public ConnectionTypeEnum ConnectionType{ get; set; }
    }
}
