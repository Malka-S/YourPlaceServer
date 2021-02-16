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
      try
      {
        return Converters.GuestConverter.ToDtoGuestList(DAL.GuestDal.SelectGuests());
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static List<Common.DTO.GuestDto> GetGuestListByCategory(string category)
    {
      try
      {
        return Converters.GuestConverter.ToDtoGuestList(DAL.GuestDal.SelectGuestsByCatagory(category));
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static List<Common.DTO.GuestDto> GetGuestById(int id)
    {
      try
      {
        return Converters.GuestConverter.ToDtoGuestList(DAL.GuestDal.SelectGuestsById(id));
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static List<Common.DTO.BaseCodeDto> GetCatagoryList()
    {
      try
      {
        return Converters.GuestConverter.ToDtoCatagoryList(DAL.GuestDal.SelectCatagoryList());
      }
      catch (Exception e)
      {
        throw e;
      }
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
    public static int AddGuestTM(Common.DTO.TMDto guest)
    {
      try
      {
        return DAL.TMDal.AddGuestTM(Converters.TMConverter.ToDalGuest(guest));
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
    public static int DeleteGuest(int id)
    {
      try
      {
        return DAL.GuestDal.DeleteGuest(id);
      }
      catch (Exception e)
      {

        throw e;
      }
    }
  }
}
