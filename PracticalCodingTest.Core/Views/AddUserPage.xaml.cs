﻿//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;
using PracticalCodingTest.ViewModel;
using PracticalCodingTest.Models;
using PracticalCodingTest.Helpers;
using Xamarin.Forms;
using PracticalCodingTest.Core.Database.Models;

namespace PracticalCodingTest.Views
{
    public partial class AddUserPage : BaseContentPage<AddUserViewModel>
    {
        public AddUserPage(ObservableCollection<UsersModel> users) : base(users)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setups the bindings.
        /// </summary>
        public override void SetupBindings()
        {
            base.SetupBindings();
            ViewModel.AddUserClicked = new Command(AddUserClickedAction);       // setup our binding to the click for now
        }

        /// <summary>
        /// Adds the user clicked action. we need to come back to the view so we can get the navigation.
        /// </summary>
        /// <param name="obj">Object.</param>
        void AddUserClickedAction(object obj)
        {
            if(ViewModel.AddUser())
            {
                Navigation.PopAsync();                          // pop back to list of users
            }
        }
    }
}
