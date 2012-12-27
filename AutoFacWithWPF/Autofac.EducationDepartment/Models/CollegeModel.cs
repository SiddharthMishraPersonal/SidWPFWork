using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutofacExample.EducationDepartment.Shared;

namespace AutofacExample.EducationDepartment.Models
{
    public class CollegeModel : NotifyPropertyChanged
    {
        #region Private Variable

        private string _collegeID;
        private string _name;
        private string _address;
        private string _city;
        private string _state;
        private string _country;
        private string _contactNumber;

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

        public CollegeModel(string name)
        {
            this.CollegeID = Guid.NewGuid().ToString();
            this.Name = name;
        }

        #endregion
    }
}
