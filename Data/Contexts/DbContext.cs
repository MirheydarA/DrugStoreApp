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

            DrugStores = new List<DrugStore>();

            Druggists = new List<Druggist>();
            
            Drugs = new List<Drug>();

            Admins= new List<Admin>();
        }
        public static List<Owner> Owners { get; set; }
        public static List<DrugStore> DrugStores { get; set; }
        public static List<Druggist> Druggists{ get; set; }
        public static List<Drug> Drugs{ get; set; }
        public static List<Admin> Admins { get; set; }
    }
}
