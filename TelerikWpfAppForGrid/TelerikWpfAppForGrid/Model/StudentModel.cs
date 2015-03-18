using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikWpfAppForGrid.Model
{
  public class StudentModel
  {

    string _firstName;
    string _middleName;
    string _lastName;
    string _college;
    string _grade;

    public string Grade
    {
      get { return _grade; }
      set { _grade = value; }
    }

    public string College
    {
      get { return _college; }
      set { _college = value; }
    }

    public string LastName
    {
      get { return _lastName; }
      set { _lastName = value; }
    }

    public string MiddleName
    {
      get { return _middleName; }
      set { _middleName = value; }
    }

    public string FirstName
    {
      get { return _firstName; }
      set { _firstName = value; }
    }

  }
}
