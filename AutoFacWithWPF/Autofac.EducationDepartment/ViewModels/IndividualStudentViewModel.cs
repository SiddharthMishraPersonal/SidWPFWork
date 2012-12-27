using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using AutofacExample.EducationDepartment.EventBase;
using AutofacExample.EducationDepartment.Models;
using System.Collections.ObjectModel;
using AutofacExample.EducationDepartment.Views;
using System.Windows.Input;
using AutofacExample.EducationDepartment.Shared;

namespace AutofacExample.EducationDepartment.ViewModels
{
    public class IndividualStudentViewModel : PageViewModel<AddStudent>
    {
        #region Private Variables

        private string _name;
        private string _studentID;
        private string _subject;
        private string _address;
        private string _city;
        private string _state;
        private string _country;
        private string _contactNumber;
        private CollegeModel _college;

        private StudentViewModel _studentVM;
        private CollegeViewModel _collegeVM;
        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Properties

        public CollegeViewModel CollegeVM
        {
            get { return _collegeVM; }
        }

        public CollegeModel College
        {
            get { return _college; }
            set
            {
                if (value != _college)
                {
                    _college = value;
                    OnPropertyChanged(() => this.College);
                    OnPropertyChanged(() => this.CollegeName);
                    OnPropertyChanged(() => this.CollegeID);
                }
            }
        }

        public string CollegeName
        {
            get
            {
                return this.College.Name;
            }
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
            get { return this.College.CollegeID; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(() => this.Name);
                }
            }
        }

        #endregion

        #region Constructors

        public IndividualStudentViewModel(AddStudent addStudent, StudentViewModel studentVM, CollegeViewModel collegeVM,
            IEventAggregator eventAggregator)
            : base(addStudent)
        {
            this._studentVM = studentVM;
            this._collegeVM = collegeVM;
            this._eventAggregator = eventAggregator;
        }

        #endregion

        #region Commands

        ICommand _saveStudentCommand;

        public ICommand SaveStudentCommand
        {
            get
            {
                if (_saveStudentCommand == null)
                    _saveStudentCommand = new RelayCommands(param => this.SaveStudentCommand_Execute(param),
                        param => this.SaveStudentCommand_CanExecute(param));
                return _saveStudentCommand;
            }
        }

        bool SaveStudentCommand_CanExecute(object param)
        {
            if (string.IsNullOrEmpty(this.Name) ||
                string.IsNullOrEmpty(this.CollegeID) ||
                string.IsNullOrEmpty(this.Subject))
                return false;

            return true;
        }

        void SaveStudentCommand_Execute(object param)
        {
            StudentModel student = new StudentModel(this.College, this.Name, this.Subject);
            student.Address = this.Address;
            student.City = this.City;
            student.State = this.State;
            student.Country = this.Country;
            student.ContactNumber = this.ContactNumber;

            //Add student to list
            this._studentVM.StudentList.Add(student);

            //Close after saving
            (this.View as AddStudent).Close();
        }

        ICommand _clearFieldsCommand;

        public ICommand ClearFieldsCommand
        {
            get
            {
                if (_clearFieldsCommand == null)
                    _clearFieldsCommand = new RelayCommands(param => this.ClearFieldsCommand_Execute(param),
                        param => this.ClearFieldsCommand_CanExecute(param));

                return _clearFieldsCommand;
            }
        }

        bool ClearFieldsCommand_CanExecute(object param)
        {
            if (string.IsNullOrEmpty(this.Name) &&
                string.IsNullOrEmpty(this.Subject) &&
                string.IsNullOrEmpty(this.Address) &&
                string.IsNullOrEmpty(this.City) &&
                string.IsNullOrEmpty(this.State) &&
                string.IsNullOrEmpty(this.Country) &&
                string.IsNullOrEmpty(this.ContactNumber))
                return false;

            return true;
        }

        void ClearFieldsCommand_Execute(object param)
        {
            this.Name = string.Empty;
            this.Subject = string.Empty;
            this.Address = string.Empty;
            this.City = string.Empty;
            this.State = string.Empty;
            this.Country = string.Empty;
            this.ContactNumber = string.Empty;
        }

        #endregion

    }
}
