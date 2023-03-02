using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Owner : BaseEntity
    {
        public Owner()
        {
            Drugstores= new List<DrugStore>();
        }
        public string Surname { get; set; }
        public List<DrugStore> Drugstores { get; set; }
    }
}
