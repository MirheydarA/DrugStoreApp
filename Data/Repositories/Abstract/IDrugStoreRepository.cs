using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IDrugStoreRepository
    {
        List<DrugStore> GetAll();
        DrugStore DrugStoreGetById(int id);
        void Add(DrugStore drugStore);
        void Update(DrugStore drugStore);
        void Delete(DrugStore drugStore);
    }
}
