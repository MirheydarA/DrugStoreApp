using Core.Entities;
using Core.Helpers;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Presentation.Services
{
    public class DruggistService
    {
        private readonly DrugStoreService _drugStoreService;
        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly DruggistRepository _druggistRepository;
        public DruggistService()
        {
            _drugStoreService = new DrugStoreService();
            _drugStoreRepository = new DrugStoreRepository();
            _druggistRepository = new DruggistRepository();
        }
        public void Create()
        {
            if (_drugStoreRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first", ConsoleColor.Red);
                return;
            }
            ConsoleHelper.WriteWithColor("Enter Druggist name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter Druggist surname", ConsoleColor.Cyan);
            string surname = Console.ReadLine();
        EnterAgeDesc: ConsoleHelper.WriteWithColor("Enter Druggist age", ConsoleColor.Cyan);
            byte age;
            bool isSucceeded = byte.TryParse(Console.ReadLine(), out age);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed age is not correct format!", ConsoleColor.Red);
                goto EnterAgeDesc;
            }
            if (age < 18)
            {
                ConsoleHelper.WriteWithColor("Inputed age must bigger than 18!", ConsoleColor.Red);
                goto EnterAgeDesc;
            }
        EnterExperienceDesc: ConsoleHelper.WriteWithColor("Enter Druggist experience", ConsoleColor.Cyan);
            byte experience;
            isSucceeded = byte.TryParse(Console.ReadLine(), out experience);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed exeperience  is not correct format!", ConsoleColor.Red);
                goto EnterExperienceDesc;
            }
            if (experience > age - 18)
            {
                ConsoleHelper.WriteWithColor("Inputed experience must smaller than age!", ConsoleColor.Red);
                goto EnterExperienceDesc;
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

            var druggist = new Druggist
            {
                Name = name,
                Surname = surname,
                Age = age,
                Experience = experience,
                DrugStore = drugStore,
            };
            drugStore.Druggists.Add(druggist);
            _druggistRepository.Add(druggist);
            ConsoleHelper.WriteWithColor($"{druggist.Name} {druggist.Surname} is succesfully created", ConsoleColor.Green);


        }

        public void GetAll()
        {
            var druggists = _druggistRepository.GetAll();
            ConsoleHelper.WriteWithColor("* -- All Drugists-- *");
            if (druggists.Count is 0)
            {
                ConsoleHelper.WriteWithColor("There is no any Druggist", ConsoleColor.Red);
            }
            foreach (var druggist in druggists)
            {
                ConsoleHelper.WriteWithColor($"ID:{druggist.Id} Name:{druggist.Name} Surname:{druggist.Surname} DrugStore:{druggist.DrugStore.Name}");
            }
        }
        public void Delete()
        {
            GetAll();

            if (_druggistRepository.GetAll().Count == 0)
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

            var dbDruggist = _druggistRepository.Get(id);
            if (dbDruggist is null)
            {
                ConsoleHelper.WriteWithColor("There is no any druggist in this ID", ConsoleColor.Red);
                return;
            }
            _druggistRepository.Delete(dbDruggist);
            ConsoleHelper.WriteWithColor("Druggists is succeesfully deleted", ConsoleColor.Green);


        }

        public void Update()
        {
            GetAll();
            if (_druggistRepository.GetAll().Count is 0)
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
            var druggist = _druggistRepository.Get(id);
            if (druggist is null)
            {
                ConsoleHelper.WriteWithColor("There is no any Druggist in this ID", ConsoleColor.Red);
                goto UpdatingDesc;
            }

            ConsoleHelper.WriteWithColor("Enter new Druggist name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter new Druggist surname", ConsoleColor.Cyan);
            string surname = Console.ReadLine();
        EnterAgeDesc: ConsoleHelper.WriteWithColor("Enter new Druggist age", ConsoleColor.Cyan);
            byte age;
            isSucceeded = byte.TryParse(Console.ReadLine(), out age);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed age is not correct format!", ConsoleColor.Red);
                goto EnterAgeDesc;
            }
        EnterExperienceDesc: ConsoleHelper.WriteWithColor("Enter new Druggist experience", ConsoleColor.Cyan);
            byte experience;
            isSucceeded = byte.TryParse(Console.ReadLine(), out experience);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed exeperience  is not correct format!", ConsoleColor.Red);
                goto EnterExperienceDesc;
            }
            if (experience > age - 18)
            {
                ConsoleHelper.WriteWithColor("Inputed experience must smaller than age!", ConsoleColor.Red);
                goto EnterExperienceDesc;
            }
            _drugStoreService.GetAll();
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter new DrugStore ID");
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

            druggist.Name = name;
            druggist.Surname = surname;
            druggist.Age = age;
            druggist.Experience = experience;
            druggist.DrugStore = drugStore;
           
            _druggistRepository.Update(druggist);
            ConsoleHelper.WriteWithColor("Druggist is succesfully updating", ConsoleColor.Green);
        }

        public void GetAllDruggistsByDrugStore()
        {
            _drugStoreService.GetAll();
            if (_drugStoreRepository.GetAll().Count is 0)
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first!", ConsoleColor.DarkCyan);
                return;
            }
        EnterIdDesc: ConsoleHelper.WriteWithColor("Enter DrugStore ID");
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not correct format!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var drugStore = _drugStoreRepository.Get(id);
            if (drugStore is null)
            {
                ConsoleHelper.WriteWithColor("Inputed Id is not exist!", ConsoleColor.Red);
                goto EnterIdDesc;
            }
            var druggists = _druggistRepository.GetAll();
            ConsoleHelper.WriteWithColor("* -- All Druggists -- *");
            if (druggists.Count is 0)
            {
                return;
            }
            foreach (var druggist in drugStore.Druggists)
            {
                ConsoleHelper.WriteWithColor($"ID:{druggist.Id} Name:{druggist.Name} {druggist.Surname}");
            }
        }
    }
}
