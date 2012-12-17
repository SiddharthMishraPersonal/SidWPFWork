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

namespace AutofacExample.EducationDepartment.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        #region Private Member Variable

        Window _currentView;
        private readonly IEventAggregator _eventAggregator;
        private CollegeViewModel _collegeVM;
        private StudentViewModel _studentVM;

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

            this.CurrentView.Show();
        }
    }
}
