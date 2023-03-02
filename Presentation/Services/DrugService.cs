﻿using Core.Entities;
using Core.Helpers;
using Data.Repositories.Abstract;
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

        private readonly DrugStoreRepository _drugStoreRepository;
        private readonly DrugStoreService _drugStoreService;
        private readonly DrugRepository _drugRepository;
        public DrugService()
        {

            _drugStoreRepository = new DrugStoreRepository();
            _drugStoreService = new DrugStoreService();
            _drugRepository = new DrugRepository();
        }
        public void Create()
        {
            if (_drugStoreRepository.GetAll().Count is 0)
            {
                ConsoleHelper.WriteWithColor("You must create DrugStore first");
                return;
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
            var drug = new Drug
            {
                Name = name,
                Price = price,
                Count = count,
                DrugStore = drugStore,
            };
            drugStore.Drugs.Add(drug);
            _drugRepository.Add(drug);
            ConsoleHelper.WriteWithColor($"{drug.Name} is succesfully created", ConsoleColor.Green);

        }

        public void GetDrugsByDrugstore()
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

            var drugs = _drugRepository.GetAll();
            ConsoleHelper.WriteWithColor("* -- All DrugStores -- *");
            if (drugs.Count is 0)
            {
                return;
            }
            foreach (var drug in drugStore.Drugs)
            {
                ConsoleHelper.WriteWithColor($"Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}");
            }
        }

        public void GetAll()
        {
            var drugs = _drugRepository.GetAll();
            ConsoleHelper.WriteWithColor("* -- All Drugs -- *");
            if (drugs.Count is 0)
            {
                ConsoleHelper.WriteWithColor("There is no any drug", ConsoleColor.Red);
            }
            foreach (var drug in drugs)
            {
                ConsoleHelper.WriteWithColor($"Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.DrugStore.Name}");
            }
        }

        public void Delete()
        {
            GetAll();

            if (_drugRepository != null)
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

            Drug dbdrug = _drugRepository.Get(id);
            if (dbdrug is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                return;
            }

            _drugRepository.Delete(dbdrug);
            ConsoleHelper.WriteWithColor("Drug is succesfully deleted", ConsoleColor.Green);

        }

        public void Update()
        {
            GetAll();

            if (_drugRepository != null)
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

            Drug drug = _drugRepository.Get(id);
            if (drug is null)
            {
                ConsoleHelper.WriteWithColor("There is no any owner in this ID", ConsoleColor.Red);
                return;
            }

            ConsoleHelper.WriteWithColor("Enter new Drug name", ConsoleColor.Cyan);
            string name = Console.ReadLine();
        EnterPrice: ConsoleHelper.WriteWithColor("Enter new Drug price", ConsoleColor.Cyan);
            int price;
            isSucceeded = int.TryParse(Console.ReadLine(), out price);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed price is not correct format!", ConsoleColor.Red);
                goto EnterPrice;
            }
            ConsoleHelper.WriteWithColor("Enter new Drug count", ConsoleColor.Cyan);
            int count;
            isSucceeded = int.TryParse(Console.ReadLine(), out count);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed count is not correct format!", ConsoleColor.Red);
                goto EnterPrice;
            }

            _drugStoreService.GetAll();
            ConsoleHelper.WriteWithColor("Enter new DrugStore ID");
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

            drug.Name = name;
            drug.Price = price;
            drug.Count = count;
            drug.DrugStore = drugStore;

            drugStore.Drugs.Add(drug);
            _drugRepository.Add(drug);
            ConsoleHelper.WriteWithColor($"{drug.Name} is succesfully updated", ConsoleColor.Green);
        }
    }
}