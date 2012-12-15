using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutofacExample.EducationDepartment.EventBase;
using AutofacExample.EducationDepartment.Models;

namespace AutofacExample.EducationDepartment.Events
{
    public class StudentAddedEvent : EventBase
    {
        public StudentModel Student { get; set; }

        public StudentAddedEvent(StudentModel student, object sender)
            : base(sender)
        {
            this.Student = student;
        }
    }
}
