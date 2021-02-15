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
    public List<Node> lisr =  new List<Node>(EventDal.GetNumOfSetaAroundTable()) ;
    

    //עובר על כל הרכבים ומשווה אילוצי כל ילד עם הרכב עונה על התנאי 
    //כל רכב שעונה על כל האילוצים יתווסף לרשימת הקשתות
    //creates an arc- an option for replacement
    //public static List<Arc> CreateArc(NodeGuest nodeChild)
    //{
    //  var listarc = new List<Arc>();
    //  foreach (NodeTable item in lisr)  // List<NodeCar> type of lisr
    //  {
    //    bool q;
    //    q = MiniCreateArc(nodeChild, item);//returns true if car responds to requirements of child 
    //    if (q == true)
    //    {
    //      Arc newArc = new Arc(nodeChild, item);
    //      listarc.Add(newArc);
    //    }
    //  }
    //  return listarc;
    //}
    public List<Node> CreateArrPerCategory(int id_category)
    {
      //add the guest id to first row by category
      //adding on to each gust there first option 
      //adding to capasity 3 and check to all otherguests in table
      //

      return lisr; 
    }
  }
}
