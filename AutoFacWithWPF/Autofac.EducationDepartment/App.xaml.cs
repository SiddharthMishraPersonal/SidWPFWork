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
using AutofacExample.EducationDepartment.Shared;

namespace AutofacExample.EducationDepartment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ISettingsService _settingsService;

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

            /*
             * SettingsService : Loading last saved settings.
             */
            string settings = AutofacExample.EducationDepartment.Properties.Settings.Default.UISetting;
            _settingsService = container.Resolve<ISettingsService>();

            if (!string.IsNullOrEmpty(settings))
            {
                _settingsService.SetState(settings);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            /*
             * Saving current application settings before exiting application.
             * 
             */
            AutofacExample.EducationDepartment.Properties.Settings.Default.UISetting = _settingsService.GetState();
            AutofacExample.EducationDepartment.Properties.Settings.Default.Save();
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
