using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DTO;

namespace BLL
{
    public class EventService
    {
       public static List<Common.DTO.EventDto> GetAllEvents()
        {
            return Converters.EventConverter.ToDtoEventList(DAL.EventDal.SelectEvents());
            
        }
    public static List<Common.DTO.BaseCodeDto> GetEventType()
    {
      return Converters.EventConverter.ToDtoEventTypeList(DAL.EventDal.SelectEventType());
    }
    //public static List<Common.DTO.BaseCodeDto> GetEventType()
    //{
    //  return Converters.EventConverter.ToDtoEventTypeList();
    //}
    public static Common.DTO.EventDto SelectEvents(int code)
    {
      return Converters.EventConverter.ToDtoEvent(DAL.EventDal.SalectEvent(code));
    }

    public static int DeleteEventByCode(int code)
    {
      try
      {
        return DAL.EventDal.DeleteEvent(code);
      }
      catch
      {
        throw;
      }
    }

    public static int updateCategoryiesList(List<BaseCodeDto> CategoryiesList)
    {
      try
      {
        return DAL.EventDal.UpdateCategoryiesList(Converters.EventConverter.ToDalCategoryiesList(CategoryiesList));
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    public static int UpdateEvent(EventDto event1)
    {
      try
      {
        return DAL.EventDal.UpdateEvent(Converters.EventConverter.ToDalEvent(event1));
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    //public static int UpdateEvent(Common.DTO.EventDto event1)
    //{
    //  try
    //  {
    //    return DAL.EventDal.UpdateEvent(Converters.EventConverter.ToDalEvent(event1));
    //  }
    //  catch (Exception e)
    //  {

    //    throw e;
    //  }
    //}

    //public static int AddEvent(Common.DTO.EventDto event)
    //{
    //    try
    //    {
    //        return DAL.EventDal.AddEvent(Converters.EventConverter.ToDalEvent(event));
    //    }
    //    catch (Exception e)
    //    {

    //        throw;
    //    }
    //}
  }

}
