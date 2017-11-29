﻿using System.ComponentModel;
using ModernUI.Presentation;

namespace ModernUI.App
{
    public class SampleFormViewModel
        : NotifyPropertyChanged, IDataErrorInfo
    {
        private string firstName = "John";
        private string lastName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName")
                {
                    return string.IsNullOrEmpty(firstName) ? "Required value" : null;
                }
                if (columnName == "LastName")
                {
                    return string.IsNullOrEmpty(lastName) ? "Required value" : null;
                }
                return null;
            }
        }
    }
}