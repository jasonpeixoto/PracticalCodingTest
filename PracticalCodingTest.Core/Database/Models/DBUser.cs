//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;
using PracticalCodingTest.Models;
using SQLite;

namespace PracticalCodingTest.Core.Database.Models
{
    public class DBUser
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(200)]
        public string EmailAddress { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DBUser()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PracticalCodingTest.Core.Database.Models.DBUser"/> class.
        /// </summary>
        /// <param name="user">User.</param>
        public DBUser(UsersModel user)
        {
            this.FullName = user.Name;
            this.EmailAddress = user.Email;
            this.Password = user.Password;
        }

        /// <summary>
        /// Gets the users model.
        /// </summary>
        /// <returns>The users model.</returns>
        public UsersModel GetUsersModel()
        {
            return UsersModel.Create(this.FullName, this.EmailAddress, this.Password);
        }
    }
}
