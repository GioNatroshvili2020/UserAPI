using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.Enum
{
    public enum PhoneNumTypeEnum
    {
        [Description("Mobile -  0")]
        Mobile = 0,
        [Description("Home - 1")]
        Home = 1,
        [Description("Office - 1")]
        Office = 2
    }
}
