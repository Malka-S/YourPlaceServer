using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class UserDal
  {
    public static List<Users> SelectUsers()
    {
      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        //Context.Connection.Open();
        // Content.Connection.Open();

        return db.Users.ToList();
      }
    }
    public static int GetHID()
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {

        return db.Users.Max(e => e.user_id);
      }
    }
    public static int UpdateUser(Users user)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var q1 = db.Users.FirstOrDefault(u => u.user_id == user.user_id);
          db.SaveChanges();
          return 1;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static bool SalectUser(string mail, string password)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        Users q1 = db.Users.FirstOrDefault(u => u.user_email == mail & u.user_password == password);
        if (q1 != null)
          return true;
        return false;
      }
    }
    public static int AddUser(Users user)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var q1 = db.Users.Add(user);
          //שמור שינוי
          db.SaveChanges();
          return q1.user_id;
          //return 1;//יתכן שנשקול להוסיף את המספור האוטמטי החדש 

        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }
}
