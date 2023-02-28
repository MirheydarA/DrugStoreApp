using Core.Helpers;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class DrugStoreService
    {
        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly OwnerRepository _ownerRepository;
        private readonly OwnerService _ownerService;
        public DrugStoreService()
        {
            _drugStoreRepository= new DrugStoreRepository();
            _ownerRepository= new OwnerRepository();
            _ownerService= new OwnerService();
        }
        public void Create()
        {
            ConsoleHelper.WriteWithColor("Enter DrugStore name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter DrugStore address", ConsoleColor.Cyan);
            string address = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter Drugstore email", ConsoleColor.Cyan);
            string email = Console.ReadLine();

            _ownerService.GetAll();
            if (_ownerRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create owner first!", ConsoleColor.Red);
            }
            EnterIdDesc:  ConsoleHelper.WriteWithColor("Enter Owner ID", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            if (_ownerRepository.Get(id) is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
            }


        }
    }
}
