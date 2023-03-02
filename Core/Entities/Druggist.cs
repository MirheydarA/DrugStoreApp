using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Druggist : BaseEntity
    {
        public string Surname { get; set; }
        public byte Age { get; set; }
        public byte Experience { get; set;}
        public DrugStore DrugStore { get; set; }
    }
}
