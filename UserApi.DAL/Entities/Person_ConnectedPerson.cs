using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.DAL.Entities
{
    public class  Person_ConnectedPerson :IDbEntity
    {
        public int ID { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int ConnectedPersonId { get; set; }
        public Person ConnectedPerson { get; set; }

        public int ConnectionType { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
