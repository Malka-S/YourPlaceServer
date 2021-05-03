using System;
using Common.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Converters
{
 public  class TMConverter
  {
    public static guest_table_member ToDalGuest(TMDto g)
    {
      guest_table_member gu = new guest_table_member();
      gu.table_members_id = TMDal.GetHID() + 1; 
      gu.guest_id = g.guest_id;
      gu.friend_id = g.friend_id;
      gu.like_or_not = g.like_or_not;
      gu.guestPriority = g.guestPriority;
      return gu;
    }

  }
}
