using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using Telerik.Windows.Controls;
using System.Windows;
using AutofacExample.EducationDepartment.EventBase;
using AutofacExample.EducationDepartment.Models;
using System.Collections.ObjectModel;
using AutofacExample.EducationDepartment.Events;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace AutofacExample.EducationDepartment.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        #region Private Member Variable

        Window _currentView;
        private readonly IEventAggregator _eventAggregator;
        private CollegeViewModel _collegeVM;
        private StudentViewModel _studentVM;
        private ObservableCollection<StudentModel> _studentRepository = new ObservableCollection<StudentModel>();

        private CollegeModel _selectedCollege;
        private StudentModel _selectedStudent;
        private RadGridView _studentGridView;

        #endregion

        #region Properties

        public Window CurrentView
        {
            get { return _currentView; }
            set
            {
                if (value != _currentView)
                {
                    _currentView = value;
                    OnPropertyChanged(() => CurrentView);
                }
            }
        }

        public StudentViewModel StudentVM
        {
            get { return _studentVM; }
        }

        public CollegeModel SelectedCollege
        {
            get { return _selectedCollege; }
            set
            {
                if (value != _selectedCollege)
                {
                    _selectedCollege = value;
                    OnPropertyChanged(() => this.SelectedCollege);
                    this._studentVM.SelectedCollegeID = this.SelectedCollege.CollegeID;
                }
            }
        }

        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (value != _selectedStudent)
                {
                    _selectedStudent = value;
                    OnPropertyChanged(() => this.SelectedStudent);
                }
            }
        }

        public CollegeViewModel CollegeVM
        {
            get { return _collegeVM; }
        }

        #endregion

        public ApplicationViewModel(MainWindow mainWindow, IEventAggregator eventAggregator,
            CollegeViewModel collegeVM, StudentViewModel studentVM)
        {
            this.CurrentView = mainWindow;
            this.CurrentView.DataContext = this;
            this._eventAggregator = eventAggregator;
            this._collegeVM = collegeVM;
            this._studentVM = studentVM;

            AddColleges();
            AddStudentsToColleges();

            UserControl ucStudentDetails = this.CurrentView.FindName("ucStudentDetails") as UserControl;
            _studentGridView = ucStudentDetails.FindName("rgvStudentList") as RadGridView;

            this.CurrentView.Show();
        }

        private void FilterStudentsOnCollegeSelection(string collegeID)
        {
            if (_studentGridView == null)
                return;

            IColumnFilterDescriptor countryFilter = this._studentGridView.Columns["Country"].ColumnFilterDescriptor;
            countryFilter.SuspendNotifications();

            countryFilter.DistinctFilter.AddDistinctValue("USA");
            countryFilter.DistinctFilter.AddDistinctValue("Canada");
            countryFilter.DistinctFilter.AddDistinctValue("Germany");

            countryFilter.ResumeNotifications();

            this._studentGridView.FilterDescriptors.ResumeNotifications();
        }

        #region College

        public void AddColleges()
        {
            CollegeModel college;

            college = new CollegeModel();
            college.Name = "Air University";
            college.Address = "XYZ 1234567878900";
            college.City = "Indianapolis";
            college.State = "Indiana";
            college.Country = "USA";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel();
            college.Name = "Guru Govind Sing University";
            college.Address = "Block 214, Johnson Road";
            college.City = "Chandigarh";
            college.State = "Punjab";
            college.Country = "India";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel();
            college.Name = "Air University";
            college.Address = "XYZ 1234567878900";
            college.City = "Indianapolis";
            college.State = "Indiana";
            college.Country = "USA";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel();
            college.Name = "Indiana University";
            college.Address = "7733 Santa Monica Dr.,";
            college.City = "Indianapolis";
            college.State = "Indiana";
            college.Country = "USA";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel();
            college.Name = "Sinhgarh University";
            college.Address = "P.O. 13564, Sinhgarh Road";
            college.City = "Pune";
            college.State = "Maharashtra";
            college.Country = "India";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel();
            college.Name = "University Of Rajasthan";
            college.Address = "J.L.N. Marg, Bapu Nagar, Near Birla Mandir";
            college.City = "Jaipur";
            college.State = "Rajasthan";
            college.Country = "India";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);
        }

        #endregion

        #region Student

        private void AddStudentsToColleges()
        {
            StudentModel student;
            foreach (CollegeModel college in this._collegeVM.CollegeList)
            {
                student = new StudentModel(college.CollegeID);
                student.College = college.Name;
                student.Name = "Siddharth Mishra";
                student.Address = "J.L.N. Marg, Bapu Nagar, Near Birla Mandir";
                student.City = "Jaipur";
                student.State = "Rajasthan";
                student.Subject = "English";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college.CollegeID);
                student.College = college.Name;
                student.Name = "Sumit Ramola";
                student.Address = "Grib Navaz Society";
                student.City = "Bikaner";
                student.State = "Rajasthan";
                student.Subject = "Arts and Drawing";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college.CollegeID);
                student.College = college.Name;
                student.Name = "Richa Sharma";
                student.Address = "C-12/3/51, CAD Quarters, JNV Colony";
                student.City = "Jodhpur";
                student.State = "Rajasthan";
                student.Subject = "Social Science";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college.CollegeID);
                student.College = college.Name;
                student.Name = "Air University";
                student.Address = "XYZ 1234567878900";
                student.City = "Indianapolis";
                student.State = "Indiana";
                student.Subject = "Hindi";
                student.Country = "USA";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college.CollegeID);
                student.College = college.Name;
                student.Name = "Albama A&M University";
                student.Address = "13641, NE , 24th St.";
                student.City = "Bellevue";
                student.State = "Washington";
                student.Subject = "Physics";
                student.Country = "USA";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college.CollegeID);
                student.College = college.Name;
                student.Name = "Sinhgarh University";
                student.Address = "P.O. 13564, Sinhgarh Road";
                student.City = "Pune";
                student.State = "Maharashtra";
                student.Subject = "Science";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college.CollegeID);
                student.College = college.Name;
                student.Name = "University Of Rajasthan";
                student.Address = "J.L.N. Marg, Bapu Nagar, Near Birla Mandir";
                student.City = "Jaipur";
                student.State = "Rajasthan";
                student.Subject = "Maths";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);
            }

        }

        #endregion

    }
}
