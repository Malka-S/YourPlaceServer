using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class TMDal
  {
    public static int AddGuestTM(guest_table_member guestTM)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {

          guest_table_member tm1 = db.guest_table_member.Add(guestTM);
          //שמור שינוי
          db.SaveChanges();
          return 1;//יתכן שנשקול להוסיף את המספור האוטמטי החדש 
        }

      }
      catch (Exception e)
      {
        throw e;
      }
    }

  }
}
