﻿using DotNetSandbox.Models.Data;
using static System.Formats.Asn1.AsnWriter;

namespace DotNetSandbox.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            //context.Database.EnsureCreated();
            if (!context.Users.Any(u => u.Username == "admin"))
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword("admin-password");

                context.Users.Add(new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = hashedPassword,
                    IsVerified = true,
                    Role = User.UserRole.admin,
                    Email = "admin@gmail.com"
                });
                context.SaveChanges();
                Console.WriteLine("admin created");
            }
            else
            {
                Console.WriteLine("admin already exist");
            }
        }
    }
}
