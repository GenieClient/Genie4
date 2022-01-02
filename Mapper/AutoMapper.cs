using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Mapper
{
    public class AutoMapper
    {
        public AutoMapper()
        {
            m_Form = new MapForm();
        }

        public AutoMapper(ref Genie.Globals globals)
        {
            m_Form = new MapForm();
            m_oGlobals = globals;
            CreateMapForm();
        }

        public event EventEchoTextEventHandler EventEchoText;

        public delegate void EventEchoTextEventHandler(string sText, Color oColor, Color oBgColor);

        public event EventSendTextEventHandler EventSendText;

        public delegate void EventSendTextEventHandler(string sText, string sSource);

        public event EventVariableChangedEventHandler EventVariableChanged;

        public delegate void EventVariableChangedEventHandler(string sVariable);

        private MapForm _m_Form;

        private MapForm m_Form
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_Form;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_Form != null)
                {
                    _m_Form.MapLoaded -= EventMapLoaded;
                    _m_Form.ListReset -= GraphForm_ListReset;
                    _m_Form.ClickNode -= GrapForm_ClickNode;
                    _m_Form.ZoneIDChange -= GraphForm_ZoneIDChange;
                    _m_Form.ZoneNameChange -= GraphForm_ZoneNameChange;
                    _m_Form.ToggleRecord -= GraphForm_ToggleRecord;
                    _m_Form.ToggleAllowDuplicates -= GraphForm_ToggleAllowDuplicates;
                    _m_Form.EchoMapPath -= GraphForm_EchoMapPath;
                    _m_Form.MoveMapPath -= GraphForm_MoveMapPath;
                }

                _m_Form = value;
                if (_m_Form != null)
                {
                    _m_Form.MapLoaded += EventMapLoaded;
                    _m_Form.ListReset += GraphForm_ListReset;
                    _m_Form.ClickNode += GrapForm_ClickNode;
                    _m_Form.ZoneIDChange += GraphForm_ZoneIDChange;
                    _m_Form.ZoneNameChange += GraphForm_ZoneNameChange;
                    _m_Form.ToggleRecord += GraphForm_ToggleRecord;
                    _m_Form.ToggleAllowDuplicates += GraphForm_ToggleAllowDuplicates;
                    _m_Form.EchoMapPath += GraphForm_EchoMapPath;
                    _m_Form.MoveMapPath += GraphForm_MoveMapPath;
                }
            }
        }

        private NodeList m_Nodes = new NodeList();
        private Node m_LastNode = null;
        private bool m_Recording = false;
        private Genie.Globals m_oGlobals;

        public string Name
        {
            get
            {
                return "AutoMapper";
            }
        }

        public string CharacterName
        {
            get
            {
                if (!Information.IsNothing(m_Form))
                {
                    return m_Form.CharacterName;
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                if (!Information.IsNothing(m_Form))
                {
                    m_Form.CharacterName = value;
                }
            }
        }

        private FormMain m_ParentForm = null;

        private void CreateMapForm()
        {
            m_Form = new MapForm();
            m_Form.ZoneID = get_GlobalVariable("zoneid");
            m_Form.ZoneName = get_GlobalVariable("zonename");
        }

        public bool IsClosing
        {
            get
            {
                if (Information.IsNothing(m_Form))
                    return false;
                return m_Form.IsClosing;
            }

            set
            {
                m_Form.IsClosing = value;
            }
        }

        public void Show(FormMain parent = null)
        {
            if (!Information.IsNothing(parent))
            {
                m_ParentForm = parent;
            }

            if (!Information.IsNothing(m_Form))
            {
                if (m_Form.Visible == false)
                {
                    if (!Information.IsNothing(parent))
                    {
                        m_Form.MdiParent = parent;
                    }
                }
            }

            if (!m_Form.Visible)
            {
                if (!Information.IsNothing(parent))
                {
                    m_Form.Top = 0;
                    m_Form.Height = parent.ClientHeight - SystemInformation.Border3DSize.Height * 2;
                    Size clientSize = (Size)parent.ClientSize;
                    m_Form.Left = Conversions.ToInteger(clientSize.Width / 2 - SystemInformation.Border3DSize.Width);
                    m_Form.Width = Conversions.ToInteger(clientSize.Width - SystemInformation.Border3DSize.Width * 2 - m_Form.Left);
                }

                m_Form.Show();
                m_Form.UpdateGraph(m_LastNode, m_Nodes, Direction.None);
            }

            m_Form.BringToFront();
        }

        // Not implemented
        public string ParseText(string Text)
        {
            return Text;
        }

        private ArrayList m_Movement = new ArrayList();
        private bool m_RoomUpdated = false;
        // private bool m_AddDupeRooms = true;
        private bool m_RisingMists = false;

        public void VariableChanged(string var)
        {
            if ((var ?? "") == "roomname")
            {
                m_RoomUpdated = true;
            }
            else if ((var ?? "") == "prompt" & m_RoomUpdated == true) // Check for room change on prompt
            {
                UpdateCurrentRoom();
            }
            else if ((var ?? "") == "connected")
            {
                m_LastNode = null;
            }
            else if ((var ?? "") == "roomexits")
            {
                m_RisingMists = get_GlobalVariable(var).Contains("obscured by a thick fog");
                if (m_RisingMists & m_DebugEnabled)
                    EchoText("[" + Name + "] RisingMists = TRUE");
            }
        }

        private void EventMapLoaded()
        {
            UpdateCurrentRoom(true);
        }

        private string GetValue(XmlNode xn, string key, string def = "")
        {
            if (!Information.IsNothing(xn))
            {
                if (!Information.IsNothing(xn.Attributes))
                {
                    if (!Information.IsNothing(xn.Attributes.GetNamedItem(key)))
                    {
                        return xn.Attributes.GetNamedItem(key).Value;
                    }
                }
            }

            return def;
        }

        private string RoomOnDisk(Node oNode)
        {
            try
            {
                var xdoc = new XmlDocument();
                XmlNodeList xnlist;
                var diDirectory = new DirectoryInfo(LocalDirectory.Path + @"\Maps");
                foreach (FileInfo dif in diDirectory.GetFiles())
                {
                    if ((dif.Extension.ToLower() ?? "") == ".xml")
                    {
                        xdoc = new XmlDocument();
                        xdoc.Load(dif.FullName);
                        xnlist = xdoc.SelectNodes("zone/node");
                        foreach (XmlNode xn in xnlist)
                        {
                            // Don't match linked node rooms as they are duplicates.
                            if (!GetValue(xn, "note").Contains(".xml"))
                            {
                                if ((oNode.Name ?? "") == (GetValue(xn, "name") ?? ""))
                                {
                                    bool bDescMatch = false;
                                    var xDescs = xn.SelectNodes("description");
                                    foreach (XmlNode xdesc in xDescs)
                                    {
                                        if (!Information.IsNothing(xdesc))
                                        {
                                            if ((oNode.Descriptions[0] ?? "") == (xdesc.InnerText ?? ""))
                                            {
                                                bDescMatch = true;
                                            }
                                        }
                                    }

                                    if (bDescMatch == true)
                                    {
                                        // Check exits here in a later version
                                        return dif.FullName;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                EchoText("[" + Name + "] Invalid maps in genie map directory.");
            }

            return string.Empty;
        }

        private void EchoRoomsOnDisk(Node oNode)
        {
            var xdoc = new XmlDocument();
            XmlNodeList xnlist;
            var diDirectory = new DirectoryInfo(LocalDirectory.Path + @"\Maps");
            bool bMatch = false;
            foreach (FileInfo dif in diDirectory.GetFiles())
            {
                if ((dif.Extension.ToLower() ?? "") == ".xml")
                {
                    xdoc = new XmlDocument();
                    xdoc.Load(dif.FullName);
                    xnlist = xdoc.SelectNodes("zone/node");
                    foreach (XmlNode xn in xnlist)
                    {
                        if ((oNode.Name ?? "") == (GetValue(xn, "name") ?? ""))
                        {
                            bool bDescMatch = false;
                            if (oNode.Descriptions.Count > 0)
                            {
                                var xDescs = xn.SelectNodes("description");
                                foreach (XmlNode xdesc in xDescs)
                                {
                                    if (!Information.IsNothing(xdesc))
                                    {
                                        if ((oNode.Descriptions[0] ?? "") == (xdesc.InnerText ?? ""))
                                        {
                                            bDescMatch = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bDescMatch = true;
                            } // No desc on node to match to. Assume match.

                            if (bDescMatch == true)
                            {
                                // Check exits here in a later version
                                bMatch = true;
                                this.EchoText("[" + Name + "] Found room #" + GetValue(xn, "id") + " on map: " + dif.FullName, true);
                            }
                        }
                    }
                }
            }

            if (bMatch == false)
            {
                EchoText("[" + Name + "] No matches.", true);
            }
        }

        private void UpdateCurrentRoom(bool bMapChanged = false)
        {
            if (Information.IsNothing(m_Form))
                m_Form = new MapForm();
            if (Information.IsNothing(m_Form.NodeList))
                m_Form.SetNodeList(m_Nodes);
            m_RoomUpdated = false;

            // -----------------------------------------------------
            // Set up a new oNode
            // -----------------------------------------------------

            var oNode = new Node();
            oNode.ID = m_Nodes.NextID;
            oNode.Name = get_GlobalVariable("roomname");
            oNode.Descriptions.Add(get_GlobalVariable("roomdesc"));
            oNode.RisingMists = m_RisingMists;

            // Set up all the exits
            if (IsExitSet("north"))
            {
                Node argdest = null;
                oNode.AddArc(Direction.North, "north", argdest);
            }

            if (IsExitSet("northeast"))
            {
                Node argdest1 = null;
                oNode.AddArc(Direction.NorthEast, "northeast", argdest1);
            }

            if (IsExitSet("east"))
            {
                Node argdest2 = null;
                oNode.AddArc(Direction.East, "east", argdest2);
            }

            if (IsExitSet("southeast"))
            {
                Node argdest3 = null;
                oNode.AddArc(Direction.SouthEast, "southeast", argdest3);
            }

            if (IsExitSet("south"))
            {
                Node argdest4 = null;
                oNode.AddArc(Direction.South, "south", argdest4);
            }

            if (IsExitSet("southwest"))
            {
                Node argdest5 = null;
                oNode.AddArc(Direction.SouthWest, "southwest", argdest5);
            }

            if (IsExitSet("west"))
            {
                Node argdest6 = null;
                oNode.AddArc(Direction.West, "west", argdest6);
            }

            if (IsExitSet("northwest"))
            {
                Node argdest7 = null;
                oNode.AddArc(Direction.NorthWest, "northwest", argdest7);
            }

            if (IsExitSet("up"))
            {
                Node argdest8 = null;
                oNode.AddArc(Direction.Up, "up", argdest8);
            }

            if (IsExitSet("down"))
            {
                Node argdest9 = null;
                oNode.AddArc(Direction.Down, "down", argdest9);
            }

            if (IsExitSet("out"))
            {
                Node argdest10 = null;
                oNode.AddArc(Direction.Out, "out", argdest10);
            }

            // Get first movement command in list
            string sMove = string.Empty;
            while (!Information.IsNothing(m_Movement) && m_Movement.Count > 0)
            {
                sMove = m_Movement[0].ToString().ToLower();
                m_Movement.RemoveAt(0);
                if (Information.IsNothing(m_LastNode))
                {
                    break;
                }
                else if (m_LastNode.ContainsLinkedArc(DirectionFromName(sMove), sMove))
                {
                    if (oNode.Compare(m_LastNode.Arcs[DirectionFromName(sMove)].Destination, false) == true)
                    {
                        break;
                    }
                    // Remove one more move.
                    else if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Removing move: " + sMove);
                }
                else if (m_LastNode.ContainsArc(DirectionFromName(sMove)) == false)
                {
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Removing move: " + sMove);
                }
                else
                {
                    break;
                }
            }

            var oDirMove = DirectionFromName(sMove);
            var oDirReverseMove = Arc.ReverseDirection(oDirMove);
            if (m_DebugEnabled == true)
                EchoText("[" + Name + "] Move = " + sMove);

            // Set position
            if (m_Recording == true & !Information.IsNothing(m_LastNode))
            {
                if (!Information.IsNothing(m_LastNode.Position))
                {
                    if (Information.IsNothing(oNode.Position))
                    {
                        oNode.Position = new Point3D(m_LastNode.Position);
                        if (oDirMove != Direction.None & oDirMove != Direction.Climb & oDirMove != Direction.Go)
                        {
                            oNode.Position.Offset(oDirMove);
                        }
                        else
                        {
                            oNode.Position.Offset(m_eLastMovement);
                        }
                    }
                }
            }

            // -----------------------------------------------------
            // Locate the room
            // -----------------------------------------------------

            int iFindCount = m_Nodes.FindCount(oNode);
            if (m_DebugEnabled == true)
                EchoText("[" + Name + "] Find count = " + iFindCount.ToString());
            if (bMapChanged == false & iFindCount == 0 & Information.IsNothing(m_LastNode) & m_Recording == false) // Locate room on disk and load map
            {
                if (m_DebugEnabled == true)
                    EchoText("[" + Name + "] Checking Map On Disk");
                string sMap = RoomOnDisk(oNode);
                if (sMap.Length > 0)
                {
                    EchoText("[" + Name + "] Activating Map: " + sMap);
                    if (m_Form.LoadXML(sMap) == true)
                    {
                        UpdateCurrentRoom(true);
                        // iFindCount = m_Nodes.FindCount(oNode)
                        return;
                    }
                }
            }

            // Let's see if the node we walked from has an exit in this direction.
            if (!Information.IsNothing(m_LastNode))
            {
                if (m_DebugEnabled == true)
                    EchoText("[" + Name + "] Last node #" + m_LastNode.ID);

                // Does the last room have this exit already?
                if (m_LastNode.ContainsLinkedArc(oDirMove, sMove))
                {
                    if (iFindCount > 1) // More then one room with same details in list
                    {
                        oNode = m_LastNode.Arcs[oDirMove].Destination;
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Located node (using arc) #" + oNode.ID);
                    }
                    else if (iFindCount == 1) // Move us here
                    {
                        oNode = m_Nodes.Find(oNode);
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Located node #" + oNode.ID);
                    }
                    else if (!Information.IsNothing(m_LastNode.Arcs[oDirMove].Destination))
                    {
                        if (oNode.Compare(m_LastNode.Arcs[oDirMove].Destination, false) == true)
                        {
                            // Assume same node that changed desc (And if we are recording, add the desc)
                            oNode = m_LastNode.Arcs[oDirMove].Destination;
                            EchoText("[" + Name + "] Room description mismatch #" + oNode.ID);
                            if (m_Recording == true)
                            {
                                oNode.Descriptions.Add(get_GlobalVariable("roomdesc"));
                                EchoText("[" + Name + "] Adding new description to room #" + oNode.ID);
                            }
                        }
                        else
                        {
                            if (m_DebugEnabled == true)
                                EchoText("[" + Name + "] ERROR in destination. Please investigate arcs from node #" + m_LastNode.ID);
                            oNode = null;
                        }
                    }
                    else
                    {
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] ERROR in arc (" + sMove + ") Please investigate node #" + m_LastNode.ID);
                        oNode = null;
                    }
                }
                else if (sMove.Length == 0) // Empty move - Try and locate ANY exit from lastnode to this room.
                {
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Blank move direction #" + oNode.ID);
                    Node oMatchNode = null;
                    bool bMultiMatch = false;
                    foreach (Arc a in m_LastNode.Arcs)
                    {
                        if (!Information.IsNothing(a.Destination))
                        {
                            if (oNode.Compare(a.Destination, true))
                            {
                                if (Information.IsNothing(oMatchNode))
                                {
                                    oMatchNode = a.Destination;
                                }
                                else
                                {
                                    bMultiMatch = true;
                                }
                            }
                        }
                    }

                    if (!Information.IsNothing(oMatchNode) & bMultiMatch == false)
                    {
                        oNode = oMatchNode;
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Located node #" + oNode.ID);
                    }
                    else if (iFindCount == 1) // Move us here
                    {
                        oNode = m_Nodes.Find(oNode);
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Located node #" + oNode.ID);
                    }
                    else
                    {
                        oNode = null;
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Unknown node.");
                    }
                }
                else // End ContainsLinkedArc()
                {
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] No exit linked in this direction from the last node.");

                    // kolla alla matchande rum efter exit till lastroom
                    Node oMatchNode = null;
                    Node oMatchLink = null;
                    bool bMultiMatch = false;
                    foreach (Node n in m_Nodes)
                    {
                        if (n.ID != m_LastNode.ID) // Länka inte från samma rum till samma rum
                        {
                            if (n.Compare(oNode))
                            {
                                foreach (Arc a in n.Arcs)
                                {
                                    if (a.Direction == oDirReverseMove) // Noder som matchar och som har en exit åt motsatt håll
                                    {
                                        if (!Information.IsNothing(a.Destination)) // Linked exit
                                        {
                                            if (a.DestinationID == m_LastNode.ID) // Motsatsen länkar till vårat rum
                                            {
                                                if (Information.IsNothing(oMatchNode))
                                                {
                                                    oMatchNode = n;
                                                }
                                                else
                                                {
                                                    bMultiMatch = true;
                                                }
                                            }
                                        }
                                        else if (Information.IsNothing(oMatchLink)) // Unlinked exit
                                        {
                                            oMatchLink = n;
                                        }
                                        else
                                        {
                                            bMultiMatch = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (m_Recording == true & iFindCount == 0)
                    {
                        EchoText("[" + Name + "] Added new node #" + oNode.ID);
                        m_Nodes.Add(oNode);
                    }
                    else if (bMultiMatch == false & m_AllowDuplicates == true)
                    {
                        EchoText("[" + Name + "] Added duplicate room #" + oNode.ID);
                        m_Nodes.Add(oNode);
                    }
                    else if (bMultiMatch == true)
                    {
                        if (m_Recording == true & m_AllowDuplicates == true & oDirMove != Direction.Climb & oDirMove != Direction.Go & oDirMove != Direction.None & oDirMove != Direction.Out)
                        {
                            EchoText("[" + Name + "] Added new multi match room #" + oNode.ID);
                            m_Nodes.Add(oNode);
                        }
                        else if (iFindCount == 1)
                        {
                            oNode = m_Nodes.Find(oNode);
                            if (m_DebugEnabled == true)
                                EchoText("[" + Name + "] Located room to #" + oNode.ID);
                        }
                        else
                        {
                            if (m_DebugEnabled == true)
                                EchoText("[" + Name + "] Unlinked and unknown node.");
                            oNode = null;
                        }
                    }
                    else if (!Information.IsNothing(oMatchNode)) // Not recording and multimatch
                    {
                        oNode = oMatchNode;
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Found reverse node #" + oNode.ID);
                    }
                    else if (!Information.IsNothing(oMatchLink)) // Link
                    {
                        oNode = oMatchLink;
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Located link node to #" + oNode.ID);
                    }
                    else if (m_Recording == true & m_AllowDuplicates == true & oDirMove != Direction.Climb & oDirMove != Direction.Go & oDirMove != Direction.None & oDirMove != Direction.Out)
                    {
                        EchoText("[" + Name + "] Added new multi match room #" + oNode.ID);
                        m_Nodes.Add(oNode);
                    }
                    else if (iFindCount == 1)
                    {
                        oNode = m_Nodes.Find(oNode);
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Located node #" + oNode.ID);
                    }
                    else
                    {
                        oNode = null;
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Unlinked and unknown node.");
                    }
                }

                if (!Information.IsNothing(oNode))
                {
                    string sDirections = string.Empty;
                    string sPortals = string.Empty;
                    foreach (Arc oArc in oNode.Arcs)
                    {
                        if (Information.IsNothing(oArc.Destination))
                        {
                            if (m_Recording == true)
                                EchoText(oArc.Direction.ToString() + ": <not set>");
                        }
                        else if (oArc.Direction == Direction.Go | oArc.Direction == Direction.Climb)
                        {
                            sPortals += Interaction.IIf(sPortals.Length > 0, ", ", "") + oArc.Move;
                        }
                        else
                        {
                            sDirections += Interaction.IIf(sDirections.Length > 0, ", ", "") + oArc.Move;
                        }
                    }

                    if (m_RisingMists & sDirections.Length > 0)
                        EchoText("Mapped directions: " + sDirections, true);
                    if (sPortals.Length > 0)
                        EchoText("Mapped exits: " + sPortals, true);
                    set_GlobalVariable("roomportals", sPortals.Replace(", ", "|"));
                    if (m_Recording == true)
                    {
                        bool bExitAdded = false;
                        if (oDirMove == Direction.Go | oDirMove == Direction.Climb)
                        {
                            if (m_LastNode.Arcs.Contains(sMove) == false)
                            {
                                m_LastNode.AddArc(oDirMove, sMove, oNode);
                                bExitAdded = true;
                            }
                        }
                        else
                        {
                            // Cardinal
                            bExitAdded = SetArc(oNode, oDirMove);

                            // Automatically set return in opposite direction on Duplicate mode TEMP TEMP TEMP TEMP
                            if (m_AllowDuplicates == true)
                            {
                                if (!Information.IsNothing(oDirReverseMove) & !Information.IsNothing(m_LastNode))
                                {
                                    if (oNode.Arcs.Contains(oDirReverseMove))
                                    {
                                        if (Information.IsNothing(oNode.Arcs[oDirReverseMove].Destination))
                                        {
                                            oNode.Arcs[oDirReverseMove].SetDestination(m_LastNode);
                                        }
                                    }
                                }
                            }
                        }

                        if (bExitAdded)
                        {
                            EchoText("[" + Name + "] Linking exit from #" + m_LastNode.ID + " to #" + oNode.ID + ": " + sMove);
                        }
                    }
                }
            }
            else // End: If Not IsNothing(m_LastNode)
            {
                if (m_DebugEnabled == true)
                    EchoText("[" + Name + "] Last node not known!");

                // First room?
                if (m_Recording == true)
                {
                    if (m_Nodes.Count == 0)
                    {
                        EchoText("[" + Name + "] Added first node #" + oNode.ID);
                        oNode.Position = new Point3D();
                        m_Nodes.Add(oNode);
                    }
                    else if (iFindCount == 1)
                    {
                        oNode = m_Nodes.Find(oNode);
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Located node #" + oNode.ID);
                    }
                    else
                    {
                        oNode = null;
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Unknown node.");
                    }
                }
                else if (iFindCount > 1)
                {
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Unable to locate specific node.");
                    oNode = null;
                }
                else if (iFindCount == 1)
                {
                    oNode = m_Nodes.Find(oNode);
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Located node #" + oNode.ID);
                }
                else if (iFindCount == 0)
                {
                    if (m_Nodes.Count > 0)
                    {
                        if (m_DebugEnabled == true)
                            EchoText("[" + Name + "] Unknown node.");
                    }
                    else if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Empty map.");
                    oNode = null;
                }
            }

            // -----------------------------------------------------
            // Update Graph
            // -----------------------------------------------------

            if (!Information.IsNothing(oNode) && oNode.IsLabelFile == true)
            {
                m_LastNode = null;
                if (bMapChanged == false)
                {
                    string sFile = string.Empty;
                    foreach (string s in oNode.Note.Split('|'))
                    {
                        if (s.ToLower().EndsWith(".xml"))
                        {
                            sFile = s;
                            break;
                        }
                    }

                    if (m_Form.LoadXML(sFile) == true)
                    {
                        UpdateCurrentRoom(true);
                        return;
                    }
                    else
                    {
                        EchoText("[" + Name + "] Failed to load linked map: " + sFile);
                    }
                }
            }
            else
            {
                if (!Information.IsNothing(m_Form))
                {
                    m_Form.UpdateGraph(oNode, m_Nodes, m_eLastMovement);
                }

                m_LastNode = oNode;
            }

            // -----------------------------------------------------
            // Set global variables
            // -----------------------------------------------------

            if (!Information.IsNothing(oNode))
            {
                if (m_DebugEnabled)
                    EchoText("roomid = " + oNode.ID.ToString());
                set_GlobalVariable("roomid", oNode.ID.ToString());
                if (oNode.ContainsArc(Direction.North))
                {
                    set_GlobalVariable("northid", oNode.Arcs[Direction.North].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("northid", "-1");
                }

                if (oNode.ContainsArc(Direction.NorthEast))
                {
                    set_GlobalVariable("northeastid", oNode.Arcs[Direction.NorthEast].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("northeastid", "-1");
                }

                if (oNode.ContainsArc(Direction.East))
                {
                    set_GlobalVariable("eastid", oNode.Arcs[Direction.East].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("eastid", "-1");
                }

                if (oNode.ContainsArc(Direction.SouthEast))
                {
                    set_GlobalVariable("southeastid", oNode.Arcs[Direction.SouthEast].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("southeastid", "-1");
                }

                if (oNode.ContainsArc(Direction.South))
                {
                    set_GlobalVariable("southid", oNode.Arcs[Direction.South].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("southid", "-1");
                }

                if (oNode.ContainsArc(Direction.SouthWest))
                {
                    set_GlobalVariable("southwestid", oNode.Arcs[Direction.SouthWest].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("southwestid", "-1");
                }

                if (oNode.ContainsArc(Direction.West))
                {
                    set_GlobalVariable("westid", oNode.Arcs[Direction.West].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("westid", "-1");
                }

                if (oNode.ContainsArc(Direction.NorthWest))
                {
                    set_GlobalVariable("northwestid", oNode.Arcs[Direction.NorthWest].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("northwestid", "-1");
                }

                if (oNode.ContainsArc(Direction.Up))
                {
                    set_GlobalVariable("upid", oNode.Arcs[Direction.Up].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("upid", "-1");
                }

                if (oNode.ContainsArc(Direction.Down))
                {
                    set_GlobalVariable("downid", oNode.Arcs[Direction.Down].DestinationID.ToString());
                }
                else
                {
                    set_GlobalVariable("downid", "-1");
                }
            }
            else
            {
                set_GlobalVariable("roomid", "0"); // Unknown
                set_GlobalVariable("northid", "-1");
                set_GlobalVariable("northeastid", "-1");
                set_GlobalVariable("eastid", "-1");
                set_GlobalVariable("southeastid", "-1");
                set_GlobalVariable("southid", "-1");
                set_GlobalVariable("southwestid", "-1");
                set_GlobalVariable("westid", "-1");
                set_GlobalVariable("northwestid", "-1");
                set_GlobalVariable("upid", "-1");
                set_GlobalVariable("downid", "-1");
                set_GlobalVariable("roomportals", "");
            }
        }

        private bool m_DebugEnabled = false;
        private int m_TimeOutMS = 1500;

        public void ParseCommand(string cmd, FormMain form)
        {
            string sCmd = string.Empty;
            string sArg = string.Empty;
            int I = cmd.IndexOf(" ");
            if (I > 0)
            {
                sCmd = cmd.Substring(I + 1);
                int J = sCmd.IndexOf(" ");
                if (J > 0)
                {
                    sArg = sCmd.Substring(J + 1);
                    sCmd = sCmd.Substring(0, J);
                }
            }

            if (sCmd.Length > 0)
            {
                if (Information.IsNothing(m_Form))
                {
                    m_Form = new MapForm();
                }

                if (Information.IsNothing(m_Form.NodeList))
                {
                    m_Form.SetNodeList(m_Nodes);
                }

                var switchExpr = sCmd.ToLower();
                switch (switchExpr)
                {
                    case "load":
                        {
                            if (sArg.Length > 0)
                            {
                                if (sArg.Contains(@"\") == false)
                                {
                                    sArg = LocalDirectory.Path + @"\Maps\" + sArg;
                                }

                                if (sArg.ToLower().EndsWith(".xml") == false)
                                {
                                    sArg += ".xml";
                                }

                                if (m_Form.LoadXML(sArg) == true)
                                {
                                    EchoText("[" + Name + "] Successfully loaded map: " + sArg, true);
                                    UpdateCurrentRoom(true);
                                    return;
                                }
                                else
                                {
                                    EchoText("[" + Name + "] Failed to load map: " + sArg, true);
                                }
                            }

                            break;
                        }

                    case "save":
                        {
                            if (sArg.Length > 0)
                            {
                                // Filename is specified:
                                if (sArg.Contains(@"\") == false)
                                {
                                    sArg = LocalDirectory.Path + @"\Maps\" + sArg;
                                }
                                if (sArg.ToLower().EndsWith(".xml") == false)
                                {
                                    sArg += ".xml";
                                }
                                if (m_Form.SaveXML(sArg) == false)
                                {
                                    EchoText("[" + Name + "] Failed to save map: " + sArg, true);
                                }
                                else
                                {
                                    EchoText("[" + Name + "] Map saved: " + sArg, true);
                                }
                                break;
                            }
                            
                            // No file name specified, attempt to use current file name:
                            if (m_Form.SaveXML() == false)
                            {
                                EchoText("[" + Name + "] Failed to save map: " + m_Form.MapFile, true);
                            }
                            else
                            {
                                EchoText("[" + Name + "] Map saved: " + m_Form.MapFile, true);
                            }
                            break;
                        }

                    case "clear":
                        {
                            EchoText("[" + Name + "] Clearing map.", true);
                            m_Form.ClearMap();
                            break;
                        }

                    case "reset":
                        {
                            EchoText("[" + Name + "] Resetting.", true);
                            m_LastNode = null;
                            m_Form.ClearMap();
                            UpdateCurrentRoom();
                            break;
                        }

                    case "record":
                        {
                            if (sArg.Length > 0)
                            {
                                bool recordSetting = StringToBoolean(sArg);
                                EchoText("[" + Name + "] Record " + recordSetting, true);
                                m_Form.SetRecordToggle(recordSetting);
                                break;
                            }
                            EchoText("[" + Name + "] Record - need to specify true or false.", true);
                            break;
                        }

                    case "lock":
                    case "locknodes":
                        {
                            if (sArg.Length > 0)
                                m_Form.SetLockPositionsToggle(StringToBoolean(sArg));
                            break;
                        }

                    case "snap":
                        {
                            if (sArg.Length > 0) {
                                bool snapSetting = StringToBoolean(sArg);
                                EchoText("[" + Name + "] Snap to grid - " + snapSetting, true);
                                m_Form.SetSnapToggle(snapSetting);
                                break;
                            }
                            EchoText("[" + Name + "] Snap - need to specify true or false.", true);
                            break;
                        }

                    case "allowdupes":
                        {
                            if (sArg.Length > 0)
                            {
                                bool dupesSetting = StringToBoolean(sArg);
                                EchoText("[" + Name + "] Allowdupes - " + dupesSetting, true);
                                m_Form.SetAllowDuplicatesToggle(dupesSetting);
                                break;
                            }
                            EchoText("[" + Name + "] Allowdupes - need to specify true or false.", true);
                            break;
                        }

                    case "show":
                        {
                            Show();
                            break;
                        }

                    case "hide":
                        {
                            if (!Information.IsNothing(m_Form))
                            {
                                m_Form.Close();
                            }
                            break;
                        }

                    case "debug":
                        {
                            if (sArg.Length > 0)
                            {
                                m_DebugEnabled = StringToBoolean(sArg);
                            }
                            else
                            {
                                m_DebugEnabled = !m_DebugEnabled;
                            }
                            EchoText("[" + Name + "] Debug = " + m_DebugEnabled.ToString(), true);
                            break;
                        }

                    case "walk":
                    case "walkto":
                    case "g":
                    case "go":
                    case "goto":
                        {
                            if (sArg.Length > 0)
                            {
                                int iNodeID = 0;
                                if (sArg.Length > 3)
                                {
                                // Other zone
                                // - Find the destination map
                                // - Find what path it needs to take trough the different zones
                                // Integer.TryParse(sArg.Substring(0, 3), iNodeID)
                                }
                                else
                                {
                                    int.TryParse(sArg, out iNodeID);
                                }

                                if (iNodeID == 0)
                                {
                                    foreach (Node n in m_Nodes)
                                    {
                                        foreach (string s in n.Note.Split('|'))
                                        {
                                            if (s.ToLower().StartsWith(sArg.ToLower()))
                                            {
                                                EchoText("[" + Name + "] Goto: " + s, true);
                                                iNodeID = n.ID;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (iNodeID > 0)
                                {
                                    var n = m_Nodes.Find(iNodeID);
                                    if (!Information.IsNothing(n))
                                    {
                                        EchoText("#goto " + sArg, true);
                                        SendText("#parse DESTINATION FOUND");
                                        WalkToNode(n);
                                    }
                                    else
                                    {
                                        EchoText("[" + Name + "] Destination ID #" + iNodeID.ToString() + " not found - your current location is unknown.", true);
                                        SendText("#parse DESTINATION NOT FOUND");
                                    }
                                }
                                else
                                {
                                    EchoText("[" + Name + "] Destination ID \"" + sArg + "\" not found.", true);
                                    SendText("#parse DESTINATION NOT FOUND");
                                }
                            }
                            else
                            {
                                EchoText("[" + Name + "] Goto - please specify a room id to travel to.", true);
                            }

                            break;
                        }

                    case "find":
                    case "locate":
                        {
                            if (sArg.Length > 0)
                            {
                                var oNode = new Node();
                                if (sArg.Contains("|"))
                                {
                                    oNode.Name = sArg.Split('|')[0];
                                    oNode.Descriptions.Add(sArg.Split('|')[1]);
                                }
                                else
                                {
                                    oNode.Name = sArg;
                                }

                                EchoRoomsOnDisk(oNode);
                            }
                            else
                            {
                                EchoText("[" + Name + "] Locate - please specify room title or title|description to locate.", true);
                            }
                            break;
                        }

                    case "select":
                        {
                            if (sArg.Contains("|"))
                            {
                                // selecting multiple nodes doesn't seem to work
                                string[] splitArgs = sArg.Split('|');
                                m_Form.SelectNodes(splitArgs[0], splitArgs[1]);
                                EchoText("[" + Name + "] Selected nodes " + splitArgs[0] + " and " + splitArgs[1]  + ".", true);
                            }
                            else
                            {
                                EchoText("[" + Name + "] Selected node " + sArg + ".", true);
                                m_Form.SelectNodes(sArg);
                            }
                            break;
                        }

                    case "delete":
                        {
                            if (sArg.Length == 0)
                            {
                                // delete the room the player is in:
                                if (!Information.IsNothing(m_LastNode))
                                {
                                    m_Form.EraseRoom(m_LastNode);
                                    EchoText("[" + Name + "] Deleting current room (" + m_LastNode.ID + ")", true);
                                } else
                                {
                                    EchoText("[" + Name + "] Delete - can't delete, current room is unknown.", true);
                                }
                            }
                            else
                            {
                                // delete the room the player specifies:
                                int iNodeID;
                                int.TryParse(sArg, out iNodeID);
                                if (iNodeID > 0)
                                {
                                    var n = m_Nodes.Find(iNodeID);
                                    if (!Information.IsNothing(n))
                                    {
                                        m_Form.EraseRoom(n);
                                        EchoText("[" + Name + "] Delete - removed room \"" + iNodeID + "\".", true);
                                    }
                                    else
                                    {
                                        EchoText("[" + Name + "] Delete - could not locate room \"" + sArg + "\".", true);
                                    }
                                } else
                                {
                                    EchoText("[" + Name + "] Delete - invalid room specified \"" + sArg + "\"", true);
                                }
                            }
                            break;
                        }

                    case "label":
                    case "note":
                    case "labels":
                    case "notes":
                        {
                            if (sArg.Length == 0)
                            {
                                // Show all labels in map zone (doesn't matter if player is located or not)
                                EchoText("[" + Name + "] Listing current zone labels:", true);
                                SendText("#parse [" + Name + "] Listing current zone labels:");
                                foreach (Node n in m_Nodes)
                                {
                                    if (n.Note.Length > 0)
                                    {
                                        EchoText(Constants.vbTab + n.Note + " (" + n.ID.ToString() + ")", true);
                                        SendText("#parse " + Constants.vbTab + n.Note + " (" + n.ID.ToString() + ")");
                                    }
                                }
                                break;
                            }
                            // Label current room:
                            if (!Information.IsNothing(m_LastNode))
                            {
                                EchoText("[" + Name + "] Label added for current room: " + sArg, true);
                                m_LastNode.Note = Conversions.ToString(Interaction.IIf(m_LastNode.Note.Length > 0, m_LastNode.Note + "|", "") + sArg);   
                            } else
                            {
                                EchoText("[" + Name + "] Current location unknown, cannot add note.", true);
                            }
                            break;
                        }

                    case "color":
                        {
                            // Color current room
                            if (!Information.IsNothing(m_LastNode))
                            {
                                if (sArg.Length > 0)
                                {
                                    EchoText("[" + Name + "] Color set for current room: " + sArg, true);
                                    m_LastNode.Color = Genie.ColorCode.StringToColor(sArg);
                                    if (!Information.IsNothing(m_Form))
                                    {
                                        m_Form.UpdateGraph(m_LastNode, m_Nodes, m_eLastMovement);
                                    }
                                }
                            } else
                            {
                                EchoText("[" + Name + "] Please specify a color (ex: green).", true);
                            }

                            break;
                        }

                    case "level":
                        {
                            break;
                        }

                    case "zoom":
                        {
                            break;
                        }

                    case "zoneid":
                    case "id":
                        {
                            if (sArg.Length == 0)
                            {
                                EchoText("[" + Name + "] Zone ID: " + m_Form.ZoneID, true);
                            }
                            else
                            {
                                EchoText("[" + Name + "] Zone ID set to: " + sArg, true);
                                m_Form.ZoneID = sArg;
                            }

                            break;
                        }

                    case "zonename":
                    case "name":
                        {
                            if (sArg.Length == 0)
                            {
                                EchoText("[" + Name + "] Zone name: " + m_Form.ZoneName, true);
                            }
                            else
                            {
                                EchoText("[" + Name + "] Zone name set to: " + sArg, true);
                                m_Form.ZoneName = sArg;
                                m_Form.UpdateMainWindowTitle();
                            }

                            break;
                        }

                    case "timeout":
                        {
                            if (sArg.Length > 0)
                            {
                                int.TryParse(sArg, out m_TimeOutMS);
                                EchoText("[" + Name + "] Time out set to (milliseconds): " + m_TimeOutMS.ToString(), true);
                            } else
                            {
                                EchoText("[" + Name + "] Please specify timeout in milliseconds.", true);
                            }
                            break;
                        }

                    case "roomid":
                        {
                            if (sArg.Length > 0)
                            {
                                int ID;
                                int.TryParse(sArg, out ID);
                                if (ID > 0)
                                {
                                    var oNode = m_Nodes.Find(ID);
                                    if (!Information.IsNothing(oNode))
                                    {
                                        set_GlobalVariable("roomid", ID.ToString());
                                        EchoText("[" + Name + "] Current node set to #" + ID.ToString(), true);
                                        if (!Information.IsNothing(m_Form))
                                        {
                                            m_Form.UpdateGraph(oNode, m_Nodes, m_eLastMovement);
                                        }

                                        m_LastNode = oNode;
                                    } else
                                    {
                                        EchoText("[" + Name + "] Room id " + ID + " not found on this map.", true);
                                    }
                                } else
                                {
                                    EchoText("[" + Name + "] Invalid roomid specified - please enter a number.", true);
                                }
                            } else
                            {
                                EchoText("[" + Name + "] Please specify a roomid.", true);
                            }
                            break;
                        }

                    case "path":
                        {
                            if (sArg.Length > 0)
                            {
                                int ID;
                                int.TryParse(sArg, out ID);
                                if (ID > 0)
                                {
                                    var oNode = m_Nodes.Find(ID);
                                    if (!Information.IsNothing(oNode))
                                    {
                                        GetNodePath(oNode);
                                    }
                                }
                            }

                            break;
                        }
                    case "help":
                        {
                            EchoText("", true);
                            EchoText("AutoMapper commands", true);
                            EchoText("All commands start with #mapper (or #m), some can be used without prefix, like #goto.");
                            EchoText("", true);

                            EchoText("#allowdupes - Toggles mapper to allow or disallow duplicate room descriptions when recording.", true);
                            EchoText(Constants.vbTab + "Example: #mapper allowdupes true", true);
                            EchoText(Constants.vbTab + "Example: #mapper allowdupes false", true);
                            EchoText("", true);

                            EchoText("#clear - Clears the current map of all rooms.", true);
                            EchoText(Constants.vbTab + "Example: #mapper clear", true);
                            EchoText("", true);

                            EchoText("#color - sets the color of the current room", true);
                            EchoText(Constants.vbTab + "Example: #mapper color green", true);
                            EchoText("", true);

                            EchoText("#debug - Displays setting or toggles mapper debug mode to display additional info.", true);
                            EchoText(Constants.vbTab + "Example: #mapper debug", true);
                            EchoText(Constants.vbTab + "Example: #mapper debug true", true);
                            EchoText("", true);

                            EchoText("#delete - Deletes the current room or a specified room.", true);
                            EchoText(Constants.vbTab + "Example: #mapper delete - removes the current room from the map.", true);
                            EchoText(Constants.vbTab + "Example: #mapper delete 1 - removes room 1 from the map.", true);
                            EchoText("", true);

                            EchoText("#find / #locate - Searches all maps for a specific room. Specify name or name|description.", true);
                            EchoText(Constants.vbTab + "Example: #mapper find First Provincial Bank, Lobby", true);
                            EchoText(Constants.vbTab + "Example: #mapper find First Provincial Bank, Lobby|Marble tiled floors covered with heavy rugs and walls of polished jasper that gleam a cool blue mark this bank as solid and secure (and expensive).  An official money-changing booth is to one side and a row of tellers windows faces you.  Several guards, armed and armored, stand ready for trouble of any sort.  Near the tellers stands a table of fine wood for those who need to do some writing.", true);
                            EchoText("", true);

                            EchoText("#goto / #go / #g / #walk / #walkto - Used to travel to another room on the current map.", true);
                            EchoText(Constants.vbTab + "Example: #goto 1 ", true);
                            EchoText("", true);

                            EchoText("#hide - Hides the automapper window.", true);
                            EchoText(Constants.vbTab + "Example: #mapper hide", true);
                            EchoText(Constants.vbTab + "See also: #show", true);
                            EchoText("", true);

                            EchoText("#id / #zoneid - displays or sets the current zone id.", true);
                            EchoText(Constants.vbTab + "Example: #mapper zoneid - shows the current id", true);
                            EchoText(Constants.vbTab + "Example: #mapper zoneid 1 - sets the id to 1", true);
                            EchoText("", true);

                            EchoText("#load - Attempts to load a map from disk.", true);
                            EchoText(Constants.vbTab + "Example: #mapper load Map1_Crossing", true);
                            EchoText(Constants.vbTab + "See also: #save for path options", true);
                            EchoText("", true);

                            EchoText("#lock / #locknodes - Toggles the room lock setting when recording.", true);
                            EchoText(Constants.vbTab + "Example: #mapper lock true", true);
                            EchoText(Constants.vbTab + "Example: #mapper lock false", true);
                            EchoText(Constants.vbTab + "Note: locking can prevent room shifts when rooms overlap.", true);
                            EchoText("", true);

                            EchoText("#name / #zonename - displays or sets the current zone name.", true);
                            EchoText(Constants.vbTab + "Example: #mapper zonename - shows the current name", true);
                            EchoText(Constants.vbTab + "Example: #mapper zonename The Crossing - sets the name", true);
                            EchoText("", true);

                            EchoText("#note / #label / #notes / #labels - Displays all zone notes or adds a note to the current room.", true);
                            EchoText(Constants.vbTab + "Example: #mapper notes - displays all notes", true);
                            EchoText(Constants.vbTab + "Example: #mapper note hunting room - adds note \"hunting room\" to current room.", true);
                            EchoText("", true);

                            EchoText("#path - Used to determine the path to another room without initiating travel.", true);
                            EchoText(Constants.vbTab + "Example: #path 1 ", true);
                            EchoText(Constants.vbTab + "Will also set the 'mapperpath' global variable.", true);
                            EchoText("", true);

                            EchoText("#record - Toggles map 'recording' mode where new rooms are added as you move.", true);
                            EchoText(Constants.vbTab + "Example: #mapper record true", true);
                            EchoText(Constants.vbTab + "Example: #mapper record false", true);
                            EchoText("", true);

                            EchoText("#reset - Reloads all maps from disk and attempts to located the player.", true);
                            EchoText(Constants.vbTab + "Example: #mapper reset", true);
                            EchoText("", true);

                            EchoText("#roomid - Sets the current roomid", true);
                            EchoText(Constants.vbTab + "Example: #mapper roomid 1 ", true);
                            EchoText("", true);

                            EchoText("#save - Saves the current map to disk.", true);
                            EchoText(Constants.vbTab + "Example: #mapper save - uses current file name", true);
                            EchoText(Constants.vbTab + "Example: #mapper save the_crossing - saves to /Maps/the_crossing.xml", true);
                            EchoText(Constants.vbTab + "Example: #mapper save /Mazes/the_maze.xml - saves to /Mazes/the_maze.xml", true);
                            EchoText("", true);

                            EchoText("#select - Highlights & selects the specified roomid on the map.", true);
                            EchoText(Constants.vbTab + "Example: #mapper select 1", true);
                            EchoText("", true);

                            EchoText("#show - Shows the automapper window.", true);
                            EchoText(Constants.vbTab + "Example: #mapper show", true);
                            EchoText(Constants.vbTab + "See also: #hide", true);
                            EchoText("", true);

                            EchoText("#snap - Toggles mapper snap-to-grid feature when dragging rooms.", true);
                            EchoText(Constants.vbTab + "Example: #mapper snap true", true);
                            EchoText(Constants.vbTab + "Example: #mapper snap false", true);
                            EchoText("", true);

                            EchoText("#timeout - Configures automapper timeout in ms.", true);
                            EchoText(Constants.vbTab + "Example: #mapper timeout 1500 (default)", true);
                            EchoText("", true);
                            break;
                        }
                    default:
                        {
                            EchoText("[" + Name + "] Unknown option \"" + switchExpr + "\".", true);
                            break;
                        }
                }
            }
            else
            {
                Show(form);
            }
        }

        private void GetNodePath(Node n)
        {
            m_Form.SetDestinationNode(n);
            if (!Information.IsNothing(m_LastNode))
            {
                m_Nodes.FindShortestPath(m_LastNode, n);
                m_Form.UpdateMap();
                if (m_Nodes.PathText.Length > 0)
                {
                    EchoText("[" + Name + "] mapperpath: " + m_Nodes.PathVariableText, true);
                    SendText("#parse [" + Name + "] mapperpath: " + m_Nodes.PathVariableText);
                    set_GlobalVariable("mapperpath", m_Nodes.PathVariableText);
                }
            }
        }

        private void WalkToNode(Node n)
        {
            m_Form.SetDestinationNode(n);
            if (!Information.IsNothing(m_LastNode))
            {
                m_Nodes.FindShortestPath(m_LastNode, n);
                m_Form.UpdateMap();
                if (m_Nodes.PathText.Length > 0)
                {
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Mapper path: " + m_Nodes.PathText);
                    SendText(".automapper " + m_Nodes.PathText);
                }
            }
        }

        private bool StringToBoolean(string sData)
        {
            var switchExpr = sData.ToLower();
            switch (switchExpr)
            {
                case "true":
                case "on":
                case "1":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        private Direction m_eLastMovement = Direction.North;

        private Direction DirectionFromName(string name)
        {
            if (name.StartsWith("go "))
            {
                return Direction.Go;
            }
            else if (name.StartsWith("climb "))
            {
                return Direction.Climb;
                // ElseIf name.StartsWith("peer ") Then
                // name = name.Substring(5)
            }

            switch (name)
            {
                case "north":
                case "n":
                    {
                        return Direction.North;
                    }

                case "northeast":
                case "ne":
                    {
                        return Direction.NorthEast;
                    }

                case "east":
                case "e":
                    {
                        return Direction.East;
                    }

                case "southeast":
                case "se":
                    {
                        return Direction.SouthEast;
                    }

                case "south":
                case "s":
                    {
                        return Direction.South;
                    }

                case "southwest":
                case "sw":
                    {
                        return Direction.SouthWest;
                    }

                case "west":
                case "w":
                    {
                        return Direction.West;
                    }

                case "northwest":
                case "nw":
                    {
                        return Direction.NorthWest;
                    }

                case "up":
                case "u":
                    {
                        return Direction.Up;
                    }

                case "down":
                case "d":
                    {
                        return Direction.Down;
                    }

                case "out":
                case "o":
                    {
                        return Direction.Out;
                    }
            }

            return Direction.None;
        }

        private bool SetArc(Node node, Direction dir)
        {
            m_eLastMovement = dir;
            if (m_LastNode.Arcs.Contains(dir))
            {
                if (Information.IsNothing(m_LastNode.Arcs[dir].Destination))
                {
                    m_LastNode.Arcs[dir].SetDestination(node);
                    return true;
                }
            }

            return false;
        }

        private DateTime m_LastInputTime = DateTime.Now;

        public string ParseInput(string Text)
        {
            if (Text.Length < 50 && Text.Contains(Constants.vbCr) == false)
            {
                var argoDateEnd = DateTime.Now;
                if (m_Movement.Count > 0 & Utility.GetTimeDiffInMilliseconds(m_LastInputTime, argoDateEnd) > m_TimeOutMS)
                {
                    m_Movement.Clear();
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Clearing move queue (timeout).");
                }

                m_LastInputTime = DateTime.Now;

                // Remove drag text
                if (Text.ToLower().StartsWith("drag "))
                {
                    Text = Text.Substring(4).Trim();
                    int I = Text.IndexOf(' ');
                    if (I > -1)
                    {
                        Text = Text.Substring(I).Trim();
                    }
                }

                if (Text.ToLower().StartsWith("go ") | Text.ToLower().StartsWith("climb "))
                {
                    m_Movement.Add(Text);
                    if (m_DebugEnabled == true)
                        EchoText("[" + Name + "] Adding movement: " + Text);
                }
                else
                {
                    var switchExpr = Text.ToLower();
                    switch (switchExpr)
                    {
                        case "north":
                        case "northeast":
                        case "east":
                        case "southeast":
                        case "south":
                        case "southwest":
                        case "west":
                        case "northwest":
                        case "up":
                        case "down":
                        case "out":
                        case "n":
                        case "ne":
                        case "e":
                        case "se":
                        case "s":
                        case "sw":
                        case "w":
                        case "nw":
                        case "u":
                        case "d":
                        case "o":
                            {
                                m_Movement.Add(Text);
                                if (m_DebugEnabled == true)
                                    EchoText("[" + Name + "] Adding movement: " + Text);
                                break;
                            }
                    }

                    // So bumping in "intended direction" works...
                    var switchExpr1 = Text.ToLower();
                    switch (switchExpr1)
                    {
                        case "north":
                        case "n":
                            {
                                m_eLastMovement = Direction.North;
                                break;
                            }

                        case "northeast":
                        case "ne":
                            {
                                m_eLastMovement = Direction.NorthEast;
                                break;
                            }

                        case "east":
                        case "e":
                            {
                                m_eLastMovement = Direction.East;
                                break;
                            }

                        case "southeast":
                        case "se":
                            {
                                m_eLastMovement = Direction.SouthEast;
                                break;
                            }

                        case "south":
                        case "s":
                            {
                                m_eLastMovement = Direction.South;
                                break;
                            }

                        case "southwest":
                        case "sw":
                            {
                                m_eLastMovement = Direction.SouthWest;
                                break;
                            }

                        case "west":
                        case "w":
                            {
                                m_eLastMovement = Direction.West;
                                break;
                            }

                        case "northwest":
                        case "nw":
                            {
                                m_eLastMovement = Direction.NorthWest;
                                break;
                            }

                        case "up":
                        case "u":
                            {
                                m_eLastMovement = Direction.Up;
                                break;
                            }

                        case "down":
                        case "d":
                            {
                                m_eLastMovement = Direction.Down;
                                break;
                            }

                        case "out":
                        case "o":
                            {
                                m_eLastMovement = Direction.Out;
                                break;
                            }
                    }
                }
            }

            return Text;
        }

        public bool IsExitSet(string name)
        {
            string sExits = get_GlobalVariable("roomexits");
            if (sExits.Length > 0)
            {
                var oRegEx = new Regex(@"\b" + name + @"\b");
                if (oRegEx.Match(sExits).Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                string sResult = get_GlobalVariable(name);
                if (sResult.Length == 0)
                    return false;
                if ((sResult ?? "") == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void GraphForm_ListReset()
        {
            m_LastNode = null;
        }

        private void GrapForm_ClickNode(string zoneid, int nodeid)
        {
            SendText(string.Format("#parse MAPCLICK {0} {1}", zoneid, nodeid));
        }

        private void GraphForm_ZoneIDChange(string zoneid)
        {
            set_GlobalVariable("zoneid", zoneid);
        }

        private void GraphForm_ZoneNameChange(string zonename)
        {
            set_GlobalVariable("zonename", zonename);
        }

        private void GraphForm_ToggleRecord(bool toggle)
        {
            m_Recording = toggle;
            if (toggle == true & m_Nodes.Count > 0)
            {
                m_LastNode = null;
            }
        }

        private bool m_AllowDuplicates = false;

        private void GraphForm_ToggleAllowDuplicates(bool toggle)
        {
            m_AllowDuplicates = toggle;
        }

        private void GraphForm_EchoMapPath()
        {
            if (m_Nodes.PathText.Length > 0)
            {
                EchoText("[" + Name + "] Mapper path: " + m_Nodes.PathText);
            }
        }

        private void GraphForm_MoveMapPath()
        {
            if (m_Nodes.PathText.Length > 0)
            {
                SendText(".automapper " + m_Nodes.PathText);
            }
        }

        public void EchoText(string Text, bool AlwaysEcho = false)
        {
            if (AlwaysEcho == false && (Information.IsNothing(m_Form) || m_Form.Visible == false))
                return;
            EventEchoText?.Invoke(Text + Constants.vbNewLine, Color.Cyan, Color.Transparent);
        }

        public void SendText(string Text)
        {
            EventSendText?.Invoke(Text, "AutoMapper");
        }

        public string get_GlobalVariable(string Var)
        {
            if (!Information.IsNothing(m_oGlobals))
            {
                if (!Information.IsNothing(m_oGlobals.VariableList[Var]))
                {
                    return Conversions.ToString(m_oGlobals.VariableList[Var]);
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public void set_GlobalVariable(string Var, string value)
        {
            if (!Information.IsNothing(m_oGlobals))
            {
                m_oGlobals.VariableList[Var] = value;
                EventVariableChanged?.Invoke("$" + Var);
            }
        }
    }
}