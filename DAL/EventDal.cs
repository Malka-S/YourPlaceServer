using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DAL
{
  public class EventDal
  {
    public static List<Event> SelectEvents()
    {
      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        //Context.Connection.Open();
        //Content.Connection.Open();

        return db.Event.ToList();
      }
    }

    public static int UpdateEvent(Event event1)
    {
      //אמור להיות update
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var ev = db.Event.FirstOrDefault(e => e.event_id == event1.event_id);
          //שמור שינוי
          ev.invitation_file = event1.invitation_file;
          ev.event_type_id = event1.event_type_id;
          ev.event_date = event1.event_date;
          ev.event_des = event1.event_des;
          ev.user_id = event1.user_id;
          ev.due_date = event1.due_date;
          ev.num_places_around_a_table = event1.num_places_around_a_table;
          ev.num_tables = event1.num_tables;
          db.SaveChanges();
          return 1;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static string GetInvatation(int id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {

          Event event1 = db.Event.FirstOrDefault(e => e.event_id == id);

          return (string)event1.invitation_file;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
      //using (YourPlaceEntities db = new YourPlaceEntities())
      //{
      //  string invatation = null;

      //  string query = @"SELECT e.invitation_file FROM Event e  where e.event_id=" + id + ";";
      //  SqlCommand cmd = new SqlCommand(query);
      //  SqlDataReader dr = cmd.ExecuteReader();

      //  if (dr.HasRows)
      //    while (dr.Read())
      //      invatation = dr.GetString(0);
      //  else
      //    Console.WriteLine("No data found.");

      //  return invatation;
      //}
    }

    public static string GetNameOfEvent(int id)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {

          Event event1 = db.Event.FirstOrDefault(e => e.event_id == id);

          return (string)event1.event_des;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
    
    }

    public static Event SalectEvent(int code)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        return db.Event.FirstOrDefault(e => e.event_id == code);
      }
    }
    public static Event SalectEventByUserId(int u_id)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        return db.Event.FirstOrDefault(e => e.user_id == u_id);
      }
    }
    public static int UpdateCategoryiesList(List<Guest_catagory> CategoryiesList)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          foreach (var item in CategoryiesList)
          {
            db.Guest_catagory.Add(item);
          }
          db.SaveChanges();
          return 1;
        }
      }
      catch
      {
        throw;
      }
    }
    public static List<EventType> SelectEventType()
    {
      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        List<EventType> f = db.EventType.ToList();
        return f;
      }
    }


    //public static int UpdateEvent(Event event)
    //{
    //    try
    //    {
    //        using (YourPlaceEntities db = new YourPlaceEntities())
    //        {
    //            var q1=db.Event.FirstOrDefault(e => e.event_code==event.event_code);
    //            if (q1 == null)
    //                return 0;
    //            else
    //            {
    //                //עדכן
    //                ////ctx.Workers.Attach(worker);
    //                // ctx.Entry(worker).State = EntityState.Modified;

    //                q1.event_code = event.event_code;

    //                //שמור שינוי
    //                return db.SaveChanges();

    //            }
    //        }
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}

    public static int AddEvent(Event event1)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var q1 = db.Event.Add(event1);
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
    public static int DeleteEvent(int code)
    {
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var q1 = db.Event.FirstOrDefault(e => e.event_id == code);
          if (q1 == null)
            return 0;
          else
          {
            //מחק
            db.Event.Remove(q1);
            //שמור שינוי
            db.SaveChanges();
            //החזר id
            return q1.event_id;
          }
        }
      }
      catch
      {
        throw;
      }
    }
    public static int GetHID()
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {

        return db.Event.Max(e => e.event_id);
      }
    }
    public static int GetNumOfSeatsAroundTable()
    {
      using (YourPlaceEntities db = new YourPlaceEntities())
      {

        var o = db.Event.FirstOrDefault();
        return (int)o.num_places_around_a_table;
      }

    }
  }
}
