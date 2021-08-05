using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.BLL.Enum;

namespace UserAPI.BLL.Model
{
    public class ConnectedPersonModel
    {
        public int  PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ConnectionType { get; set; }
    }
}
