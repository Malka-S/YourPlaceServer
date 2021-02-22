using Common.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
  public class GuestConverter
  {
    public static Guest ToDalGuest(GuestDto g)
    {
       Guest gu = new  Guest();
      Random rand = new Random();
      //עשיתי מספרים גבוהים כי ךא עובד הבדיקה
      gu.guest_id = rand.Next(100,10000);
      gu.guest_first_name = g.guest_first_name;
      gu.guest_last_name = g.guest_last_name;
      gu.guest_email = g.guest_email;
      gu.gender = g.gender;
      //gu.guest_tz = g.guest_tz;
      gu.guest_message_befor = g.guest_message_befor;
      gu.guest_message_after = g.guest_message_after;
      return gu;
    }
    public static Guest ToDalGuestEdit(GuestDto g)
    {
      Guest gu = new Guest();

      gu.guest_id = g.guest_id;
      gu.guest_first_name = g.guest_first_name;
      gu.guest_last_name = g.guest_last_name;
      gu.guest_email = g.guest_email;
      gu.gender = g.gender;
      //gu.guest_tz = g.guest_tz;
      gu.guest_message_befor = g.guest_message_befor;
      gu.guest_message_after = g.guest_message_after;
      return gu;
    }
    public static Common.DTO.GuestDto ToDtoGuest( Guest g)
    {
      Common.DTO.GuestDto gu = new Common.DTO.GuestDto();
      gu.guest_id = g.guest_id;
      gu.guest_first_name = g.guest_first_name;
      gu.guest_last_name = g.guest_last_name;
      gu.guest_email = g.guest_email;
      //gu.guest_tz = g.guest_tz;
      gu.guest_message_befor = g.guest_message_befor;
      gu.guest_message_after = g.guest_message_after;
      return gu;

    }
    public static List< Guest> ToDalGuestList(List<Common.DTO.GuestDto> l)
    {
      List< Guest> le = new List< Guest>();
      foreach (var item in l)
      {
        le.Add(ToDalGuest(item));
      }
      return le;
    }

    public static List<Common.DTO.GuestDto> ToDtoGuestList(List< Guest> l)
    {
      List<Common.DTO.GuestDto> le = new List<Common.DTO.GuestDto>();
      foreach (var item in l)
      {
        le.Add(ToDtoGuest(item));
      }
      return le;
    }

    public static List<BaseCodeDto> ToDtoCatagoryList(List<Guest_catagory> l)
    {
      List<BaseCodeDto> le = new List<BaseCodeDto>();
      foreach (var item in l)
      {
        le.Add(ToDtoBaseCode(item.guest_catagory_id, item.guest_catagory_des));

      }
      return le;
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
