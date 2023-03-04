using Core.Entities;
using Core.Helpers;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DbInitializer
    {
        static int id;
        public static void SeedAdmins()
        {
            var admins = new List<Admin>
            {
                new Admin
                {
                    Id= id++,
                    Username = "admin1",
                    Password = PasswordHasher.Encrypt("123456"),
                },
                new Admin
                {
                    Id= id++,
                    Username = "admin2",
                    Password = PasswordHasher.Encrypt("123456") ,
                },
                new Admin
                {
                    Id= id++,
                    Username= "admin3",
                    Password = PasswordHasher.Encrypt("123456")
                }
            };
            DbContext.Admins.AddRange(admins);
        }
    }
}
