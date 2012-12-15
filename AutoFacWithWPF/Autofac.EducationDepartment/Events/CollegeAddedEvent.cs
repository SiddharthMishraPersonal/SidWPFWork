using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutofacExample.EducationDepartment.Models;

namespace AutofacExample.EducationDepartment.Events
{
    public class CollegeAddedEvent : EventBase
    {
        public CollegeModel College { get; set; }

        public CollegeAddedEvent(CollegeModel college, object sender)
            : base(sender)
        {
            this.College = college;
        }
    }
}
