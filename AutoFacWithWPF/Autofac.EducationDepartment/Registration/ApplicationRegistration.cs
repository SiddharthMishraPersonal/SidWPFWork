using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using AutofacExample.EducationDepartment.ViewModels;
using AutofacExample.EducationDepartment.Views;
using AutofacExample.EducationDepartment.EventBase;


namespace AutofacExample.EducationDepartment.Registration
{
    public class ApplicationRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<EventAggregator>()
                .AsSelf()
                .As<IEventAggregator>()
                .SingleInstance();

            builder.RegisterType<MainWindow>()
                .AsSelf()
                .SingleInstance();

            //Each time new instance will be created for College
            builder.RegisterType<AddCollege>()
                .AsSelf()
               .InstancePerDependency();

            //Each time new instance will be created for Student
            builder.RegisterType<AddStudent>()
                .AsSelf()
               .InstancePerDependency();

            builder.RegisterType<ucCollegeDetails>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ucStudentDetails>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ApplicationViewModel>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<CollegeViewModel>()
                .AsSelf()
                .SingleInstance();

            //Each time new instance will be created for College
            builder.RegisterType<IndividualCollegeViewModel>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<StudentViewModel>()
                .AsSelf()
                .SingleInstance();

            //Each time new instance will be created for Student
            builder.RegisterType<IndividualStudentViewModel>()
                .AsSelf()
                .InstancePerDependency();

        }

    }
}
