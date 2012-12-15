using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace AutofacExample.EducationDepartment.ViewModels
{
    public abstract class PageViewModel<TView> : ViewModelBase
        where TView : class
    {
        private TView _view;

        public TView View
        {
            get { return _view; }
            protected set
            {
                if (value != _view)
                {
                    _view = value;
                    OnPropertyChanged(() => this.View);
                }
            }
        }

        public PageViewModel(TView view)
        {
            this.View = view;
        }
    }
}
