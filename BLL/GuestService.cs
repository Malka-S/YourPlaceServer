using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class GuestService
  {
    public static List<Common.DTO.GuestDto> GetAllGuests()
    {
      return Converters.GuestConverter.ToDtoGuestList(DAL.GuestDal.SelectGuests());
    }
    public static List<Common.DTO.GuestDto> GetGuestListByCategory(string category)
    {
      return Converters.GuestConverter.ToDtoGuestList(DAL.GuestDal.SelectGuestsByCatagory(category));
    }

    public static List<Common.DTO.BaseCodeDto> GetCatagoryList()
    {
      return Converters.GuestConverter.ToDtoCatagoryList(DAL.GuestDal.SelectCatagoryList());
    }
    public static int AddGuest(Common.DTO.GuestDto guest)
    {
      try
      {
        return DAL.GuestDal.AddGuest(Converters.GuestConverter.ToDalGuest(guest));
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    public static int UpdateGuest(Common.DTO.GuestDto guest)
    {
      try
      {
        return DAL.GuestDal.UpdateGuest(Converters.GuestConverter.ToDalGuest(guest));
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    public static int DeleteGuest(Common.DTO.GuestDto guest)
    {
      try
      {
        return DAL.GuestDal.DeleteGuest(Converters.GuestConverter.ToDalGuest(guest));
      }
      catch (Exception e)
      {

        throw e;
      }
    }
  }
}
