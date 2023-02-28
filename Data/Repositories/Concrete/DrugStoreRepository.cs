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
            DbContext.DrugStores.Add(drugStore);
        }
        public void Update(DrugStore drugStore)
        {
            throw new NotImplementedException();
        }

        public void Delete(DrugStore drugStore)
        {
            DbContext.DrugStores.Remove(drugStore);
        }
    }
}
