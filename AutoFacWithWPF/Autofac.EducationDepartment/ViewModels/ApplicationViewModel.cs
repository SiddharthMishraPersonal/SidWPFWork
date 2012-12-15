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

        string _name;
        Window _currentView;
        private readonly IEventAggregator _eventAggregator;

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

        public ApplicationViewModel(MainWindow mainWindow, IEventAggregator eventAggregator)
        {
            this.CurrentView = mainWindow;
            this.CurrentView.DataContext = this;
            this._eventAggregator = eventAggregator;

            this.CurrentView.Show();
        }
    }
}
