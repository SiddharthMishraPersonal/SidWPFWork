using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace AutofacExample.EducationDepartment.Shared
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (null == handler)
                return;

            if (null != propertyExpression)
            {
                var e = new PropertyChangedEventArgs(((MemberExpression)propertyExpression.Body).Member.Name);
                handler(this, e);
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (null != PropertyChanged)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
