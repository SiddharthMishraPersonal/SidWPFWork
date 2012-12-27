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
using System.Windows.Input;
using AutofacExample.EducationDepartment.Shared;
using AutofacExample.EducationDepartment.Views;

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

        private Func<IndividualCollegeViewModel> _individualCollegeVMFactory;
        private Func<IndividualStudentViewModel> _individualStudentVMFactory;

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
            CollegeViewModel collegeVM, StudentViewModel studentVM,
           Func<IndividualCollegeViewModel> individualCollegeVM, Func<IndividualStudentViewModel> individualStudentVM)
        {
            this.CurrentView = mainWindow;
            this.CurrentView.DataContext = this;
            this._eventAggregator = eventAggregator;
            this._collegeVM = collegeVM;
            this._studentVM = studentVM;
            this._individualCollegeVMFactory = individualCollegeVM;
            this._individualStudentVMFactory = individualStudentVM;

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

            college = new CollegeModel("Air University");
            college.Address = "XYZ 1234567878900";
            college.City = "Indianapolis";
            college.State = "Indiana";
            college.Country = "USA";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel("Guru Govind Sing University");            
            college.Address = "Block 214, Johnson Road";
            college.City = "Chandigarh";
            college.State = "Punjab";
            college.Country = "India";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel("Kurukshetra University");
            college.Address = "XYZ 1234567878900";
            college.City = "Indianapolis";
            college.State = "Indiana";
            college.Country = "USA";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel("Indiana University");
            college.Address = "7733 Santa Monica Dr.,";
            college.City = "Indianapolis";
            college.State = "Indiana";
            college.Country = "USA";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel("Sinhgarh University");
            college.Address = "P.O. 13564, Sinhgarh Road";
            college.City = "Pune";
            college.State = "Maharashtra";
            college.Country = "India";
            college.ContactNumber = "371-356-8546";
            this._collegeVM.CollegeList.Add(college);

            college = new CollegeModel("University Of Rajasthan");
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
                student = new StudentModel(college, "Siddharth Mishra", "English");
                student.Address = "J.L.N. Marg, Bapu Nagar, Near Birla Mandir";
                student.City = "Jaipur";
                student.State = "Rajasthan";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college, "Sumit Ramola", "Arts and Drawing");
                student.Address = "Grib Navaz Society";
                student.City = "Bikaner";
                student.State = "Rajasthan";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college, "Sandeep Solanki", "Hindi");
                student.Name = "Richa Sharma";
                student.Address = "C-12/3/51, CAD Quarters, JNV Colony";
                student.City = "Jodhpur";
                student.State = "Rajasthan";
                student.Subject = "Social Science";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college,"Sandeep Solanki", "Hindi");
                student.Name = "Sandeep ";
                student.Address = "XYZ 1234567878900";
                student.City = "Indianapolis";
                student.State = "Indiana";
                student.Subject = "Hindi";
                student.Country = "USA";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college,"Louis Kusic", "Quantum Physics");
                student.Address = "13641, NE , 24th St.";
                student.City = "Bellevue";
                student.State = "Washington";
                student.Country = "USA";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college,"Richard Hughes", "Business Commerce");
                student.Address = "P.O. 13564, Sinhgarh Road";
                student.City = "Pune";
                student.State = "Maharashtra";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);

                student = new StudentModel(college,"Makarand Devalekar", "Maths");
                student.Address = "J.L.N. Marg, Bapu Nagar, Near Birla Mandir";
                student.City = "Jaipur";
                student.State = "Rajasthan";
                student.Country = "India";
                student.ContactNumber = "371-356-8546";
                this._studentVM.StudentList.Add(student);
            }

        }

        #endregion

        #region College Commands

        ICommand _createNewCollegeCommand;

        /// <summary>
        /// Command to create new College.
        /// </summary>
        public ICommand CreateNewCollegeCommand
        {
            get
            {
                if (_createNewCollegeCommand == null)
                {
                    _createNewCollegeCommand = new RelayCommands(param => this.CreateNewCollegeCommand_Execute(param),
                    param => this.CreateNewCollegeCommand_CanExecute(param));
                }
                return _createNewCollegeCommand;
            }
        }

        bool CreateNewCollegeCommand_CanExecute(object param)
        {
            return true;
        }

        void CreateNewCollegeCommand_Execute(object param)
        {
            IndividualCollegeViewModel indCollegeVM = this._individualCollegeVMFactory();

            //Set the DataContext
            (indCollegeVM.View as AddCollege).DataContext = indCollegeVM;

            //Show dialog box to add College.
            (indCollegeVM.View as AddCollege).Owner = this.CurrentView;
            (indCollegeVM.View as AddCollege).ShowDialog();
        }

        #endregion

        #region Student Commands

        ICommand _createStudentCommand;

        /// <summary>
        /// Command to create new Student for a college.
        /// </summary>
        public ICommand CreateStudentCommand
        {
            get
            {
                if (_createStudentCommand == null)
                {
                    _createStudentCommand = new RelayCommands(param => this.CreateStudentCommand_Execute(param),
                        param => this.CreateStudentCommand_CanExecute(param));
                }
                return _createStudentCommand;
            }
        }

        bool CreateStudentCommand_CanExecute(object param)
        {
            if (this.SelectedCollege == null)
                return false;
            return true;
        }

        void CreateStudentCommand_Execute(object param)
        {
            IndividualStudentViewModel indStudentVM = this._individualStudentVMFactory();
            //Select college to add Student
            indStudentVM.College = this.SelectedCollege;

            //Set the DataContext
            (indStudentVM.View as AddStudent).DataContext = indStudentVM;

            //Show dialog box to add student.
            (indStudentVM.View as AddStudent).Owner = this.CurrentView;
            (indStudentVM.View as AddStudent).ShowDialog();
        }

        #endregion

    }
}
