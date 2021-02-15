using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NodeTable : Node
    {
        //id of car represents: id of driver + 0 + i(individual for each node)
        public NodeTable(int id, List<Arc> listArc) : base(id, listArc)
        {

        }
    }
}
