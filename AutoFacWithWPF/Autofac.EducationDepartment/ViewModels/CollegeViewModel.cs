using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using Telerik.Windows.Controls;
using AutofacExample.EducationDepartment.Views;
using System.Collections.ObjectModel;
using AutofacExample.EducationDepartment.Models;
using AutofacExample.EducationDepartment.EventBase;
using AutofacExample.EducationDepartment.Events;

namespace AutofacExample.EducationDepartment.ViewModels
{
    public class CollegeViewModel : PageViewModel<ucCollegeDetails>
    {
        #region Private

        private readonly IEventAggregator _eventAggregator;
        private ObservableCollection<CollegeModel> _collegeList = new ObservableCollection<CollegeModel>();

        #endregion

        #region Properties

        public ObservableCollection<CollegeModel> CollegeList
        {
            get { return _collegeList; }
        }

        #endregion

        public CollegeViewModel(ucCollegeDetails ucCollegeViewDetails, IEventAggregator eventAggregator)
            : base(ucCollegeViewDetails)
        {
            this._eventAggregator = eventAggregator;

            this._eventAggregator
                .GetEvents<CollegeAddedEvent>()
                .ObserveOnDispatcher()
                .Subscribe(e =>
                {
                    if (null != e.College)
                        return;

                    this.CollegeList.Add(e.College);
                });
        }
    }
}
