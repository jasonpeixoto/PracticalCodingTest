//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PracticalCodingTest.Core.Database.Models;
using PracticalCodingTest.Models;
using Xamarin.Forms;

namespace PracticalCodingTest.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<UsersModel> users { get; set; }

        public DashboardViewModel()
        {
            users = new ObservableCollection<UsersModel>();
            IEnumerable<DBUser> DBUsers = DBModels.GetAllDBUSers();

            foreach(DBUser dbUser in DBUsers)
            {
                users.Add(dbUser.GetUsersModel());
            }
        }

        public override void InitlizeModel()
        {

        }


    }
}

