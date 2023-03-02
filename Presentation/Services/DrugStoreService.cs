using Core.Entities;
using Core.Extension;
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
            
            if (_ownerRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create owner for create DrugStore!", ConsoleColor.DarkCyan);
                return;
            }
            ConsoleHelper.WriteWithColor("Enter DrugStore name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter DrugStore address", ConsoleColor.Cyan);
            string address = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter DrugStore contact number", ConsoleColor.Cyan);
            string contactnumber = Console.ReadLine();//regex
        EmailDesc: ConsoleHelper.WriteWithColor("Enter Drugstore email", ConsoleColor.Cyan);
            string email = Console.ReadLine();
            //if (!email.IsEmail())
            //{
            //    ConsoleHelper.WriteWithColor("Email is not correct format!", ConsoleColor.Red);
            //    goto EmailDesc;
            //}

            //if (_drugStoreRepository.IsDuplicatedEmail(email))
            //{
            //    ConsoleHelper.WriteWithColor("This email already used!", ConsoleColor.Red);
            //    goto EmailDesc;
            //}

            _ownerService.GetAll();
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
                ContactNumber = contactnumber,
                Email = email,
                Owner = owner
            };
            owner.Drugstores.Add(drugStore);    
            _drugStoreRepository.Add(drugStore);
            ConsoleHelper.WriteWithColor($"{drugStore.Name} drugstore is succesfully created", ConsoleColor.Green);
        }

        public void GetAll()
        {
            var drugStores = _drugStoreRepository.GetAll();
            ConsoleHelper.WriteWithColor("* -- All DrugStores -- *");
            if (drugStores.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no any DrugStore",ConsoleColor.Red);
            }
            foreach (var drugStore in drugStores)
            {
                ConsoleHelper.WriteWithColor($"ID:{drugStore.Id} Name:{drugStore.Name} Email:{drugStore.Email} Owner:{drugStore.Owner.Name} {drugStore.Owner.Surname} {drugStore.Owner.Id} ");
            }


        }

        public void Delete()
        {
            GetAll();

            if (_drugStoreRepository.GetAll().Count == 0)
            {
                return;
            }
            EnterIdDesc: ConsoleHelper.WriteWithColor("Enter ID for deleting", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }

            DrugStore dbdrugStore = _drugStoreRepository.Get(id);
            if (dbdrugStore is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                return;
            }
            _drugStoreRepository.Delete(dbdrugStore);
            ConsoleHelper.WriteWithColor("DrugStore is succesfully deleted", ConsoleColor.Green);

        }

        public void Update()
        {
            GetAll();

            if (_drugStoreRepository.GetAll().Count == 0)
            {
                return;
            }
        UpdatingDesc: ConsoleHelper.WriteWithColor("Enter DrugStore ID for updating", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed ID is not correct format!", ConsoleColor.Red);
                goto UpdatingDesc;
            }
            var drugStore = _drugStoreRepository.Get(id);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("There is no any DrugStore in this ID", ConsoleColor.Red);
                goto UpdatingDesc;
            }
            ConsoleHelper.WriteWithColor("Enter new name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter new DrugStore address", ConsoleColor.Cyan);
            string address = Console.ReadLine();
            //
            ConsoleHelper.WriteWithColor("Enter new DrugStore contact number", ConsoleColor.Cyan);
            string contactnumber = Console.ReadLine();//regex
            //
        NewEmailDesc: ConsoleHelper.WriteWithColor("Enter new Drugstore email", ConsoleColor.Cyan);
            string email = Console.ReadLine();
            if (!email.IsEmail())
            {
                ConsoleHelper.WriteWithColor("Email is not correct format!", ConsoleColor.Red);
                goto NewEmailDesc;
            }

            if (_drugStoreRepository.IsDuplicatedEmail(email))
            {
                ConsoleHelper.WriteWithColor("This email already used!", ConsoleColor.Red);
                goto NewEmailDesc;
            }
            _ownerService.GetAll();
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter new Owner ID", ConsoleColor.Cyan);
            int ownerid;
            isSucceeded = int.TryParse(Console.ReadLine(), out ownerid);
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


            drugStore.Name = name;
            drugStore.Email = email;
            drugStore.Address = address;
            drugStore.ContactNumber = contactnumber;
            drugStore.Owner = owner;

            
            _drugStoreRepository.Update(drugStore);
            ConsoleHelper.WriteWithColor("DrugStore is succesfully updating", ConsoleColor.Green);
        }
    }
}
