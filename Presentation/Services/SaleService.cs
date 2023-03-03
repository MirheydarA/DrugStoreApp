using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class SaleService
    {
        private readonly DrugStoreService _drugStoreService;
        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly DrugService _drugService;
        private readonly DrugRepository _drugRepository;

        public SaleService()
        {
            _drugStoreService= new DrugStoreService();
            _drugStoreRepository = new DrugStoreRepository();
            _drugService= new DrugService();
            _drugRepository= new DrugRepository();
        }

        public void Sale()
        {
            _drugStoreService.GetAll();
            if (_drugStoreRepository.GetAll().Count is 0)
            {
                return;
            }

        }
    }
}
