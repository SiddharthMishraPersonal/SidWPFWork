﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutofacExample.EducationDepartment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ApplicationViewModel _appVM;
        public MainWindow()
        {

            InitializeComponent();

            //this._appVM = appVM;
            //this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        //void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    this.DataContext = _appVM;
        //}
    }
}
