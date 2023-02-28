using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public static class DbContext
    {
        static DbContext()
        {
            Owners = new List<Owner>();

            DrugStores= new List<DrugStore>();
        }
        public static List<Owner> Owners { get; set; }
        public static List<DrugStore> DrugStores { get; set; }        
    }
}
