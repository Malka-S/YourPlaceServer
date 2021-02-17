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
    //רשימה שתכיל בסוף את כל האורחים והכמות שהם מרוצים
    public static List<Node> LTM = new List<Node>(EventDal.GetNumOfSeatsAroundTable());
    //רשימה של אורחים בקטגוריה המסוימת
    public static List<Guest> LTMByCategory = new List<Guest>(GuestDal.SelectNumOfGuestsByCatagory(category));
    //למה צריך להגדיר את המשתנה במחלקה הזאת?
    public static int satisfy { get; private set; }

    //עובר על ליסט של קטגוריה מסוימת
    //עשיתי סטטי בשביל הקריאה מהAPI
    public static List<Node> CreateArrPerCategory()
    {
      //add the guest id to first row by category
      //adding on to each guest there first option
      //checking the capacity of other tm to see if more/less
      //addin 3 to guest and adding/taking off other tm
      //moving on to next friend
     // BLL.Node TM = new Node();
      int id = TMDal.GetGuest1priority(LTMByCategory[0].guest_id);
      //הראשון זה הID שח הנוכחי והשני זה החבר
      int priority = TMDal.GetPriorityByFriend(LTMByCategory[0].guest_id, id);
      //LTM[i].guest_id = id;
      //LTM[i].satisfy += priority;
      LTM.Add(new Node() { guest_id = LTMByCategory[0].guest_id, satisfy = satisfy + priority });
      //h=כמה האורח החדש רוצה את מי שביקש אותו
      int h = TMDal.GetPriorityByFriendToAdd(id, LTMByCategory[0].guest_id);  
      LTM.Add(new Node() { guest_id = id, satisfy = h });
      int c = LTMByCategory.Count;
      //int i = 1;
      while (c > 0)
      {

        int id2 = TMDal.GetGuest1priority(id);
        //הראשון זה הID שח הנוכחי והשני זה החבר
        priority = TMDal.GetPriorityByFriend(id, id2);
        //LTM[i].guest_id = id;
        //LTM[i].satisfy += priority;
        //חיפוש למציאת מיקום של החבר המסוים
        LTM[GetGuestById(id2)].satisfy += priority;
        //לעבור על האורחים שכבר בשולחן לראות אם החדש מעלה או מוריד להם
        for (int j = 0; LTM[j].guest_id!=0; j++)
        {
          //לראות כמה מעלה או וריד האורח הספציפי ברשימה עם החדש שאנו מוסיפים
          int old_id = LTM[j].guest_id;
          int n_satisfy = TMDal.GetPriorityByFriendToAdd(old_id, id2);
              //לעלות או להוריד ממי שכבר שם
          LTM[j].satisfy += n_satisfy;

        }
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
    public static int GetGuestById(int id)
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
