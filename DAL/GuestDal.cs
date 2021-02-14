using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class GuestDal
  {
    public static int AddGuest(Guest guest)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          //אם ישנו כבר אורח עם כזה ID
          //משום מה הפונקציה לא עובדת לא בטוחה מה הסוג של q1
          while (db.Guest.FirstOrDefault(g => g.guest_id == guest.guest_id) == guest)
            //תוסיף 1 לID
            guest.guest_id += guest.guest_id + 1;
          Guest q1 = db.Guest.Add(guest);
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
    public static int UpdateGuest(Guest guest)
    {
      //אמור להיות update
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var q1 = db.Guest.FirstOrDefault(g => g.guest_id == guest.guest_id);
          //שמור שינוי
          q1.guest_first_name = guest.guest_first_name;
          q1.guest_last_name = guest.guest_last_name;
          q1.guest_email = guest.guest_email;
          q1.guest_message_befor = guest.guest_message_befor;
          q1.guest_message_after = guest.guest_message_after;
          // q1.guest_category_id = guest.guest_category_id;
          db.SaveChanges();
          return 1;//יתכן שנשקול להוסיף את המספור האוטמטי החדש 
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static List<Guest> SelectGuestsByCatagory(string category)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {

        return db.Guest.Where(e => e.Guest_catagory.guest_catagory_des == category).ToList();
      }
    }
    public static List<Guest> SelectGuestsById(int id)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        return db.Guest.Where(e => e.guest_id == id).ToList();
      }
    }

    public static List<string> GetGuestMail(int id)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        List<string> guestMail = null;

        string query = @"SELECT e.guest_email FROM Guest e  where e.event_id=" + id + ";";
        SqlCommand cmd = new SqlCommand(query);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
          int i = 0;
          while (dr.Read())
            guestMail.Add(dr.GetString(i++));
        }
        else
          Console.WriteLine("No data found.");
        
        return guestMail;
      }
    }
    public static List<Guest> SelectGuests()
    {
      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        //לא נראה לי צריך שורות אלו
        //Context.Connection.Open();
        //Content.Connection.Open();
        return db.Guest.ToList();
      }
    }

    public static List<Guest_catagory> SelectCatagoryList()
    {
      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        //List<EventType> f = new List<EventType>();
        //f.Add();
        List<Guest_catagory> f = db.Guest_catagory.ToList();
        return f;
      }
    }
    public static int DeleteGuest(int id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          //אמור למחוק את האורח שקיבל 
          var q1 = db.Guest.FirstOrDefault(e => e.guest_id == id);
          if (q1 == null)
            return 0;
          else
          {
            //מחק
            db.Guest.Remove(q1);
            //שמור שינוי
            db.SaveChanges();
            //החזר 1
            return 1;
          }
        }
      }
      catch (Exception e)
      {
        throw e;
      }

    }
  }
}
