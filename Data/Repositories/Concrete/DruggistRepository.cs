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
    public class DruggistRepository : IDruggistRepository
    {
        static int id;
        public List<Druggist> GetAll()
        {
            return DbContext.Druggists;
        }
        
        public Druggist Get(int id)
        {
            return DbContext.Druggists.FirstOrDefault(d => d.Id == id);
        }
        
        public void Add(Druggist druggist)
        {
            id++;
            druggist.Id = id;
            DbContext.Druggists.Add(druggist);
        }

        public void Update(Druggist druggist)
        {
            var dbDruggist = DbContext.Druggists.FirstOrDefault(druggist=> druggist.Id == id);
            if (dbDruggist != null)
            {
                druggist.Name= dbDruggist.Name;
                druggist.Surname = dbDruggist.Surname;
                druggist.Age = dbDruggist.Age;
                druggist.Experience = dbDruggist.Experience;
                druggist.DrugStore = dbDruggist.DrugStore;
            }
        }
        
        public void Delete(Druggist druggist)
        {
            DbContext.Druggists.Remove(druggist);
        }
    }
}
