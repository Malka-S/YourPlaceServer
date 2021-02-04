using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
  public class UserConverter
  {
    public static DAL.Users ToDalUser(Common.DTO.UserDto e)
    {
      DAL.Users ev = new DAL.Users();
      ev.user_email = e.user_email;
      ev.user_password = e.user_password;
      return ev;
    }
    public static Common.DTO.UserDto ToDtoUser(DAL.Users e)
    {
      Common.DTO.UserDto ev = new Common.DTO.UserDto();
      ev.user_email = e.user_email;
      ev.user_password = e.user_password;
      return ev;
    }
    public static List<DAL.Users> ToDalUserList(List<Common.DTO.UserDto> l)
    {
      List<DAL.Users> U = new List<DAL.Users>();
      foreach (var item in l)
      {
        U.Add(ToDalUser(item));

      }
      return U;
    }
    //לא מבינה למה לא טוב
    //public static List<Common.DTO.UserDto> ToDtoUserList()
    //{
    //  List<Common.DTO.UserDto> le = new List<Common.DTO.UserDto>();
    //  le.Add(ToDtoUser("name1", "password1"));
    //  le.Add(ToDtoUser("name2", "password2"));
    //  le.Add(ToDtoUser("name3", "password3"));
    //  le.Add(ToDtoUser("name4", "password4"));
    //  le.Add(ToDtoUser("name5", "password5"));
    //  return le;
    //}
    public static List<Common.DTO.UserDto> ToDtoUserList(List<DAL.Users> l)
    {
      List<Common.DTO.UserDto> U = new List<Common.DTO.UserDto>();
      foreach (var item in l)
      {
        U.Add(ToDtoUser(item));

      }
      return U;
    }
  }
}
