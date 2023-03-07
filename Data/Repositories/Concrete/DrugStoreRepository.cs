using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class DrugStoreRepository : IDrugStoreRepository
    {
        static int id;
        public List<DrugStore> GetAll()
        {
            return DbContext.DrugStores;
        }
        public DrugStore Get(int id)
        {
            return DbContext.DrugStores.FirstOrDefault(d => d.Id == id);
        }
        public void Add(DrugStore drugStore)
        {
            id++;
            drugStore.Id = id;
            DbContext.DrugStores.Add(drugStore);
        }
        public void Update(DrugStore drugStore)
        {
            var dbDrugStore = DbContext.DrugStores.FirstOrDefault(dr => dr.Id == drugStore.Id);
            if (dbDrugStore != null)
            {
                dbDrugStore.Name= drugStore.Name;
                dbDrugStore.ContactNumber= drugStore.ContactNumber;
                dbDrugStore.Address= drugStore.Address;
                dbDrugStore.Owner= drugStore.Owner;
                dbDrugStore.Email= drugStore.Email;
            }
        }

        public void Delete(DrugStore drugStore)
        {
            DbContext.DrugStores.Remove(drugStore);
        }
        public bool IsDuplicatedEmail(string email)
        {
            return DbContext.DrugStores.Any(d => d.Email == email);
        }
    }
}
