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
      try
      {
        using (YourPlaceEntities db = new YourPlaceEntities())
        {
          var q1 = db.Event.FirstOrDefault(e => e.event_id == event1.event_id);
          db.SaveChanges();
          return 1;
        }
      }
      catch
      {
        throw;
      }
    }

   
    public static Event SalectEvent(int code)
    {

      using (YourPlaceEntities db = new YourPlaceEntities())
      {
        return db.Event.FirstOrDefault(e => e.event_id == code);
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
        //List<EventType> f = new List<EventType>();
        //f.Add();
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

//    public static int AddEvent(Event event)
//    {
//      try
//      {
//        using (YourPlaceEntities db = new YourPlaceEntities())
//        {
//          var q1 = db.Event.Add(event);
//    //שמור שינוי
//    db.SaveChanges();
//          return 1;//יתכן שנשקול להוסיף את המספור האוטמטי החדש 

//        }
//}
//      catch
//{
//  throw;
//}
//    }
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
            //החזר 1
            return 1;
          }
        }
      }
      catch
      {
        throw;
      }
    }
  }
}
