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
    public static int UpdateUser(Users user)
    {
      //אמור להיות update
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var q1 = db.Users.FirstOrDefault(u => u.user_id == user.user_id);
          //שמור שינוי
          db.SaveChanges();
          return 1;//יתכן שנשקול להוסיף את המספור האוטמטי החדש 
        }
      }
      catch
      {
        throw;
      }
    }
    public static string SalectUser(string mail)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        //לא מכיר את USERS
        // return db.Users.FirstOrDefault(u => u.user_email == mail);
        return "567";
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
          return 1;//יתכן שנשקול להוסיף את המספור האוטמטי החדש 

        }
      }
      catch
      {
        throw;
      }
    }
  }
}
