using Core.Helpers;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class DrugService
    {
        private readonly DruggistService _druggistService;
        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly DrugStoreService _drugStoreService;
        private readonly DrugRepository _drugRepository;
        public DrugService()
        {
            _druggistService= new DruggistService();
            _drugStoreRepository= new DrugStoreRepository();
            _drugStoreService = new DrugStoreService();
            _drugRepository= new DrugRepository();
        }
        public void Create()
        {
            if (_drugStoreRepository.GetAll().Count is 0) 
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first");
            }
            ConsoleHelper.WriteWithColor("Enter Drug name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            EnterPrice: ConsoleHelper.WriteWithColor("Enter Drug price", ConsoleColor.Cyan);
            int price;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out price);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed price is not correct format!", ConsoleColor.Red);
                goto EnterPrice;
            }
            ConsoleHelper.WriteWithColor("Enter Drug count", ConsoleColor.Cyan);
            int count;
            isSucceeded = int.TryParse(Console.ReadLine(), out count);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed count is not correct format!", ConsoleColor.Red);
                goto EnterPrice;
            }

            _drugStoreService.GetAll();
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter DrugStore ID");
            int drugStoreid;
            isSucceeded = int.TryParse(Console.ReadLine(), out drugStoreid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var drugStore = _drugStoreRepository.Get(drugStoreid);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var
        }
    }
}
