//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;
using PracticalCodingTest.Helpers;
using PracticalCodingTest.ViewModel;
using PracticalCodingTest.Models;
using Xamarin.Forms;

namespace PracticalCodingTest.Views
{
    public class BaseContentPage<VM> : ContentPage where VM : BaseViewModel
    {
        public VM ViewModel;

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="T:INLShac.Views.BaseContentPage`1"/> class.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// ------------------------------------------------------------------------------------------
        public BaseContentPage(dynamic obj = null)
        {
            ViewModel = Extentions.GetObject<VM>();
            ViewModel.Init(obj);
            BindingContext = ViewModel;
            NavigationPage.SetHasNavigationBar(this, true);
            Title = ViewModel.Title;
            SetupBindings();
        }

        public virtual void SetupBindings()
        {

        }
    }
}
