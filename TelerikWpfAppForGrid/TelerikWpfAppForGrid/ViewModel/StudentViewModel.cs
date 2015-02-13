using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;
using TelerikWpfAppForGrid.Model;

namespace TelerikWpfAppForGrid.ViewModel
{
  public class StudentViewModel : ViewModelBase
  {
    #region Private Member Variables

    string _exportFormatType;
    string _firstName;
    string _middleName;
    string _lastName;
    string _college;
    string _grade;

    #endregion

    #region Properties

    public ObservableCollection<StudentModel> StudentCollection { get; set; }
    public ObservableCollection<string> ExportFormatTypes { get; set; }

    public string ExportFormatType
    {
      get { return _exportFormatType; }
      set
      {
        _exportFormatType = value;
        OnPropertyChanged("ExportFormat");
        CommandManager.InvalidateRequerySuggested();
        ExportCommand_CanExcute(null);
      }
    }

    public string Grade
    {
      get { return _grade; }
      set
      {
        _grade = value;

        OnPropertyChanged("Grade");
      }
    }

    public string College
    {
      get { return _college; }
      set
      {
        _college = value;

        OnPropertyChanged("College");
      }
    }

    public string LastName
    {
      get { return _lastName; }
      set
      {
        _lastName = value;

        OnPropertyChanged("LastName");
      }
    }

    public string MiddleName
    {
      get { return _middleName; }
      set
      {
        _middleName = value;

        OnPropertyChanged("MiddleName");
      }
    }

    public string FirstName
    {
      get { return _firstName; }
      set
      {
        _firstName = value;

        OnPropertyChanged("FirstName");
      }
    }

    #endregion

    #region Constructors

    public StudentViewModel()
    {
      ExportFormatTypes = new ObservableCollection<string>();
      ExportFormatTypes.Add("Excel");
      ExportFormatTypes.Add("PDF");
      ExportFormatTypes.Add("Html");

      ExportFormatType = ExportFormatTypes.FirstOrDefault();

      StudentCollection = new ObservableCollection<StudentModel>();

      StudentCollection.Add(new StudentModel()
      {
        FirstName = "Siddharth",
        MiddleName = "Kumar",
        LastName = "Mishra",
        Grade = "5",
        College = "College Of Engineering, Pune"
      });

      StudentCollection.Add(new StudentModel()
      {
        FirstName = "Sandeep",
        MiddleName = "Parimal",
        LastName = "Sihag",
        Grade = "7",
        College = "Engineering College Of Bikaner, Bikaner"
      });

      StudentCollection.Add(new StudentModel()
      {
        FirstName = "Rohit",
        MiddleName = "Rajesh",
        LastName = "Khanna",
        Grade = "8",
        College = "Dheerubhai Ambani College of Engineering, Surat"
      });

      StudentCollection.Add(new StudentModel()
      {
        FirstName = "Samrat",
        MiddleName = "",
        LastName = "Chakrawarti",
        Grade = "3",
        College = "University Of Rajasthan, Jaipur"
      });

    }

    #endregion

    #region Command

    ICommand _exportCommand;

    public ICommand ExportCommand
    {
      get
      {
        if (_exportCommand == null)
          _exportCommand = new DelegateCommand(ExportCommand_Execute, ExportCommand_CanExcute);
        return _exportCommand;
      }

    }

    void ExportCommand_Execute(object param)
    {
      var StudentGridView = param as RadGridView;

      switch (ExportFormatType)
      {
        case "Html": break;
        case "Excel": ExportInExcel(param); break;
        case "PDF": break;

        default:
          break;
      }

      ExportInExcel(StudentGridView);
    }

    private void ExportInExcel(object param)
    {
      RadGridView StudentGridView = param as RadGridView;
      string extension = "xls";
      SaveFileDialog dialog = new SaveFileDialog()
      {
        DefaultExt = extension,
        Filter = String.Format("{1} files (*.{0})|*.{0}|All files (*.*)|*.*", extension, "Excel"),
        FilterIndex = 1
      };

      if (dialog.ShowDialog() == true)
      {
        using (Stream stream = dialog.OpenFile())
        {
          StudentGridView.Export(stream,
           new GridViewExportOptions()
           {
             Format = ExportFormat.Html,
             ShowColumnHeaders = true,
             ShowColumnFooters = true,
             ShowGroupFooters = false,
           });
        }
      }
    }

    bool ExportCommand_CanExcute(object param)
    {
      //if (string.IsNullOrEmpty(ExportFormat))
      //  return false;
      return true;
    }

    #endregion
  }
}
