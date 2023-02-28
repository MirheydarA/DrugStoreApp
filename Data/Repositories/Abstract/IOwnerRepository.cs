using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IOwnerRepository 
    {
        
        List<Owner> GetAll();
        Owner Get(int id);
        void Add(Owner owner);
        void Update(Owner owner);
        void Delete(Owner owner);

    }
}
