using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using Telerik.Windows.Controls;
using AutofacExample.EducationDepartment.Views;
using AutofacExample.EducationDepartment.EventBase;
using AutofacExample.EducationDepartment.Events;
using System.Collections.ObjectModel;
using AutofacExample.EducationDepartment.Models;

namespace AutofacExample.EducationDepartment.ViewModels
{
    public class StudentViewModel : PageViewModel<ucStudentDetails>
    {
        #region Private

        private readonly IEventAggregator _eventAggregator;
        private string _selectedCollegeID = Guid.NewGuid().ToString();
        private ObservableCollection<StudentModel> _studentList = new ObservableCollection<StudentModel>();
        private ObservableCollection<StudentModel> _studentListPerCollege = new ObservableCollection<StudentModel>();

        public ObservableCollection<StudentModel> StudentListPerCollege
        {
            get
            {
                _studentListPerCollege.Clear();
                var ss = _studentList.Where(s => s.CollegeID == this.SelectedCollegeID).ToList();
                if (ss == null)
                {
                    return null;
                }

                foreach (var item in ss)
                {
                    this._studentListPerCollege.Add(item);
                }

                return _studentListPerCollege;
            }
        }

        #endregion

        #region Properties

        public string SelectedCollegeID
        {
            get { return _selectedCollegeID; }
            set
            {
                _selectedCollegeID = value;
                OnPropertyChanged(() => SelectedCollegeID);
                OnPropertyChanged(() => StudentListPerCollege);
            }
        }

        public ObservableCollection<StudentModel> StudentList
        {
            get
            {
                return _studentList;
            }
        }

        #endregion

        public StudentViewModel(ucStudentDetails ucStudentDetails, IEventAggregator eventAggregator)
            : base(ucStudentDetails)
        {
            this._eventAggregator = eventAggregator;

            //Add Student Event subscriber.
            this._eventAggregator
                .GetEvents<StudentAddedEvent>()
                .ObserveOnDispatcher()
                .Subscribe(e =>
                {
                    if (null == e.Student)
                        return;

                    this.StudentList.Add(e.Student);
                });
        }
    }
}
