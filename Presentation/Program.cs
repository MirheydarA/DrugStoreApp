﻿using Core.Constants;
using Core.Helpers;
using Presentation.Services;
using System.Text;

namespace Presentation
{
    public static class Program
    {
        private readonly static OwnerService _ownerService;
        private readonly static DrugStoreService _drugStoreService;
        private readonly static DruggistService _druggistService;
        private readonly static DrugService _drugService;

        static Program()
        {
            _ownerService = new OwnerService();
            _drugStoreService = new DrugStoreService();
            _druggistService = new DruggistService();
            _drugService = new DrugService();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ConsoleHelper.WriteWithColor("* --- Welcome --- *", ConsoleColor.DarkCyan);
        MainMenuDesc: ConsoleHelper.WriteWithColor("\n1. Owners", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("2. Drugstores", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("3. Druggists ", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("4. Drugs", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("0. Logout", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteWithColor("<- Choose option ->", ConsoleColor.DarkCyan);

            int number;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                goto MainMenuDesc;
            }

            switch (number)
            {
                case (int)MainMenuOptions.Owners:
                    while (true)
                    {
                    OwnerMenuDesc: ConsoleHelper.WriteWithColor("1. Create Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all Owner", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);

                        ConsoleHelper.WriteWithColor("<- Choose option ->", ConsoleColor.DarkCyan);

                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                            goto OwnerMenuDesc;
                        }

                        switch (number)
                        {
                            case (int)OwnerOptions.Create:
                                _ownerService.Create();
                                break;
                            case (int)OwnerOptions.Update:
                                _ownerService.Update();
                                break;
                            case (int)OwnerOptions.Delete:
                                _ownerService.Delete();
                                break;
                            case (int)OwnerOptions.GetAll:
                                _ownerService.GetAll();
                                break;
                            case (int)OwnerOptions.BackToMainMenu:
                                goto MainMenuDesc;
                            default:
                                ConsoleHelper.WriteWithColor("Your choise is not correct!", ConsoleColor.Red);
                                ConsoleHelper.WriteWithColor("Please try again", ConsoleColor.DarkCyan);
                                goto OwnerMenuDesc;
                        }
                    }

                case (int)MainMenuOptions.Drugstores:
                    while (true)
                    {
                    DrugStoreMenuDesc: ConsoleHelper.WriteWithColor("1. Create DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all DrugStore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);


                        ConsoleHelper.WriteWithColor("<- Choose option ->", ConsoleColor.DarkCyan);
                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                            goto DrugStoreMenuDesc;
                        }

                        switch (number)
                        {
                            case (int)DrugStoreOptions.Create:
                                _drugStoreService.Create();
                                break;

                            case (int)DrugStoreOptions.Update:
                                _drugStoreService.Update();
                                break;

                            case (int)DrugStoreOptions.Delete:
                                _drugStoreService.Delete();
                                break;

                            case (int)DrugStoreOptions.GetAll:
                                _drugStoreService.GetAll();
                                break;

                            case (int)DrugStoreOptions.BackToMainMenu:
                                goto MainMenuDesc;

                            default:
                                ConsoleHelper.WriteWithColor("Your choise is not correct!", ConsoleColor.Red);
                                ConsoleHelper.WriteWithColor("Please try again", ConsoleColor.DarkCyan);
                                goto DrugStoreMenuDesc;
                        }
                    }

                case (int)MainMenuOptions.Druggists:
                    while (true)
                    {
                    DruggistMenuDesc: ConsoleHelper.WriteWithColor("1. Create Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all Druggist", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);

                        ConsoleHelper.WriteWithColor("<- Choose option ->", ConsoleColor.DarkCyan);

                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                            goto DruggistMenuDesc;
                        }

                        switch (number)
                        {
                            case (int)DruggistOptions.Create:
                                _druggistService.Create();
                                break;

                            case (int)DruggistOptions.Update:
                                _druggistService.Update();
                                break;

                            case (int)DruggistOptions.Delete:
                                _druggistService.Delete();
                                break;

                            case (int)DruggistOptions.GetAll:
                                _druggistService.GetAll();
                                break;

                            case (int)DruggistOptions.BackToMainMenu:
                                goto MainMenuDesc;

                            default:
                                ConsoleHelper.WriteWithColor("Your choise is not correct!", ConsoleColor.Red);
                                ConsoleHelper.WriteWithColor("Please try again", ConsoleColor.DarkCyan);
                                goto DruggistMenuDesc;
                        }
                    }

                case (int)MainMenuOptions.Drugs:
                    while (true)
                    {
                    DrugsMenuDesc: ConsoleHelper.WriteWithColor("1. Create Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("2. Update Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("3. Delete Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("4. Get all Drug", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("5. Get Drugs by Drugstore", ConsoleColor.DarkYellow);
                        ConsoleHelper.WriteWithColor("0. Back to main menu", ConsoleColor.DarkYellow);

                        ConsoleHelper.WriteWithColor("<- Choose option ->", ConsoleColor.DarkCyan);

                        isSucceeded = int.TryParse(Console.ReadLine(), out number);
                        if (!isSucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                            goto DrugsMenuDesc;
                        }

                        switch (number)
                        {
                            case (int)DrugOptions.Create:
                                _drugService.Create();
                                break;
                            
                            case (int)DrugOptions.Update:
                                _drugService.Update();  
                                break;
                            
                            case (int)DrugOptions.Delete:
                                _drugService.Delete();
                                break;
                            
                            case (int)DrugOptions.GetAll:
                                _drugService.GetAll();
                                break;

                            case (int)DrugOptions.GetDrugsByDrugstore:
                                _drugService.GetDrugsByDrugstore();
                                break;
                            
                            case (int)DrugOptions.BackToMainMenu:
                                goto DrugsMenuDesc;

                            default:
                                ConsoleHelper.WriteWithColor("Your choise is not correct!", ConsoleColor.Red);
                                ConsoleHelper.WriteWithColor("Please try again", ConsoleColor.DarkCyan);
                                goto DrugsMenuDesc;
                        }
                    }

                case (int)MainMenuOptions.Logout:
                    goto MainMenuDesc;

                default:
                    ConsoleHelper.WriteWithColor("Your choise is not correct!", ConsoleColor.Red);
                    ConsoleHelper.WriteWithColor("Please try again", ConsoleColor.DarkCyan);
                    goto MainMenuDesc;
            }


        }
    }
}