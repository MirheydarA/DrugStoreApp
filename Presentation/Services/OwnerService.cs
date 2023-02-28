using System;
using Core.Entities;
using Data.Repositories.Concrete;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using Data.Repositories.Abstract;
using Core.Helpers;

namespace Presentation.Services
{
    public class OwnerService
    {
        private readonly OwnerRepository _ownerRepository;
        public OwnerService()
        {
            _ownerRepository = new OwnerRepository();
        }

        public void GetAll()
        {
            var owners = _ownerRepository.GetAll();
            ConsoleHelper.WriteWithColor("* -- All Groups -- *");
            if (owners.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no any group.", ConsoleColor.Red);
            }
            foreach (var owner in owners)
            {
                ConsoleHelper.WriteWithColor($"ID:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
            }
        }

        public void Create()
        {
            ConsoleHelper.WriteWithColor("Enter Owner name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter Owner surname", ConsoleColor.Cyan);
            string surname = Console.ReadLine();


            var owner = new Owner()
            {
                Name = name,
                Surname = surname,
            };
            _ownerRepository.Add(owner);
            ConsoleHelper.WriteWithColor($"{owner.Name} {owner.Surname} is succecfully created", ConsoleColor.Green);
        }

        public void Delete()
        {
            GetAll();

            if (_ownerRepository.GetAll().Count == 0)
            {
                return;
            }
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter ID for delete", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            Owner dbOwner = _ownerRepository.Get(id);
            if (dbOwner is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            _ownerRepository.Delete(dbOwner);
            ConsoleHelper.WriteWithColor("Owner is succesfully deleted", ConsoleColor.Green);
        }

        public void Update()
        {
            GetAll();

            if (_ownerRepository.GetAll().Count == 0)
            {
                return;
            }

        UpdatıngDesc: ConsoleHelper.WriteWithColor("Enter owner ID for updating", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed ID is not correct format!", ConsoleColor.Red);
                goto UpdatıngDesc;
            }
            var owner = _ownerRepository.Get(id);
            if (owner is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                goto UpdatıngDesc;
            }
            ConsoleHelper.WriteWithColor("Enter new name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter new surname");
            string surname = Console.ReadLine();

            owner.Name = name;
            owner.Surname = surname;

            _ownerRepository.Update(owner);
            ConsoleHelper.WriteWithColor("Owner is succesfully updating", ConsoleColor.Green);
        }
    }
}



