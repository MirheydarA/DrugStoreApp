using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DrugStore : BaseEntity
    {
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        public string Email { get; set; }
        //public List<Druggists> Druggists { get; set; }
        //public List<Drugs> Drugs { get; set; }
        public Owner Owner { get; set; }
    }
}
