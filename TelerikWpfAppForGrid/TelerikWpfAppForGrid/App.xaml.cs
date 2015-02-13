using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using TelerikWpfAppForGrid.ViewModel;

namespace TelerikWpfAppForGrid
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public App()
    {
      //this.InitializeComponent();

      var viewModel = new StudentViewModel();
      var view = new MainWindow();
      view.DataContext = viewModel;

      view.Show();
    }
  }
}
