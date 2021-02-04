using Common.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
  public class EventConverter
  {
    
    public static Event ToDalEvent(EventDto e)
    {
      Event ev = new Event();
      ev.event_id = e.event_id;
      ev.invitation_file = e.invitation_file;
      ev.event_type_id = e.event_type_id;
      ev.event_date = e.event_date;
      ev.event_des = e.event_des;
      ev.user_id = e.user_id;
      ev.due_date = e.due_date;
      ///....
      return ev;
    }
    public static EventDto ToDtoEvent(Event e)
    {
      EventDto ev = new EventDto();
      ev.event_id = e.event_id;
      ev.invitation_file = e.invitation_file;
      return ev;

    }
    public static List<Event> ToDalEventList(List<EventDto> l)
    {
      List<Event> le = new List<Event>();
      foreach (var item in l)
      {
        le.Add(ToDalEvent(item));

      }
      return le;
    }

    public static List<EventDto> ToDtoEventList(List<Event> l)
    {
      List<EventDto> le = new List<EventDto>();
      foreach (var item in l)
      {
        le.Add(ToDtoEvent(item));

      }
      return le;
    }

    public static List<Guest_catagory> ToDalCategoryiesList(List<BaseCodeDto> l)
    {
      List<Guest_catagory> le = new List<Guest_catagory>();
      foreach (var item in l)
      {
        le.Add(ToDalGuest_catagory(item));

      }
      return le;
    }

    public static List<BaseCodeDto> ToDtoEventTypeList(List<EventType> l)
    {
      List<BaseCodeDto> le = new List<BaseCodeDto>();
      foreach (var item in l)
      {
        le.Add(ToDtoBaseCode(item.event_type_id, item.event_type_des));

      }
      return le;
    }
   
    public static Guest_catagory ToDalGuest_catagory(BaseCodeDto bc)
    {
      Guest_catagory tc = new Guest_catagory();
     tc.guest_catagory_id= bc.Id ;
     tc.guest_catagory_des= bc.Des ;
      return tc;
    }
    public static BaseCodeDto ToDtoBaseCode(int id, string des)
    {
      BaseCodeDto bc = new BaseCodeDto();
      bc.Id = id;
      bc.Des = des;
      return bc;
    }
  }
}
