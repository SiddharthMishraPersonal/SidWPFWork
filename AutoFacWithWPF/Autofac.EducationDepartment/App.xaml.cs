using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Text;
using AutofacExample.EducationDepartment.ViewModels;
using Autofac;
using AutofacExample.EducationDepartment.Registration;

namespace AutofacExample.EducationDepartment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);

            /*
             * Below code will Register the application
             * 
             */

            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationRegistration>();

            var container = builder.Build();
            var app = container.Resolve<ApplicationViewModel>();
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            var strBuilder = new StringBuilder("An unexpected error has occurred in Application.");

            strBuilder.AppendLine(exception.Message);
            strBuilder.AppendLine(exception.StackTrace);

            MessageBox.Show(strBuilder.ToString());

            Application.Current.Shutdown(1);
        }
    }
}
