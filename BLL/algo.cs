using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class Node
  {
    public int guest_id;
    public int satisfy = 0;
  }
  public class LTM
  {
    private int c = 0;
    //רוד שולחן
    public int TableID;
    public List<Node> members = new List<Node>(EventDal.GetNumOfSeatsAroundTable());
    public LTM()
    {
      TableID = c++;
    }
  }
  public class algo
  {//המשתנה הזה אמור לקבל מהשרת לפי הארוע המסוים
    public static int seatsArountTable = 8;
    public static int category = 1;
    //רשימה של כל השולחנות
    public static List<LTM> TabelList = new List<LTM>();
    //רשימה של אורחים בקטגוריה המסוימת
    public static List<Guest> LTMByCategory = new List<Guest>(GuestDal.SelectNumOfGuestsByCatagory(category));
    //למה צריך להגדיר את המשתנה במחלקה הזאת?
    public static int satisfy { get; private set; }
    public static LTM currentTable = new LTM();

    //עובר על ליסט של קטגוריה מסוימת
    //עשיתי סטטי בשביל הקריאה מהAPI
    public static LTM CreateArrPerCategory()
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
      currentTable.members.Add(new Node() { guest_id = LTMByCategory[0].guest_id, satisfy = satisfy + priority });
      //h=כמה האורח החדש רוצה את מי שביקש אותו
      int h = TMDal.GetPriorityByFriendToAdd(id, LTMByCategory[0].guest_id);
      if (TMDal.GetstatusOfFById(LTMByCategory[0].guest_id, id) == true)
        currentTable.members.Add(new Node() { guest_id = id, satisfy = h });
      int c = LTMByCategory.Count;
      //int i = 1;
      while (c > 0)
      {

        int id2 = TMDal.GetGuest1priority(id);
        //הראשון זה הID שח הנוכחי והשני זה החבר
        priority = TMDal.GetPriorityByFriend(id, id2);
        //LTM[i].guest_id = id;
        //LTM[i].satisfy += priority;
        ////חיפוש למציאת מיקום של החבר המסוים
        //LTM[GetGuestById(id2)].satisfy += priority;
        ////לעבור על האורחים שכבר בשולחן לראות אם החדש מעלה או מוריד להם
        ////לפני שמוסיפים עוד אורח לשולחן צריך לבדוק כמה מעלה או מוריד מכל החברים האחרים בשולחן
        currentTable.members.Add(new Node() { guest_id = id2, satisfy = 0 });
        currentTable.members[GetGuestById(id)].satisfy += priority;
        changeTMP(id);
        ChangePToNTM(id2);

        //אני רוצה להוסיף את הID של האורח הספציפי
        //TM.guest_id;
        id = id2;
        c--;
      }
      return currentTable;
    }
    /// <summary>
    /// הפונקציה משנה את הפריוריטי לכל החברים ע"י הוספת החבר החדש
    /// </summary>
    public static void changeTMP(int id)
    {
      //לראות כמה מעלה או וריד האורח הספציפי ברשימה עם החדש שאנו מוסיפים
      //לעלות או להוריד ממי שכבר שם
      for (int j = 0; currentTable.members[j].guest_id != id; j++)
        currentTable.members[j].satisfy += TMDal.GetPriorityByFriendToAdd(currentTable.members[j].guest_id, id);
    }
    /// <summary>
    /// הפונקציה משנה את הפרירוטי לחבר החדש בהתאמה לחברים הקיימים כבר בשולחן 
    /// </summary>
    public static void ChangePToNTM(int id)
    {
      for (int j = 0; currentTable.members[j].guest_id != id; j++)
        currentTable.members[GetGuestById(id)].satisfy += TMDal.GetPriorityByFriendToAdd(id, currentTable.members[j].guest_id);
    }
    //פונקציה למציאת מיקום במערך של השולחן
    public static int GetGuestById(int id)
    {
      int i = 0;
      while (currentTable.members[0].guest_id != id)
      {
        i++;
        if (currentTable.members[i].guest_id == id)
          return i;
      }
      return -1;
    }

    /// <summary>
    ///הפונקציה מקבלת שולחן ואורח ומוחקת את האורח מהשולחן
    /// </summary>
    public static void DeleteGuestFromTable(int tableId, int guestId)
    {
      for (int i = 0; TabelList[tableId].members != null; i++)
      {
        if (TabelList[tableId].members[i].guest_id == guestId)
          TabelList[tableId].members[i] = null;
      }
    }
    //פונקציה היוצרת שולחן חדש ומחזירה אותו
    public static int OpenNewTable()
    {
      LTM newTableAdd = new LTM();
      TabelList.Add(newTableAdd);
      return newTableAdd.TableID;
    }


    public static int RandomRetrieval()
    {
      Random _random = new Random();
      int c = _random.Next(LTMByCategory.Count);
      while (IsPlaced(LTMByCategory[c].guest_id))
      {
        c = _random.Next(LTMByCategory.Count);
      }
      return LTMByCategory[c].guest_id;
    }
    //פונקציה המקבלת קוד אורח ובודקת אם האורח משובץ כבר
    public static bool IsPlaced(int guestId)
    {
      for (int i = 0; i < TabelList.Count; i++)
        foreach (var item in TabelList[i].members)
          if (item.guest_id == guestId)
            return true;
      return false;
    }
    /// <summary>
    /// הפונקציה בודקת אם הבקשה המסוימת סותרת את הבקשה הראשונה של אחד מיושבי השולחן הנמצאים
    /// </summary>
    /// <param name="tableId"></param>
    /// <param name="guestId"></param>
    /// <param name="disOrNot"></param>
    /// <returns></returns>
    public static bool ContradictionBetweenRequests(int tableId, int guestId, int frient_id, bool disOrNot)
    {
      return false;
    }
    /// <summary>
    /// במקרה ובקשה ראשונה לא יכולה להתקיים אנסה למלאות את שתי הבקשות האחרות
    /// </summary>
    /// <param name="tableId"></param>
    /// <param name="guestId"></param>
    /// <returns></returns>
    public static int Place23(int tableId, int guestId)
    {
      //בודק אם אפשר למלא את 2 הבקשות שלו בשולחן זה
      //ואם לא-בוקדק אולי בשולחן אחר

      return 1;
    }
    public static int GetTableFromTList(int tableId)
    {
      for (int i = 0; TabelList[i] != null; i++)

        if (TabelList[i].TableID == tableId)
          return i;
      return -1;
    }
    /// <summary>
    ///הפונקציה מקבלת אורך שולחן ושולחן מסוים ובודקת אם נשארו בו מקומות פנוים
    /// </summary>
    public static bool isTableFull(int tableId, int seatsArountTable)
    {
      int i = 0;
      while (i < seatsArountTable && TabelList[tableId].members != null)
      {
        i++;
      }
      if (TabelList[tableId].members == null)
        return false;
      return true;
    }
    //האם האורח הספציפי קיים בשולחן הספציפי
    public static bool ExesitInTable(int tableId, int guestId)
    {
      foreach (var item in TabelList[tableId].members)
      {
        if (item.guest_id == guestId)
          return true;
      }
      return false;
    }
    public static int Main(int tableId, int guestId)
    {
      if (!IsPlaced(guestId) && isTableFull(tableId, seatsArountTable))
      {
        int idFriend = TMDal.GetGuest3priority(guestId);
        int priority = TMDal.GetPriorityByFriend(guestId, idFriend);

        if (TMDal.GetstatusOfFById(guestId, idFriend) && !IsPlaced(idFriend))
        {
          if (ContradictionBetweenRequests(tableId, guestId, idFriend, TMDal.GetstatusOfFById(guestId, idFriend)))
          {
            //ChangeInTable(tableId, idFriend);
            TabelList[tableId].members.Add(new Node() { guest_id = guestId, satisfy = priority });
            return Main(tableId, idFriend);
          }
          else
          {
            Place23(tableId, guestId);
          }
        }
        //בקשה סותרת או כבר משובץ
        else
        {
          if (!ExesitInTable(tableId, idFriend))
          {
            int newTableId = OpenNewTable();
            Place23(tableId, guestId);
            return Main(newTableId, guestId);
          }
          else
          {
            DeleteGuestFromTable(tableId, idFriend);
            return Main(tableId, RandomRetrieval());
          }
        }

      }
      else
        return Main(tableId, RandomRetrieval());
      return Main(tableId, RandomRetrieval());

    }

  }
}
