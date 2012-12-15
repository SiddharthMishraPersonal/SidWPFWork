using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacExample.EducationDepartment.Events
{
    public class EventBase
    {
        public object Sender { get; private set; }

        public EventBase(object sender)
        {
            this.Sender = sender;
        }
    }
}
