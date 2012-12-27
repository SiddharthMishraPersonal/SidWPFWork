using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using AutofacExample.EducationDepartment.EventBase;
using AutofacExample.EducationDepartment.Views;
using System.Windows.Input;
using AutofacExample.EducationDepartment.Models;
using AutofacExample.EducationDepartment.Shared;

namespace AutofacExample.EducationDepartment.ViewModels
{
    public class IndividualCollegeViewModel : PageViewModel<AddCollege>
    {
        #region Private Variable

        private string _collegeID;
        private string _name;
        private string _address;
        private string _city;
        private string _state;
        private string _country;
        private string _contactNumber;

        private CollegeViewModel _collegeVM;
        private readonly IEventAggregator _eventAggregator;

        #endregion

        #region Properties

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

        #endregion

        #region Constructors

        public IndividualCollegeViewModel(AddCollege addCollege, CollegeViewModel collegeVM, IEventAggregator eventAggregator)
            : base(addCollege)
        {
            this._collegeVM = collegeVM;
            this._eventAggregator = eventAggregator;
        }

        #endregion

        #region Public Methods

        public void OnEdit(CollegeViewModel college)
        {

        }

        #endregion

        #region Commands

        ICommand _saveCollegeCommand;

        public ICommand SaveCollegeCommand
        {
            get
            {

                if (_saveCollegeCommand == null)
                    this._saveCollegeCommand = new RelayCommands(param => this.SaveCollegeCommand_Execute(param),
                        param => this.SaveCollegeCommand_CanExecute(param));

                return _saveCollegeCommand;
            }
        }

        bool SaveCollegeCommand_CanExecute(object param)
        {
            if (string.IsNullOrEmpty(this.Name))
                return false;

            return true;
        }

        void SaveCollegeCommand_Execute(object param)
        {
            CollegeModel college = new CollegeModel(this.Name);
            college.Address = this.Address;
            college.City = this.City;
            college.State = this.State;
            college.Country = this.Country;
            college.ContactNumber = this.ContactNumber;

            //Add college to list
            this._collegeVM.CollegeList.Add(college);

            //Close after saving
            (this.View as AddCollege).Close();
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
            this.Address = string.Empty;
            this.City = string.Empty;
            this.State = string.Empty;
            this.Country = string.Empty;
            this.ContactNumber = string.Empty;
        }

        #endregion
    }
}
