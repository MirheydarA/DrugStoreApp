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
    public class AdminService
    {
        private readonly AdminRepository _adminRepository;
        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }
        public Admin Authorize()
        {
        Login: ConsoleHelper.WriteWithColor("* --- LOGIN --- *", ConsoleColor.Blue);

            ConsoleHelper.WriteWithColor("Please enter username:", ConsoleColor.DarkYellow);
            string username = Console.ReadLine();


            ConsoleHelper.WriteWithColor("\nPlease enter password:", ConsoleColor.DarkYellow);
            string password = Console.ReadLine();

            var admin = _adminRepository.GetByUsernameAndPassword(username, password);
            if (admin is null)
            {
                ConsoleHelper.WriteWithColor("Username or Password is wrong ");
                goto Login;
            }
            return admin;
        }
    }
}
