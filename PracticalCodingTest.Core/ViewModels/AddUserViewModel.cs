//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PracticalCodingTest.Helpers;
using PracticalCodingTest.Models;

namespace PracticalCodingTest.ViewModel
{
    public class AddUserViewModel : BaseViewModel
    {
        public readonly string ColorValid = "FFFFFF";
        public readonly string ColorInValid = "FF7F7F";

        public ObservableCollection<UsersModel> users { get; set; }

        public override void InitlizeModel()
        {

        }

        // save users that was passed
        public override void Init(dynamic parameter)
        {
            users = parameter;
        }

        private string _FullName;
        public string FullName
        {
            get => _FullName;
            set {
                OnPropertyChanged(_FullName = value);
                EvaluateFields();
            }
        }

        private string _EmailAddress;
        public string EmailAddress
        {
            get => _EmailAddress;
            set {
                OnPropertyChanged(_EmailAddress = value);
                EvaluateFields();
            }
        }

        public bool PasswordEmpty
        {
            get => string.IsNullOrEmpty(Password);
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set {
                OnPropertyChanged(_Password = value);
                OnPropertyChanged(PasswordEmpty, "PasswordEmpty");
                EvaluateFields();
            }
        }

        private string _PasswordCopy;
        public string PasswordCopy
        {
            get => _PasswordCopy;
            set {
                OnPropertyChanged(_PasswordCopy = value);
                EvaluateFields();
            }
        }

        private bool _IsEnabled;
        public bool IsEnabled
        {
            get => _IsEnabled;
            set { OnPropertyChanged(_IsEnabled = value);  }
        }

        // command
        public ICommand AddUserClicked { get; set; }

        // background colors for now
        private string _BGFullName;
        public string BGFullName
        {
            get => _BGFullName;
            set { OnPropertyChanged(_BGFullName = value); }
        }

        // background colors for now
        private string _BGEmailAddress;
        public string BGEmailAddress
        {
            get => _BGEmailAddress;
            set { OnPropertyChanged(_BGEmailAddress = value); }
        }

        // background colors for now
        private string _BGPassword;
        public string BGPassword
        {
            get => _BGPassword;
            set { OnPropertyChanged(_BGPassword = value); }
        }

        // background colors for now
        private string _BGPasswordCopy;
        public string BGPasswordCopy
        {
            get => _BGPasswordCopy;
            set { OnPropertyChanged(_BGPasswordCopy = value); }
        }

        public bool ShowError
        {
            get => !string.IsNullOrEmpty(Error);
        }

        private string _Error;
        public string Error
        {
            get => _Error;
            set { 
                OnPropertyChanged(_Error = value);
                OnPropertyChanged(ShowError);
            }
        }


        /// <summary>
        /// Evaluates the fields.
        /// </summary>
        public void EvaluateFields()
        {
            do
            {
                Error = "";

                // determien full name
                if (string.IsNullOrEmpty(FullName))
                {
                    Error = "Full Name Required";
                    BGFullName = ColorInValid;
                    break;
                }
                BGFullName = ColorValid;

                // determien if email is valid
                if (!EmailAddress.IsValidEmail())
                {
                    Error = "Email Address is Invalid";
                    BGEmailAddress = ColorInValid;
                    break;
                }
                BGEmailAddress = ColorValid;

                // determine if password is valid
                PasswordHasConsecutiveChars = Password.HasConsecutiveChars();
                PasswordHasDecimalDigit = Password.HasDecimalDigit();
                PasswordHasLowerCaseLetter = Password.HasLowerCaseLetter();
                PasswordHasUpperCaseLetter = Password.HasUpperCaseLetter();
                PasswordMeetsLengthRequirements = Password.MeetsLengthRequirements();

                if (!Password.IsPasswordStrong())
                {
                    Error = "Password Is Weak";
                    BGPassword = ColorInValid;
                    break;
                }
                BGPassword = ColorValid;
                BGPasswordCopy = ColorValid;

                // determien if password is valid
                if (Password != PasswordCopy)
                {
                    Error = "Password Do Not Match";
                    BGPassword = ColorInValid;
                    BGPasswordCopy = ColorInValid;
                    break;
                }

                IsEnabled = true;
                return;
            } while (IsEnabled == false);
            IsEnabled = false;
        }

        // all the ones below can be used for the password
        private bool _PasswordHasConsecutiveChars;
        public bool PasswordHasConsecutiveChars
        {
            get => _PasswordHasConsecutiveChars && !PasswordEmpty;
            set { OnPropertyChanged(_PasswordHasConsecutiveChars = value);  }
        }

        private bool _PasswordHasDecimalDigit;
        public bool PasswordHasDecimalDigit
        {
            get => !_PasswordHasDecimalDigit && !PasswordEmpty;
            set { OnPropertyChanged(_PasswordHasDecimalDigit = value); }
        }

        private bool _PasswordHasLowerCaseLetter;
        public bool PasswordHasLowerCaseLetter
        {
            get => !_PasswordHasLowerCaseLetter && !PasswordEmpty;
            set { OnPropertyChanged(_PasswordHasLowerCaseLetter = value); }
        }

        private bool _PasswordHasUpperCaseLetter;
        public bool PasswordHasUpperCaseLetter
        {
            get => !_PasswordHasUpperCaseLetter && !PasswordEmpty;
            set { OnPropertyChanged(_PasswordHasUpperCaseLetter = value); }
        }

        private bool _PasswordMeetsLengthRequirements;
        public bool PasswordMeetsLengthRequirements
        {
            get => !_PasswordMeetsLengthRequirements && !PasswordEmpty;
            set { OnPropertyChanged(_PasswordMeetsLengthRequirements = value); }
        }


    }
}
