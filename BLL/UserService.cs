using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class UserService
  {

    public static List<Common.DTO.UserDto> GetAllUsers()
    {
      return Converters.UserConverter.ToDtoUserList(DAL.UserDal.SelectUsers());
    }

    public static string GetUserByEmail(string mail)
    {
      try
      {
        return DAL.UserDal.SalectUser(mail);

      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static int AddUser(Common.DTO.UserDto user)
    {
      try
      {
        return DAL.UserDal.AddUser(Converters.UserConverter.ToDalUser(user));
      }
      catch (Exception e)
      {

        throw e;
      }
    }
  }
}
