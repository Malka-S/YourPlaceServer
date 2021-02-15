using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BLL
{
   public class Arc
    {

        private Node s;
        private Node t;
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
