using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Graph
    {
        //#region Graph

        //#region Get/Set
        //public static int codeGroup;    //every graph is for a different group
        //private NodePrime source;   //node that includes all the nodes of childen
        //private NodePrime target;   //node that includes all the nodes of cars
        //private List<Node> listNode;    //list of all nodes in graph
        //private List<Arc> path; //path of arcs
        //public NodePrime getSource()
        //{
        //    return source;
        //}
        //public void setSource(NodePrime source)
        //{
        //    this.source = source;
        //}
        //public NodePrime getTarget()
        //{
        //    return target;
        //}
        //public void setTarget(NodePrime target)
        //{
        //    this.target = target;
        //}
        //public List<Node> getListNode()
        //{
        //    return listNode;
        //}
        //public void setListNode(List<Node> listNode)
        //{
        //    this.listNode = listNode;
        //}
        //public void setPath(List<Arc> path)
        //{
        //    this.path = path;
        //}
        //public List<Arc> getPath()
        //{
        //    return path;
        //}

        //#endregion

        //#region Defination

        //public static List<COMMON.Children> listChildrenPerGroup;
        //public static List<NodeTable> lisr;
        //public static List<Node> listNodes;
        //public static List<NodeGuest> liNodeChild = new List<NodeGuest>();
        //public static List<NodeTable> liNodeCar = new List<NodeTable>();
        //public static List<COMMON.Days> liD;
        //public static List<COMMON.Capabilities> listCapa;
        //public static List<Arc> listarc;
        //public static int flagPref; //this is for level of preferences

        //#endregion

        //#region static functions

        ////function gets list of children from db and creates a node for every child
        ////returns list of Child nodes 
        //public static List<NodeGuest> listNodeChild()
        //{
        //    List<NodeGuest> list = new List<NodeGuest>();   //list of nodes child type 
        //    List<COMMON.HoursTakingKids> listh = HoursTakingKids.GetHoursTakingKids();
        //    foreach (var item in listChildrenPerGroup)
        //    {
        //        //need to go over list of hourTaking child creates 2 nodes:
        //        //every child needs to be taken to school and picked up
        //        foreach (var i in liD)
        //        {
        //            //Taking
        //            COMMON.HoursTakingKids h = listh.First(a => a.codeHourTakingKids == item.codeHourTaking);
        //            NodeGuest nodeChild1 = new NodeGuest(item.codeChild, i, h);// /a child node type has hour taking property
        //            nodeChild1.setListArc(CreateArc(nodeChild1));//each node has a list of arcs comming out of node- all capabilities that match(see func 'CreateArc')
        //            list.Add(nodeChild1);

        //            //PickingUp
        //            h = listh.First(a => a.codeHourTakingKids == item.codeHourPickingUp);
        //            NodeGuest nodeChild2 = new NodeGuest(item.codeChild, i, h);
        //            nodeChild2.setListArc(CreateArc(nodeChild2));
        //            list.Add(nodeChild2);
        //        }
        //    }
        //    return list;
        //}

        ////function gets list of children from db and creates a node for every child
        ////returns list of Car nodes 
        ////הפונקציה יוצרת ומחזירה רשימת קדקודי הרכבים
        //public static List<NodeTable> listNodeCar()
        //{
        //    lisr = new List<NodeTable>();
        //    List<COMMON.Families> listfa = Families.GetFamiliesPerGroup(codeGroup);
        //    List<Arc> listArc = new List<Arc>();
        //    List<COMMON.Capabilities> listCapabilities = BLL.Capabilities.GetCapabilitiesbyGroup(codeGroup);
        //    NodeTable nodeCar;
        //    foreach (var item in listCapabilities)
        //    {
        //        //need numSeets from family 
        //        COMMON.Families f = listfa.First(a => a.codeFamily == item.codeFamily);
        //        //car node will be multiplied by numSeetsAvail
        //        for (int i = 1; i <= f.numSeetsAvail; i++)
        //        {
        //            nodeCar = new NodeTable(item.codeCapability * 100 + i, listArc);// /100 - %100  =unique id of node car since multiplied by numSeets
        //            lisr.Add(nodeCar);
        //        }
        //    }
        //    return lisr;
        //}

        ////returns true if car matches childs needs
        ////checks also preferenses
        ////יחזיר אמת אם הרכב עונה על דרישות הילד 
        //public static bool MiniCreateArc(NodeGuest nodeChild, NodeTable nodeCar)
        //{
        //    List<COMMON.HoursTakingKids> listh = HoursTakingKids.GetHoursTakingKids();
        //    int id = nodeCar.getId() / 100;     //original code of car

        //    COMMON.Days dayChild = nodeChild.getDay();
        //    //goes over listCapa and not listCapa of specific group- run time shorter
        //    COMMON.Days dayCapa = liD.First(a => a.codeDay == (listCapa.First(b => b.codeCapability == id)).codeDay);

        //    COMMON.HoursTakingKids hourChild = nodeChild.gethour();
        //    COMMON.HoursTakingKids hourCapa = listh.First(b => b.codeHourTakingKids == listCapa.First(a => a.codeCapability == id).codeHourTakingKids);
        //    //here we checked match and preferens with flagPref
        //    bool preference = checkPref(nodeChild, nodeCar);
        //    if (dayCapa == dayChild && preference == true)
        //    {
        //        if (hourCapa.codeHourTakingKids == hourChild.codeHourTakingKids)
        //        {
        //            return true;
        //        }
        //    }
        //    return false; //not match at all
        //}

        ////checks preferences if match - return true
        //public static bool checkPref(NodeGuest nodeChild, NodeTable nodeCar)
        //{
        //    int? codeSchoolOfCapa = listCapa.Where(a => a.codeCapability == (nodeCar.getId() / 100)).First().codeSchool;
        //    int codeFamilyOfCapa = listCapa.Where(a => a.codeCapability == (nodeCar.getId() / 100)).First().codeFamily;
        //    int codeSchoolOfChild = listChildrenPerGroup.Where(a => a.codeChild == nodeChild.getId()).First().codeSchool;
        //    int codeFamilyOfChild = listChildrenPerGroup.Where(a => a.codeChild == nodeChild.getId()).First().codeFamily;
        //    switch (flagPref)
        //    {
        //        case 3:
        //            if (codeSchoolOfCapa == codeSchoolOfChild && codeFamilyOfCapa == codeFamilyOfChild)
        //            {
        //                return true;    //pref3 = going to same school every hour & taking my own children
        //            }
        //            break;
        //        case 2:
        //            if (codeSchoolOfCapa == codeSchoolOfChild)
        //            {
        //                return true;    //pref2 = going to same school every hour
        //            }
        //            break;
        //        case 1:
        //            if (codeFamilyOfCapa == codeFamilyOfChild)
        //            {
        //                return true;    //pref1 = taking my own children
        //            }
        //            break;
        //        case 0: return true;
        //        default:
        //            return false;
        //    }
        //    return false;
        //}


        ////עובר על כל הרכבים ומשווה אילוצי כל ילד עם הרכב עונה על התנאי 
        ////כל רכב שעונה על כל האילוצים יתווסף לרשימת הקשתות
        ////creates an arc- an option for replacement
        //public static List<Arc> CreateArc(NodeGuest nodeChild)
        //{
        //    listarc = new List<Arc>();
        //    foreach (NodeTable item in lisr)  // List<NodeCar> type of lisr
        //    {
        //        bool q;
        //        q = MiniCreateArc(nodeChild, item);//returns true if car responds to requirements of child 
        //        if (q == true)
        //        {
        //            Arc newArc = new Arc(nodeChild, item);
        //            listarc.Add(newArc);
        //        }
        //    }
        //    return listarc;
        //}

        ////אתחול רשימות שמוגדרות לעיל
        //public static void initLists(int cGroup)
        //{
        //    codeGroup = cGroup;//init the global code group
        //    listChildrenPerGroup = BLL.Children.GetChildrenPerGroup(codeGroup);
        //    liD = BLL.Days.GetDays();
        //    listCapa = Capabilities.GetCapabilities();
        //}
        //#endregion

        //#region graph ctor
        //public Graph(int codeGroup)// אתחול הגרף בקודקודים ובקשתות  
        //{
        //    listNodes = new List<Node>();
        //    liNodeCar = listNodeCar();  //הפונקציה יוצרת ומחזירה רשימת קדקודי הרכבים
        //    liNodeChild = listNodeChild();  //הפונקציה יוצרת ומחזירה רשימת קדקודי הילדים

        //    NodePrime source = new NodePrime(); //יצירת קודקוד מקור
        //    source.setId(-1);
        //    NodePrime target = new NodePrime(); //יצירת קודקוד יעד
        //    target.setId(1);

        //    Arc arc;
        //    List<Arc> listArcSource = new List<Arc>();//יצירת רשימת קשתות ריקה למקור
        //    List<Arc> listArcTarget = new List<Arc>();//יצירת רשימת קשתות ריקה ליעד

        //    foreach (var item in liNodeChild)   //עבור על רשימת הקודקודים מסוג ילד
        //    {
        //        arc = new Arc(source, item);
        //        listArcSource.Add(arc);
        //    }
        //    source.setListArc(listArcSource);   //לכל הילדים source יוצר חיצים מהמקור 
        //    foreach (var item in liNodeCar)     // target יוצר חיצים מהרכבים ליעד 
        //    {
        //        arc = new Arc(item, target);
        //        List<Arc> la = new List<Arc>();
        //        la.Add(arc);
        //        item.setListArc(la);
        //    }
        //    // listNodes כל קדקודי הגרף מוכנסים ל
        //    listNodes.Add(source);
        //    foreach (var item in liNodeChild)
        //    {
        //        listNodes.Add(item);
        //    }
        //    foreach (var item in liNodeCar)
        //    {
        //        listNodes.Add(item);
        //    }
        //    listNodes.Add(target);
        //    //הוספה לרשימת הצמתים צומת מקור וצומת יעד עם הקשתות שלהם ואז הרשימה מכילה גרף שלם
        //    this.source = source;
        //    this.target = target;
        //    listNode = listNodes;
        //    path = null;
        //}
        //#endregion

        ////פונקציה שעוברת על כל הקדקודים והקשתות בגרף ומוצאת מסלול אפשרי 
        ////goes over all nodes and arcs in graph and finds a possible path
        //public static List<Arc> BFS(Graph graph, NodePrime source, NodePrime target)
        //{
        //    List<Arc> list = new List<Arc>();
        //    Queue<Node> queue = new Queue<Node>();
        //    //אתחול
        //    foreach (var node in graph.listNode)
        //    {
        //        if (node.getId() != source.getId())
        //        {
        //            node.setColor("white");
        //            node.setD(10000);   //infinity difference from source
        //        }
        //        else
        //        {
        //            // init starting node
        //            node.setD(0);
        //        }
        //        node.setP(null); //path from source till current node
        //    }
        //    queue.Enqueue(source);
        //    source.setColor("gray");
        //    Node u = new Node();//current
        //    while (queue.Count != 0)//queue not empty
        //    {
        //        u = queue.Peek();
        //        if (u.getListArc() != null)//list of arcs of node in head of queue not empty  
        //        {
        //            foreach (Arc arcOfU in u.getListArc())//all its' arcs
        //            {
        //                if ((graph.getListNode().Where(a => a == arcOfU.getT()).ToList().First().getColor() == "white"))//target of arc is white- didnt go over yet
        //                {
        //                    graph.getListNode().Where(a => a == arcOfU.getT()).ToList().First().setColor("gray");//gray= went over it
        //                    graph.getListNode().Where(a => a == arcOfU.getT()).ToList().First().setD(1);
        //                    graph.getListNode().Where(a => a == arcOfU.getT()).ToList().First().setP(u);//parent
        //                    queue.Enqueue(graph.getListNode().Where(a => a == arcOfU.getT()).ToList().First());
        //                }
        //            }
        //        }
        //        queue.Dequeue();
        //        u.setColor("black");
        //    }
        //    if (target.getD() == 10000)//graph not in order
        //    {
        //        return null;
        //    }
        //    Arc arc;//an arc to add to path
        //    Node nodeTarget = target;
        //    Node nodeParent;
        //    for (int i = 0; i < nodeTarget.getD();)//goes over nodes from target to source
        //    {
        //        nodeParent = nodeTarget.getP();
        //        arc = nodeParent.getListArc().Where(q => q.getT().getId() == nodeTarget.getId()).First();
        //        list.Add(arc);
        //        nodeParent = nodeParent.getP();
        //        nodeTarget = nodeTarget.getP();//gets parent of current node
        //    }
        //    return list;//possible path
        //}

        ////the main algorithm of the project implements Ford Fulkerson
        ////algorithm gets graph, source node and target node and replaces children in optimal way
        //public static Graph FordFulkerson(Graph graph, NodePrime source, NodePrime target)
        //{
        //    List<Arc> pathP;
        //    pathP = BFS(graph, source, target); //finds possible path
        //    while (pathP != null)   //if path found
        //    {
        //        reversePath(pathP);     //try to replace
        //        pathP = BFS(graph, source, target); //continue finding possible paths
        //    }
        //    return graph;
        //}

        ////gets a path and reverses all its arcs and deletes the original path
        //public static void reversePath(List<Arc> path)
        //{
        //    Arc a;
        //    bool flag_foundS = false, flag_foundT = false;
        //    foreach (var item in path)
        //    {
        //        List<Arc> l = new List<Arc>();
        //        foreach (var node in listNodes)
        //        {
        //            if (node.getListArc() != null)
        //                l = node.getListArc();
        //            //adds a reversed path
        //            if (node.getId() == item.getT().getId())  //find target
        //            {
        //                a = new Arc(node, item.getS()); //reversed arc
        //                l.Add(a);
        //                node.setListArc(l);
        //                flag_foundT = true;
        //            }
        //            //deletes path that was reversed
        //            if (node.getId() == item.getS().getId())    //find source
        //            {
        //                Node nodetoremove = listNodes.First(b => b.getId() == node.getId());
        //                nodetoremove.deleteArc(item);
        //                flag_foundS = true;
        //            }
        //            if (flag_foundS && flag_foundT)
        //            {
        //                flag_foundT = false;    //initialize for next time...
        //                flag_foundS = false;
        //                break;
        //            }
        //        }
        //    }
        //}

        ////finds all children replaced and returns them
        //public static List<NodeGuest> fixedGraph(Graph graph, NodePrime source, NodePrime target)
        //{
        //    int flag = 0;
        //    Graph gr = FordFulkerson(graph, source, target);//FordFulkerson returns optimal graph for replacement
        //    List<NodeGuest> listFilledChldrn = new List<NodeGuest>();
        //    List<Arc> a;    //list of arcs
        //    foreach (var item in listNodes)//goes over all nodes in graph
        //    {
        //        if (item is NodeGuest)  //goes over all children(list of cildren changed-can't use it)
        //        {
        //            foreach (Node node in listNodes)
        //            {
        //                if (node is NodeTable)
        //                {
        //                    if (node.getColor() != "green")//green=capability caught
        //                    {
        //                        foreach (Arc arc in node.getListArc())
        //                        {
        //                            a = new List<Arc>();//init list of arcs
        //                            if (arc.getT().getId() == item.getId())//is car pointing at me?
        //                            {
        //                                Arc newArc = new Arc(item, node);
        //                                a.Add(newArc);
        //                                item.setListArc(a);
        //                                flag = 1;
        //                                node.setColor("green");//catches capability of car
        //                                listFilledChldrn.Add((NodeGuest)item);//add to list of children this child
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //                if (flag == 1)//if child replaces- go to next child
        //                {
        //                    flag = 0;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return listFilledChldrn;//returns the list of children replaced
        //}

        //public static List<NodeGuest> mainFunction(int codeGroup)//main function that replaces a group
        //{
        //    COMMON.Children c;
        //    COMMON.Replacement r;
        //    List<NodeGuest> liChldrnNotReplaced = new List<NodeGuest>();
        //    List<NodeGuest> listChldrnReplaced = new List<NodeGuest>();//   list of nodes that will be for children replaced
        //    initLists(codeGroup);   //init lists defined above
        //    flagPref = 3;//init preference flag to highest level
        //    //replacment, in MiniCreateArc we checked flagPref
        //    while (flagPref >= 0)// didnt finish checking preferences and there are still children not replaced
        //    {
        //        liChldrnNotReplaced = new List<NodeGuest>();
        //        Graph g = new Graph(codeGroup); //each group has own graph
        //        listChldrnReplaced = fixedGraph(g, g.getSource(), g.getTarget());  //fill list from func that reurns kids replaced after replacement happens
        //        if (listChldrnReplaced.Count() > 0)
        //        {
        //            if (liNodeChild.Count() == listChldrnReplaced.Count())//all requirements were fulfilled
        //            {
        //                foreach (var item in listChldrnReplaced) //for every child replaced:
        //                {
        //                    int codeCapa = item.getListArc().First().getT().getId() / 100;//code capability that child was replaced with
        //                    try
        //                    {
        //                        r = new COMMON.Replacement(codeCapa);//code capa
        //                        c = Children.GetChildren().First(a => a.codeChild == item.getId()); //gets child from current node                                                                                                 
        //                        r.codeChild = c.codeChild;
        //                        Replacement.AddReplacement(r);
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        Console.WriteLine(e);
        //                        throw;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                foreach (var item in liNodeChild) 
        //                {
        //                    if (!(listChldrnReplaced.Contains(item)))
        //                        liChldrnNotReplaced.Add(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            liChldrnNotReplaced = liNodeChild;
        //        }
        //        if (liChldrnNotReplaced.Count > 0)
        //        {//not all were replaced yet
        //            flagPref--;//lower level of preferences and try again to replace by running algorithm again
        //        }
        //        else { break; }//finished replacing
        //    }
        //    return liChldrnNotReplaced; //returns the children not replaced!!! if 0- all replaced...
        //}

        //#endregion
    }
}
