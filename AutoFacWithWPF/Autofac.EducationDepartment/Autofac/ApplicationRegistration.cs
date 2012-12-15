using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using AutofacExample.EducationDepartment.ViewModels;
using AutofacExample.EducationDepartment.Views;
using AutofacExample.EducationDepartment.EventBase;


namespace AutofacExample.EducationDepartment.Autofac
{
    class ApplicationRegistration : Module
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

            builder.RegisterType<StudentViewModel>()
                .AsSelf()
                .SingleInstance();
        }

    }
}
