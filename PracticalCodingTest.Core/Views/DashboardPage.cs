//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using PracticalCodingTest.ViewModel;

namespace PracticalCodingTest.Views
{
    public partial class DashboardPage : BaseContentPage<DashboardViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PracticalCodingTest.MainPage"/> class.
        /// </summary>
        public DashboardPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the add user.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_AddUser(object sender, System.EventArgs e)
        {
            // ok for now navigate (I have my own navigationg framework as well)
            Navigation.PushAsync(new AddUserPage(ViewModel.users));
        }
    }
}
