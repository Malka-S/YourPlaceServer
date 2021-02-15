using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class Arc
  {
    //private int zrima;
    //private int kibul;
    private Node s;
    private Node t;
    //public int getZrima()
    //{
    //    return zrima;
    //}
    //public void setZrima(int zrima)
    //{
    //    this.zrima = zrima;
    //}
    //public Arc(int Zrima)
    //{
    //    setZrima(zrima);
    //}
    //public Arc(int Zrima, int kibul, int s, int t)
    //{
    //    setZrima(Zrima);
    //    setKibul(kibul);
    //    setS(s);
    //    setT(t);
    //}
    public Arc(Node s, Node t)
    {
      setS(s);
      setT(t);
      //setZrima(0);
    }
    public Arc()
    {
      //setZrima(0);
    }
    //public void setKibul(int kibul)
    //{
    //    this.kibul = kibul;
    //}
    //public int getKibul()
    //{
    //    return kibul;
    //}


    public Node getS()
    {
      return s;
    }
    public void setS(Node s)
    {
      this.s = s;
    }

    public Node getT()
    {
      return t;
    }
    public void setT(Node t)
    {
      this.t = t;
    }
  }
}
