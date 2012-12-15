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
        private ObservableCollection<StudentModel> _studentList = new ObservableCollection<StudentModel>();

        #endregion

        #region Properties

        public ObservableCollection<StudentModel> StudentList
        {
            get { return _studentList; }
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
