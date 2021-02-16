using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class algo
  {
    public static int category = 1;
    public List<Node> LTM = new List<Node>(EventDal.GetNumOfSeatsAroundTable());
    //public int amoutOfCategory = GuestDal.SelectNumOfGuestsByCatagory(category);
    //אני לא מצליחה להגדיר רשימה באורך של כמות האורחים בקטגוריה זו לא יודעת למה אא
    public List<Guest> LTMByCategory = new List<Guest>(GuestDal.SelectNumOfGuestsByCatagory(category));

    public int satisfy { get; private set; }


    //עובר על ליסט של קטגוריה מסוימת
    public List<Node> CreateArrPerCategory()
    {
      //add the guest id to first row by category
      //adding on to each guest there first option
      //checking the capacity of other tm to see if more/less
      //addin 3 to guest and adding/taking off other tm
      //moving on to next friend
      BLL.Node TM = new Node();
      int id = GuestDal.GetGuest1priority(LTMByCategory[0].guest_id);
      //הראשון זה הID שח הנוכחי והשני זה החבר
      int priority = GuestDal.GetPriorityByFriend(LTMByCategory[0].guest_id, id);
      //LTM[i].guest_id = id;
      //LTM[i].satisfy += priority;
      LTM.Add(new Node() { guest_id = LTMByCategory[0].guest_id, satisfy = satisfy + priority });
      var h = (GuestDal.GetPriorityByFriend(id, LTMByCategory[0].guest_id));
      LTM.Add(new Node() { guest_id = id, satisfy = h });
      int c = LTMByCategory.Count;
      int i = 1;
      while (c > 0)
      {

        int id2 = GuestDal.GetGuest1priority(id);
        //הראשון זה הID שח הנוכחי והשני זה החבר
        priority = GuestDal.GetPriorityByFriend(id, id2);
        //LTM[i].guest_id = id;
        //LTM[i].satisfy += priority;
        //חיפוש למציאת מיקום של החבר המסוים
        LTM[GetGuestById(id2)].satisfy+=priority;
        //לפני שמוסיפים עוד אורח לשולחן צריך לבדוק כמה מעלה או מוריד מכל החברים האחרים בשולחן
        LTM.Add(new Node() { guest_id = id2, satisfy = 0 });

        //אני רוצה להוסיף את הID של האורח הספציפי
        //TM.guest_id;
        id = id2;
        c--;
      }
      return LTM;
    }
    //פונקציה למציאת מיקום במערך של השולחן
    public int GetGuestById(int id)
    {
      int i = 0;
      while (LTM[0].guest_id != id)
      {
        i++;
        if (LTM[i].guest_id == id)
          return i;
      }
      return -1;
    }
  }
}
