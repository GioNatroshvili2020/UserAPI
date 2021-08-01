using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.Helpers
{
    public interface IDbEntity
    {
        Guid ID { get; set; }

        DateTime DateCreated { get; set; }
        DateTime? DateChanged { get; set; }
        DateTime? DateDeleted { get; set; }
    }
}
