using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class DrugRepository : IDrugRepository
    {
        static int id;
        public List<Drug> GetAll()
        {
            return DbContext.Drugs;
        }
        
        public Drug Get(int id)
        {
            return DbContext.Drugs.FirstOrDefault(d => d.Id == id);
        }
        
        public void Add(Drug drug)
        {
            id++;
            drug.Id = id;
            DbContext.Drugs.Add(drug);
        }

        public void Update(Drug drug)
        {
            var dbDrugs = DbContext.Drugs.FirstOrDefault(drugs => drugs.Id == drug.Id);
            if (dbDrugs != null)
            {
                drug.Name= dbDrugs.Name;
                drug.Price= dbDrugs.Price;
                drug.Count= dbDrugs.Count;
            }
        }
       
        public void Delete(Drug drug)
        {
            DbContext.Drugs.Remove(drug);
        }

        //public Drug Filter(double price)
        //{
        //    var dbDrugs = DbContext.Drugs.Where< drugs => >


        //}
    }
}
