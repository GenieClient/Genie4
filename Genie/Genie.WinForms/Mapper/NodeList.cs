using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Mapper
{
    public enum Direction
    {
        None,
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest,
        Up,
        Down,
        Out,
        Go,
        Climb
    }

    public class Point3D
    {
        private int m_iX = 0;

        public int X
        {
            get
            {
                return m_iX;
            }

            set
            {
                m_iX = value;
            }
        }

        private int m_iY = 0;

        public int Y
        {
            get
            {
                return m_iY;
            }

            set
            {
                m_iY = value;
            }
        }

        private int m_iZ = 0;

        public int Z
        {
            get
            {
                return m_iZ;
            }

            set
            {
                m_iZ = value;
            }
        }

        public Point3D()
        {
        }

        public Point3D(Point3D p)
        {
            m_iX = p.X;
            m_iY = p.Y;
            m_iZ = p.Z;
        }

        public Point3D(int X, int Y, int Z = 0)
        {
            m_iX = X;
            m_iY = Y;
            m_iZ = Z;
        }

        public void Offset(int X, int Y, int Z = 0)
        {
            m_iX += X;
            m_iY += Y;
            m_iZ += Z;
        }

        public void Offset(Point3D Item)
        {
            m_iX += Item.X;
            m_iY += Item.Y;
            m_iZ += Item.Z;
        }

        public void Offset(Direction dir, int distance = 20)
        {
            var oPoint3D = new Point3D();
            switch (dir)
            {
                case Direction.North:
                    {
                        oPoint3D.Offset(0, -distance);
                        break;
                    }

                case Direction.NorthEast:
                    {
                        oPoint3D.Offset(distance, -distance);
                        break;
                    }

                case Direction.East:
                    {
                        oPoint3D.Offset(distance, 0);
                        break;
                    }

                case Direction.SouthEast:
                    {
                        oPoint3D.Offset(distance, distance);
                        break;
                    }

                case Direction.South:
                    {
                        oPoint3D.Offset(0, distance);
                        break;
                    }

                case Direction.SouthWest:
                    {
                        oPoint3D.Offset(-distance, distance);
                        break;
                    }

                case Direction.West:
                    {
                        oPoint3D.Offset(-distance, 0);
                        break;
                    }

                case Direction.NorthWest:
                    {
                        oPoint3D.Offset(-distance, -distance);
                        break;
                    }

                case Direction.Up:
                    {
                        oPoint3D.Offset(0, -distance); // 1
                        break;
                    }

                case Direction.Down:
                    {
                        oPoint3D.Offset(0, distance); // -1
                        break;
                    }

                default:
                    {
                        return;
                    }
            }

            Offset(oPoint3D);
        }

        public override string ToString()
        {
            return m_iX.ToString() + ", " + m_iY.ToString() + ", " + m_iZ.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3D)
            {
                {
                    var withBlock = (Point3D)obj;
                    if (X != withBlock.X)
                        return false;
                    if (Y != withBlock.Y)
                        return false;
                    if (Z != withBlock.Z)
                        return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }

    public class Label
    {
        private string m_sText = string.Empty;

        public string Text
        {
            get
            {
                return m_sText;
            }

            set
            {
                m_sText = value;
                m_Rect.Width = 0; // Reset label size
            }
        }

        private Point3D m_oPosition;

        public Point3D Position
        {
            get
            {
                return m_oPosition;
            }

            set
            {
                m_oPosition = value;
            }
        }

        private RectangleF m_Rect = new RectangleF();

        public RectangleF Rectangle
        {
            get
            {
                return m_Rect;
            }

            set
            {
                m_Rect = value;
            }
        }

        public void ClearRectangle()
        {
            if (Information.IsNothing(m_Rect))
                m_Rect = new RectangleF();
            m_Rect.Width = 0;
        }

        public Label()
        {
        }

        public Label(string Text, Point3D Position)
        {
            m_sText = Text;
            m_oPosition = Position;
        }

        public override bool Equals(object obj)
        {
            if (obj is Label)
            {
                {
                    var withBlock = (Label)obj;
                    if ((withBlock.Text ?? "") == (Text ?? "") & withBlock.Position.X == Position.X & withBlock.Position.Y == Position.Y & withBlock.Position.Z == Position.Z)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }

    public class LabelList : CollectionBase
    {
        public Label this[int Index]
        {
            get
            {
                return (Label)List[Index];
            }

            set
            {
                List[Index] = value;
            }
        }

        public int Add(Label Item)
        {
            return List.Add(Item);
        }

        public int Add(string Text, Point3D Position)
        {
            var oItem = new Label();
            oItem.Text = Text;
            oItem.Position = Position;
            Add(oItem);
            return default;
        }

        public void Remove(Label l)
        {
            int I = 0;
            foreach (Label a in List)
            {
                if ((a.Text ?? "") == (l.Text ?? "") & a.Position.X == l.Position.X & a.Position.Y == l.Position.Y & a.Position.Z == l.Position.Z)
                {
                    List.RemoveAt(I);
                    return;
                }

                I += 1;
            }
        }

        public bool Contains(Label l)
        {
            foreach (Label a in List)
            {
                if ((a.Text ?? "") == (l.Text ?? "") & a.Position.X == l.Position.X & a.Position.Y == l.Position.Y & a.Position.Z == l.Position.Z)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Arc
    {
        private Direction m_eDirection = Direction.None;

        public Direction Direction
        {
            get
            {
                return m_eDirection;
            }

            set
            {
                m_eDirection = value;
            }
        }

        private string m_sMove = string.Empty;

        public string Move
        {
            get
            {
                return m_sMove;
            }

            set
            {
                m_sMove = value;
            }
        }

        private int m_iDestinationID = 0;

        public int DestinationID
        {
            get
            {
                return m_iDestinationID;
            }

            set
            {
                m_iDestinationID = value;
            }
        }

        private Node m_oDestination = null;

        public Node Destination
        {
            get
            {
                return m_oDestination;
            }
        }

        private bool m_bHideArc = false;

        public bool HideArc
        {
            get
            {
                return m_bHideArc;
            }

            set
            {
                m_bHideArc = value;
            }
        }

        public void SetDestination(Node dest)
        {
            if (!Information.IsNothing(dest))
            {
                m_iDestinationID = dest.ID;
            }
            else
            {
                m_iDestinationID = 0;
            }

            m_oDestination = dest;
        }

        public Arc()
        {
        }

        public Arc(Direction dir, string move, Node dest)
        {
            Direction = dir;
            Move = move;
            SetDestination(dest);
        }

        public static Direction ReverseDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    {
                        return Direction.South;
                    }

                case Direction.NorthEast:
                    {
                        return Direction.SouthWest;
                    }

                case Direction.East:
                    {
                        return Direction.West;
                    }

                case Direction.SouthEast:
                    {
                        return Direction.NorthWest;
                    }

                case Direction.South:
                    {
                        return Direction.North;
                    }

                case Direction.SouthWest:
                    {
                        return Direction.NorthEast;
                    }

                case Direction.West:
                    {
                        return Direction.East;
                    }

                case Direction.NorthWest:
                    {
                        return Direction.SouthEast;
                    }

                case Direction.Up:
                    {
                        return Direction.Down;
                    }

                case Direction.Down:
                    {
                        return Direction.Up;
                    }
            }

            return default;
        }

        public static bool IsCardinalDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                case Direction.NorthEast:
                case Direction.East:
                case Direction.SouthEast:
                case Direction.South:
                case Direction.SouthWest:
                case Direction.West:
                case Direction.NorthWest:
                    {
                        return true;
                    }
            }

            return false;
        }
    }

    public class ArcList : CollectionBase
    {
        public Arc this[int Index]
        {
            get
            {
                return (Arc)List[Index];
            }

            set
            {
                List[Index] = value;
            }
        }

        public Arc this[Direction dir]
        {
            get
            {
                foreach (Arc a in List)
                {
                    if (a.Direction == dir)
                    {
                        return a;
                    }
                }

                return null;
            }

            set
            {
                for (var i = 0; i < List.Count; i++)
                {
                    if (((Arc)List[i]).Direction == dir)
                    {
                        List[i] = value;
                        break;
                    }
                }
            }
        }

        public int CardinalCount()
        {
            int iResult = 0;
            foreach (Arc a in List)
            {
                if (a.Direction != Direction.None & a.Direction != Direction.Go & a.Direction != Direction.Climb)
                {
                    iResult += 1;
                }
            }

            return iResult;
        }

        public int Add(Arc Item)
        {
            return List.Add(Item);
        }

        public bool Contains(string move)
        {
            foreach (Arc a in List)
            {
                if ((a.Move ?? "") == (move ?? ""))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(Direction dir)
        {
            foreach (Arc a in List)
            {
                if (a.Direction == dir)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Node
    {
        public enum States
        {
            Ready,
            Processed,
            Waiting,
            EndPath
        }

        private States m_State = States.Ready;

        public States State
        {
            get
            {
                return m_State;
            }

            set
            {
                m_State = value;
            }
        }

        private Node m_Origin = null;

        public Node Origin
        {
            get
            {
                return m_Origin;
            }

            set
            {
                m_Origin = value;
            }
        }

        private bool m_bArranged = false;

        public bool Arranged
        {
            get
            {
                return m_bArranged;
            }

            set
            {
                m_bArranged = value;
            }
        }

        private int m_iID = -1;

        public int ID
        {
            get
            {
                return m_iID;
            }

            set
            {
                m_iID = value;
            }
        }

        private string m_sName = string.Empty;

        public string Name
        {
            get
            {
                return m_sName;
            }

            set
            {
                m_sName = value.Replace("\"", "");
            }
        }

        private StringList m_Descriptions = new StringList();

        public StringList Descriptions
        {
            get
            {
                return m_Descriptions;
            }

            set
            {
                m_Descriptions = value;
            }
        }

        private string m_HyperLink = string.Empty;

        public string HyperLink
        {
            get
            {
                return m_HyperLink;
            }

            set
            {
                m_HyperLink = value;
            }
        }

        private bool m_IsLabelFile = false;

        public bool IsLabelFile
        {
            get
            {
                return m_IsLabelFile;
            }

            set
            {
                m_IsLabelFile = value;
            }
        }

        private string m_Note = string.Empty;

        public string Note
        {
            get
            {
                return m_Note;
            }

            set
            {
                m_Note = value;
            }
        }

        private Color m_Color = Color.White;

        public Color Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        private Point3D m_oPosition;

        public Point3D Position
        {
            get
            {
                return m_oPosition;
            }

            set
            {
                m_oPosition = value;
            }
        }

        private ArcList m_oArcList = new ArcList();

        public ArcList Arcs
        {
            get
            {
                return m_oArcList;
            }
        }

        public bool RisingMists = false;

        public bool Compare(Node n, bool comparedesc = true)
        {
            if (Information.IsNothing(n))
                return false;
            if ((Name ?? "") != (n.Name ?? ""))
                return false;
            if (n.RisingMists == false & Arcs.CardinalCount() != n.Arcs.CardinalCount())
                return false;
            if (comparedesc == true)
            {
                if (Descriptions.Contains(n.Descriptions) == false)
                    return false;
            }

            if (n.RisingMists == false)
            {
                foreach (Arc oArc in n.Arcs)
                {
                    if (oArc.Direction != Direction.None & oArc.Direction != Direction.Go & oArc.Direction != Direction.Climb)
                    {
                        if (ContainsArc(oArc) == false)
                            return false;
                    }
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is Node)
            {
                {
                    var withBlock = (Node)obj;
                    if (ID != withBlock.ID)
                        return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool ContainsArc(Arc Item)
        {
            foreach (Arc oArc in Arcs)
            {
                if (oArc.Direction != Direction.None & oArc.Direction != Direction.Go & oArc.Direction != Direction.Climb)
                {
                    if (Item.Direction == oArc.Direction)
                        return true;
                }
            }

            return false;
        }

        public bool ContainsArc(Direction Item)
        {
            foreach (Arc oArc in Arcs)
            {
                if (oArc.Direction != Direction.None & oArc.Direction != Direction.Go & oArc.Direction != Direction.Climb)
                {
                    if (Item == oArc.Direction)
                        return true;
                }
            }

            return false;
        }

        public bool ContainsLinkedArc(Direction item, string move = "")
        {
            foreach (Arc oArc in Arcs)
            {
                if (!Information.IsNothing(oArc.Destination))
                {
                    if (oArc.Direction != Direction.None)
                    {
                        if (item == oArc.Direction)
                        {
                            if (oArc.Direction == Direction.Go | oArc.Direction == Direction.Climb)
                            {
                                if (oArc.Move.ToLower().StartsWith(move.ToLower()) | move.ToLower().StartsWith(oArc.Move.ToLower()))
                                    return true;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool ContainsArc(Node Item)
        {
            foreach (Arc oArc in Arcs)
            {
                if (oArc.DestinationID > 0)
                {
                    if (oArc.DestinationID == Item.ID)
                        return true;
                }
            }

            return false;
        }

        public int AddArc(Direction dir, string name, Node dest)
        {
            var oArc = new Arc(dir, name, dest);
            return AddArc(oArc);
        }

        public int AddArc(Arc Item)
        {
            if (ContainsArc(Item) == false)
            {
                return Arcs.Add(Item);
            }
            else
            {
                return -1;
            }
        }
    }

    public class StringList : CollectionBase
    {
        public string this[int Index]
        {
            get
            {
                return Conversions.ToString(List[Index]);
            }

            set
            {
                List[Index] = value;
            }
        }

        public int Add(string Value)
        {
            return List.Add(Value);
        }

        public void Remove(string Value)
        {
            List.Remove(Value);
        }

        public bool Contains(StringList oList)
        {
            foreach (string s in oList)
            {
                if (Contains(s))
                    return true;
            }

            return false;
        }

        public bool Contains(string Value)
        {
            foreach (string s in List)
            {
                if ((Value ?? "") == (s ?? ""))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            string sReturn = string.Empty;
            foreach (string s in List)
            {
                if (sReturn.Length > 0)
                {
                    sReturn += "|";
                }

                sReturn += s;
            }

            return sReturn;
        }
    }

    public class NodeList : CollectionBase
    {
        private LabelList m_oLabelList = new LabelList();

        public LabelList Labels
        {
            get
            {
                return m_oLabelList;
            }
        }

        private int m_NextID = 1;

        public int NextID
        {
            get
            {
                if (List.Count == 0) // Cleared list means Next ID = 1
                {
                    m_NextID = 1;
                }

                return m_NextID;
            }

            set
            {
                m_NextID = value;
            }
        }

        public Node this[int Index]
        {
            get
            {
                return (Node)List[Index];
            }

            set
            {
                List[Index] = value;
            }
        }

        public int Add(string name, StringList desc, Point3D pos)
        {
            var oNode = new Node();
            oNode.ID = NextID;
            oNode.Name = name;
            oNode.Descriptions = desc;
            oNode.Position = new Point3D(pos.X, pos.Y, pos.Z);
            return Add(oNode);
        }

        public int Add(Node Item)
        {
            // Raise next ID value
            if (Item.ID >= m_NextID)
            {
                m_NextID = Item.ID + 1;
            }

            return List.Add(Item);
        }

        public void Remove(Node Item)
        {
            List.Remove(Item);
        }

        public bool Contains(Node Item)
        {
            foreach (Node n in List)
            {
                if (n.Compare(Item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(int ID)
        {
            foreach (Node n in List)
            {
                if (n.ID == ID)
                {
                    return true;
                }
            }

            return false;
        }

        public Node Find(Node Item)
        {
            foreach (Node n in List)
            {
                if (n.Compare(Item))
                {
                    return n;
                }
            }

            return null;
        }

        public Node Find(int ID)
        {
            foreach (Node n in List)
            {
                if (n.ID == ID)
                {
                    return n;
                }
            }

            return null;
        }

        public int FindCount(Node Item)
        {
            int iCount = 0;
            foreach (Node n in List)
            {
                if (n.Compare(Item))
                {
                    iCount += 1;
                }
            }

            return iCount;
        }

        public void ResetArranged()
        {
            foreach (Node n in List)
                n.Arranged = false;
        }

        public void ResetPathStates()
        {
            foreach (Node n in List)
            {
                n.State = Node.States.Ready;
                n.Origin = null;
            }
        }

        public void Arrange([Optional, DefaultParameterValue(null)] Node n)
        {
            if (Information.IsNothing(n))
            {
                if (List.Count > 0)
                {
                    n = (Node)List[0];
                }
                else
                {
                    return;
                }
            }

            n.Arranged = true;
            foreach (Arc a in n.Arcs)
            {
                if (!Information.IsNothing(a.Destination))
                {
                    if (a.Destination.Arranged == false)
                    {
                        var argn = a.Destination;
                        Arrange(argn); // Hantera tillbaka-länkar senare
                        Debug.WriteLine("Arranging " + n.ID);
                        if (a.Direction != Direction.None & a.Direction != Direction.Go & a.Direction != Direction.Climb)
                        {
                            var argnode = a.Destination;
                            if (IsPointOccupied(argnode, false))
                            {
                                // Debug.WriteLine("Moving from: " & a.Destination.ID)
                                a.Destination.Position.Offset(a.Direction); // Ska kanske inte alltid vara högsta rummet som ska flyttas???
                                var argoriginal = a.Destination;
                                OffsetAllNodes(argoriginal, a.Direction);
                            }
                        }
                    }
                }
            }
        }

        public void ArrangeSingle(Node n, Direction dir)
        {
            if (dir != Direction.None & dir != Direction.Go & dir != Direction.Climb)
            {
                if (IsPointOccupied(n))
                {
                    OffsetAllNodes(n, dir);
                }
            }
        }

        private void OffsetAllNodes(Node original, Direction dir)
        {
            foreach (Node n in List)
            {
                if (!Information.IsNothing(n.Position) & !Information.IsNothing(original.Position))
                {
                    if (n.Equals(original) == false)
                    {
                        if (dir == Direction.West | dir == Direction.NorthWest | dir == Direction.SouthWest)
                        {
                            if (n.Position.X <= original.Position.X)
                            {
                                n.Position.Offset(Direction.West);
                            }
                        }
                        else if (dir == Direction.East | dir == Direction.NorthEast | dir == Direction.SouthEast)
                        {
                            if (n.Position.X >= original.Position.X)
                            {
                                n.Position.Offset(Direction.East);
                            }
                        }

                        if (dir == Direction.North | dir == Direction.NorthWest | dir == Direction.NorthEast)
                        {
                            if (n.Position.Y <= original.Position.Y)
                            {
                                n.Position.Offset(Direction.North);
                            }
                        }
                        else if (dir == Direction.South | dir == Direction.SouthWest | dir == Direction.SouthEast)
                        {
                            if (n.Position.Y >= original.Position.Y)
                            {
                                n.Position.Offset(Direction.South);
                            }
                        }
                    }
                }
            }
        }

        public bool IsPointOccupied(Node node, bool checkline = true)
        {
            foreach (Node n in List)
            {
                if (n.ID != node.ID)
                {
                    if (!Information.IsNothing(n.Position) & !Information.IsNothing(node.Position))
                    {
                        if (n.Position.Equals(node.Position))
                        {
                            return true;
                        }

                        if (checkline == true)
                        {
                            foreach (Arc a in n.Arcs)
                            {
                                if (!Information.IsNothing(a.Destination))
                                {
                                    if (a.Destination.ID != node.ID)
                                    {
                                        if (!Information.IsNothing(a.Destination.Position))
                                        {
                                            var argdot = node.Position;
                                            var argpt1 = n.Position;
                                            var argpt2 = a.Destination.Position;
                                            if (IsPointOccupiedByLine(argdot, argpt1, argpt2))
                                            {
                                                // Debug.WriteLine(node.ID & " is between " & n.ID & " and " & a.Destination.ID)
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public void FixArcLinks()
        {
            foreach (Node n in List)
            {
                foreach (Arc a in n.Arcs)
                {
                    if (Information.IsNothing(a.Destination))
                    {
                        if (a.DestinationID > 0)
                        {
                            var argdest = Find(a.DestinationID);
                            a.SetDestination(argdest);
                        }
                    }
                }
            }
        }

        private Genie.Collections.ArrayList m_PathList = new Genie.Collections.ArrayList();

        public string PathText
        {
            get
            {
                var oSB = new StringBuilder();
                foreach (string item in m_PathList)
                {
                    var sItem = item;
                    if (sItem.Contains(" "))
                    {
                        sItem = "\"" + sItem + "\"";
                    }

                    if (oSB.Length > 0)
                    {
                        sItem = " " + sItem;
                    }

                    oSB.Append(sItem);
                }

                return oSB.ToString();
            }
        }

        public string PathVariableText
        {
            get
            {
                var oSB = new StringBuilder();
                foreach (string sItem in m_PathList)
                {
                    if (oSB.Length > 0)
                    {
                        oSB.Append("|" + sItem);
                    }
                    else
                    {
                        oSB.Append(sItem);
                    }
                }

                return oSB.ToString();
            }
        }

        public bool FindShortestPath(Node n1, Node n2)
        {
            m_PathList.Clear();
            ResetPathStates();
            var oQueue = new NodeList();
            oQueue.Add(n1);
            n1.State = Node.States.Waiting;
            n2.State = Node.States.EndPath;
            while (oQueue.Count > 0)
            {
                var n = oQueue[0];
                n.State = Node.States.Processed;
                oQueue.RemoveAt(0);
                if (n.ContainsArc(n2))
                {
                    n2.Origin = n;
                    break;
                }

                foreach (Arc a in n.Arcs)
                {
                    if (!Information.IsNothing(a.Destination))
                    {
                        if (a.Destination.State == Node.States.Ready)
                        {
                            a.Destination.State = Node.States.Waiting;
                            a.Destination.Origin = n;
                            var argItem = a.Destination;
                            oQueue.Add(argItem);
                        }
                    }
                }
            }

            // Mark path ( This routine needs to be called to find the actual "string" path later. )
            int iDestinationID = n2.ID;
            var nOrigin = n2;
            while (!Information.IsNothing(nOrigin))
            {
                iDestinationID = nOrigin.ID;
                nOrigin.State = Node.States.EndPath;
                nOrigin = nOrigin.Origin;
                if (!Information.IsNothing(nOrigin))
                {
                    foreach (Arc a in nOrigin.Arcs)
                    {
                        if (a.DestinationID == iDestinationID) // Found EXIT
                        {
                            if (a.Move.Length > 0)
                            {
                                m_PathList.Insert(0, a.Move);
                            }
                            else
                            {
                                var switchExpr = a.Direction;
                                switch (switchExpr)
                                {
                                    case Direction.North:
                                        {
                                            m_PathList.Insert(0, "n");
                                            break;
                                        }

                                    case Direction.NorthEast:
                                        {
                                            m_PathList.Insert(0, "ne");
                                            break;
                                        }

                                    case Direction.East:
                                        {
                                            m_PathList.Insert(0, "e");
                                            break;
                                        }

                                    case Direction.SouthEast:
                                        {
                                            m_PathList.Insert(0, "se");
                                            break;
                                        }

                                    case Direction.South:
                                        {
                                            m_PathList.Insert(0, "s");
                                            break;
                                        }

                                    case Direction.SouthWest:
                                        {
                                            m_PathList.Insert(0, "sw");
                                            break;
                                        }

                                    case Direction.West:
                                        {
                                            m_PathList.Insert(0, "w");
                                            break;
                                        }

                                    case Direction.NorthWest:
                                        {
                                            m_PathList.Insert(0, "nw");
                                            break;
                                        }

                                    case Direction.Up:
                                        {
                                            m_PathList.Insert(0, "u");
                                            break;
                                        }

                                    case Direction.Down:
                                        {
                                            m_PathList.Insert(0, "d");
                                            break;
                                        }

                                    case Direction.Out:
                                        {
                                            m_PathList.Insert(0, "out");
                                            break;
                                        }

                                    default:
                                        {
                                            m_PathList.Insert(0, a.Move);
                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    }

                    if (nOrigin.State != Node.States.Processed)
                        nOrigin = null; // Exit loop if data is invalid
                }
            }

            return default;
        }

        public Rectangle GetMapSize()
        {
            int iLowestX = 0;
            int iHighestX = 0;
            int iLowestY = 0;
            int iHighestY = 0;
            foreach (Node n in List)
            {
                if (!Information.IsNothing(n.Position))
                {
                    if (n.Position.X < iLowestX)
                        iLowestX = n.Position.X;
                    if (n.Position.X > iHighestX)
                        iHighestX = n.Position.X;
                    if (n.Position.Y < iLowestY)
                        iLowestY = n.Position.Y;
                    if (n.Position.Y > iHighestY)
                        iHighestY = n.Position.Y;
                }
            }

            if (iLowestX < 0)
            {
                iHighestX -= iLowestX;
                iLowestX = 0;
            }

            if (iLowestY < 0)
            {
                iHighestY -= iLowestY;
                iLowestY = 0;
            }

            return new Rectangle(0, 0, iHighestX - iLowestX + 40, iHighestY - iLowestY + 40);
        }

        public Point3D GetOffset()
        {
            int iLowestX = 0;
            int iLowestY = 0;
            var oPoint = new Point3D();
            foreach (Node n in List)
            {
                if (!Information.IsNothing(n.Position))
                {
                    if (n.Position.X < iLowestX)
                        iLowestX = n.Position.X;
                    if (n.Position.Y < iLowestY)
                        iLowestY = n.Position.Y;
                }
            }

            oPoint.X = -iLowestX + 20;
            oPoint.Y = -iLowestY + 20;
            return oPoint;
        }

        private static bool IsPointOccupiedByLine(Point3D dot, Point3D pt1, Point3D pt2)
        {
            double A = pt2.Y - pt1.Y;
            double B = pt1.X - pt2.X;
            double C = A * pt1.X + B * pt1.Y;
            if (dot.Z != pt1.Z | dot.Z != pt2.Z)
                return false;
            if (pt1.X < pt2.X)
            {
                if (dot.X < pt1.X | dot.X > pt2.X)
                {
                    return false;
                }
            }
            else if (pt1.X > pt2.X)
            {
                if (dot.X < pt2.X | dot.X > pt1.X)
                {
                    return false;
                }
            }

            if (pt1.Y < pt2.Y)
            {
                if (dot.Y < pt1.Y | dot.Y > pt2.Y)
                {
                    return false;
                }
            }
            else if (pt1.Y > pt2.Y)
            {
                if (dot.Y < pt2.Y | dot.Y > pt1.Y)
                {
                    return false;
                }
            }

            // Same point = Doesn't cross itself since there is no "line"
            if (pt1.X == pt2.X & pt1.Y == pt2.Y)
                return false;

            // A * PtX + B * PtY = C
            return Math.Abs(A * dot.X + B * dot.Y - C) < 0.000000001;
        }
    }
}