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
    public static DAL.Guest ToDalGuest(Common.DTO.GuestDto g)
    {
      DAL.Guest gu = new DAL.Guest();
      gu.guest_id = g.guest_id;
      gu.guest_first_name = g.guest_first_name;
      gu.guest_last_name = g.guest_last_name;
      gu.guest_email = g.guest_email;
      //gu.guest_tz = g.guest_tz;
      ///....
      return gu;
    }
    public static Common.DTO.GuestDto ToDtoGuest(DAL.Guest g)
    {
      Common.DTO.GuestDto gu = new Common.DTO.GuestDto();
      gu.guest_id = g.guest_id;
      gu.guest_first_name = g.guest_first_name;
      gu.guest_last_name = g.guest_last_name;
      gu.guest_email = g.guest_email;
     // gu.guest_tz = g.guest_tz;
      ///....
      return gu;

    }
    public static List<DAL.Guest> ToDalGuestList(List<Common.DTO.GuestDto> l)
    {
      List<DAL.Guest> le = new List<DAL.Guest>();
      foreach (var item in l)
      {
        le.Add(ToDalGuest(item));
      }
      return le;
    }

    public static List<Common.DTO.GuestDto> ToDtoGuestList(List<DAL.Guest> l)
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
