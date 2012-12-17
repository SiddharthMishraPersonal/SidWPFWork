using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using AutofacExample.EducationDepartment.EventBase;
using AutofacExample.EducationDepartment.Models;
using System.Collections.ObjectModel;

namespace AutofacExample.EducationDepartment.ViewModels
{
    public class IndividualStudentViewModel : ViewModelBase
    {
        #region Private Variables

        private string _name;
        private string _collegeID;
        private string _studentID;
        private string _subject;
        private string _address;
        private string _city;
        private string _state;
        private string _country;
        private string _contactNumber;

        private StudentViewModel _studentVM;
        private CollegeViewModel _collegeVM;
        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Properties

        public CollegeViewModel CollegeVM
        {
            get { return _collegeVM; }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set
            {
                if (value != _contactNumber)
                {
                    _contactNumber = value;
                    OnPropertyChanged(() => this.ContactNumber);
                }
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    OnPropertyChanged(() => this.Country);
                }
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (value != _state)
                {
                    _state = value;
                    OnPropertyChanged(() => this.State);
                }
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged(() => this.City);
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged(() => this.Address);
                }
            }
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                if (value != _subject)
                {
                    _subject = value;
                    OnPropertyChanged(() => this.Subject);
                }
            }
        }

        public string StudentID
        {
            get { return _studentID; }
            set
            {
                if (value != _studentID)
                {
                    _studentID = value;
                    OnPropertyChanged(() => this.StudentID);
                }
            }
        }

        public string CollegeID
        {
            get { return _collegeID; }
            set
            {
                if (value != _collegeID)
                {
                    _collegeID = value;
                    OnPropertyChanged(() => CollegeID);
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _country)
                {
                    _name = value;
                    OnPropertyChanged(() => this.Name);
                }
            }
        }

        #endregion

        #region Constructors

        public IndividualStudentViewModel(StudentViewModel studentVM, CollegeViewModel collegeVM,
            IEventAggregator eventAggregator)
        {
            this._studentVM = studentVM;
            this._collegeVM = collegeVM;
            this._eventAggregator = eventAggregator;
        }

        #endregion
    }
}
