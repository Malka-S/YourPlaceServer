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
    public static int GetPriority()
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {

          var o = db.guest_table_member.FirstOrDefault();
          return (int)o.guestPriority;
        }
      }
      catch (Exception e)
      {
        throw e;
      }

    }
    public static int GetPriorityByFriend(int id, int f_id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {

          guest_table_member tm = db.guest_table_member.Where(e => e.guest_id == id & e.friend_id == f_id).FirstOrDefault();
          return (int)tm.guestPriority;
        }
      }
      catch
      {
        return 0;
      }
    }
    //פונקציה שמחשבת כמה להוסיף 
    public static int GetPriorityByFriendToAdd(int id, int f_id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {

          guest_table_member tm = db.guest_table_member.Where(e => e.guest_id == id & e.friend_id == f_id).FirstOrDefault();
          if ((bool)GetstatusOfFById(id, f_id)==false)
            return (int)tm.guestPriority*-1;
          return (int)tm.guestPriority;
        }
      }
      catch
      {
        return 0;
      }
    }

    public static int GetGuest1priority(int guest_id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          guest_table_member tm1 = db.guest_table_member.FirstOrDefault(u => u.guest_id == guest_id & u.guestPriority == 1);
          return (int)tm1.friend_id;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static int GetGuest2priority(int guest_id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          guest_table_member tm1 = db.guest_table_member.FirstOrDefault(u => u.guest_id == guest_id & u.guestPriority == 2);
          return (int)tm1.friend_id;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static int GetGuest3priority(int guest_id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          guest_table_member tm1 = db.guest_table_member.FirstOrDefault(u => u.guest_id == guest_id & u.guestPriority == 3);
          return (int)tm1.friend_id;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static bool GetstatusOfFById(int id, int f_id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {

          var o = db.guest_table_member.Where(e => e.guest_id == id & e.friend_id == f_id).FirstOrDefault();
          return (bool)o.like_or_not;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }
}
