//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;

namespace PracticalCodingTest.Models
{
    public class UsersModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UsersModel(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public static UsersModel Create(string name, string email, string password)
        {
            return new UsersModel(name, email, password);
        }
    }
}
