using Core.Entities;
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
            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
            _ownerService = new OwnerService();
        }
        public void Create()
        {
            _ownerService.GetAll();
            if (_ownerRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create owner for create DrugStore!", ConsoleColor.DarkCyan);
                return;
            }
            ConsoleHelper.WriteWithColor("Enter DrugStore name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter DrugStore address", ConsoleColor.Cyan);
            string address = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter Drugstore email", ConsoleColor.Cyan);
            string email = Console.ReadLine();

            
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter Owner ID", ConsoleColor.Cyan);
            int ownerid;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out ownerid);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var owner = _ownerRepository.Get(ownerid);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto EnterIdDesc;
            }

            var drugStore = new DrugStore
            {
                Name = name,
                Address = address,
                Email = email,
                Owner = owner
            };
            _ownerRepository.Add(owner);
            _drugStoreRepository.Add(drugStore);
            ConsoleHelper.WriteWithColor($"{drugStore.Name} drugstore is succesfully created");
        }

        public void GetAll()
        {
            var drugStores = _drugStoreRepository.GetAll();
            ConsoleHelper.WriteWithColor("* -- All Groups -- *");
            if (drugStores.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no any DrugStore",ConsoleColor.Red);
            }
            foreach (var drugStore in drugStores)
            {
                ConsoleHelper.WriteWithColor($"ID:{drugStore.Id} Name:{drugStore.Name} Email:{drugStore.Email}");
            }


        }

        public void 
    }
}
