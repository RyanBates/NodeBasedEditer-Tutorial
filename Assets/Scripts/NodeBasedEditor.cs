/// anything commented out is something ive tried.

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class NodeBasedEditor : EditorWindow
{
    private string textBox;

    private List<Node> nodes;
    private List<Connection> connections;

    private GUIStyle nodeStyle;
    private GUIStyle selectedNodeStyle;
    private GUIStyle inPointStyle;
    private GUIStyle outPointStyle;

    private ConnectionPoint selectedInPoint;
    private ConnectionPoint selectedOutPoint;

    private Vector2 offset;
    private Vector2 drag;

    [MenuItem("Ryan's/Node Based Editor")]
    private static void OpenWindow()
    {
        NodeBasedEditor window = GetWindow<NodeBasedEditor>();
        window.titleContent = new GUIContent("Name Display");
    }

    private void OnEnable()
    {
        nodeStyle = new GUIStyle();
        nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
        nodeStyle.border = new RectOffset(12, 12, 12, 12);

        selectedNodeStyle = new GUIStyle();
        selectedNodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1 on.png") as Texture2D;
        selectedNodeStyle.border = new RectOffset(12, 12, 12, 12);

        inPointStyle = new GUIStyle();
        inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
        inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
        inPointStyle.border = new RectOffset(4, 4, 12, 12);

        outPointStyle = new GUIStyle();
        outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
        outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
        outPointStyle.border = new RectOffset(4, 4, 12, 12);
    }

    private void OnGUI()
    {
        DrawGrid(20, 0.2f, Color.gray);
        DrawGrid(100, 0.4f, Color.gray);

        DrawNodes();
        DrawConnections();
        
        DrawConnectionLine(Event.current);

        ProcessNodeEvents(Event.current);
        ProcessEvents(Event.current);

        if (GUI.changed) Repaint();

        if (GUILayout.Button(new GUIContent("Save"), EditorStyles.toolbarButton, GUILayout.Width(35)))
            Save();
        if (GUILayout.Button(new GUIContent("Load"), EditorStyles.toolbarButton, GUILayout.Width(35)))
            Load();
    }

    private void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
    {
        int widthDivs = Mathf.CeilToInt(position.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

        Handles.BeginGUI();
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        offset += drag * 0.5f;

        Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);

        for (int i = 0; i < widthDivs; i++)
            Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
        

        for (int j = 0; j < heightDivs; j++)
            Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(position.width, gridSpacing * j, 0f) + newOffset);
        

        Handles.color = Color.white;
        Handles.EndGUI();
    }

    private void DrawNodes()
    {
        if (nodes != null)
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Draw();

                //if(nodes.Count >= characters.Count)
                //    characters.Add(character);
                
            }
    }

    //private void DisplayCharacterNames()
    //{
    //    int count = 0;

    //    foreach (Character character in characters)
    //    {
    //        count++;
    //        GUI.TextField(new Rect(10, 10, 200, 100), character.name, characters[count].name);
    //    }
    //}

    private void DrawConnections()
    {
        if (connections != null)
            for (int i = 0; i < connections.Count; i++)
                connections[i].Draw();       
    }

    /// <summary>
    /// have it save the string combining the two nodes seeing if both 
    /// nodes have a connection point on either the in or out point 
    /// </summary>    
    //bool connected = false;
    private void Save()
    {
        var path = Path.Combine(Application.dataPath, "Saves");
        ///this makes it to where the save button cant be hit until there is at least on connection between nodes.
        ///and making them save to one file instead of making a new
        ///file for everytime i hit the save button
        path.Contains(nodes.ToString());
        path.Contains(connections.ToString());
        var filename = "1.json";
        var savepath = Path.Combine(path, filename);

        ///this below creates new nodes and connections when the save button is hit. 
        ///does not actually save to the file.
        //Node node = new Node(new Vector2(position.x, position.y), 10, 10, this.nodeStyle, this.selectedNodeStyle, this.inPointStyle, this.outPointStyle, this.OnClickInPoint, this.OnClickOutPoint, this.OnClickRemoveNode);
        //Connection connection = new Connection(node.inPoint, node.outPoint, this.OnClickRemoveConnection);
        //nodes.Add(node);
        //connections.Add(connection);
        //var nodeSaver = JsonUtility.ToJson(node);
        //var connectionSaver = JsonUtility.ToJson(connections);
        ///end of what creates the nodes and connections
        
        ///tried doing just the connections
        //Node node = new Node(new Vector2(position.x, position.y), 10, 10, this.nodeStyle, this.selectedNodeStyle, this.inPointStyle, this.outPointStyle, this.OnClickInPoint, this.OnClickOutPoint, this.OnClickRemoveNode);
        //Connection connection = new Connection(node.inPoint, node.outPoint, this.OnClickRemoveConnection);
        //if (connection.inPoint == connection.outPoint)
        //    connected = true;
        //if (connected == true)
        //{
        //    connections.Add(connection);
        //    var connectionSaves = JsonUtility.ToJson(connections, true);
        //    File.WriteAllText(savepath, connectionSaves);
        //}

        ///Tried to save what was already in the lists to see if anything would 
        ///be in there. Both the list are empty and I should of known that 
        ///before I tried doing this.
        //var nodeSaver = JsonUtility.ToJson(nodes, true);
        //var connectionSaver = JsonUtility.ToJson(connections, true);

        //File.WriteAllText(savepath, nodeSaver);
        //File.WriteAllText(savepath, connectionSaver);

        ///going to brain storm at work about what I could do to fix this 
        

        ///Questions to think about 
        ///1) should it be from a list of connections?
        ///2) should i even worry about the nodes and only focus on the connections between them?
        ///3) how do?


        File.WriteAllText(savepath, "");
    }

    private void Load()
    {
        var nodeLoader = JsonUtility.FromJson<Node>(Application.dataPath + "Saves/1.json");
        var connectionLoader = JsonUtility.FromJson<Connection>(Application.dataPath + "Saves/1.json");

        File.OpenText(nodeLoader.ToString());
        File.OpenText(connectionLoader.ToString());

        //File.Open(nodeLoader.ToString(), FileMode.Open);
        //File.Open(connectionLoader.ToString(), FileMode.Open);
    }
    

    private void ProcessEvents(Event e)
    {
        drag = Vector2.zero;

        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 0)
                    ClearConnectionSelection();
                

                if (e.button == 1)
                    ProcessContextMenu(e.mousePosition);
                
                break;

            case EventType.MouseDrag:
                if (e.button == 0)
                    OnDrag(e.delta);
                
                break;
        }
    }

    private void ProcessNodeEvents(Event e)
    {
        if (nodes != null)
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                bool guiChanged = nodes[i].ProcessEvents(e);

                if (guiChanged)
                    GUI.changed = true;
            }
        
    }

    private void DrawConnectionLine(Event e)
    {
        if (selectedInPoint != null && selectedOutPoint == null)
        {
            Handles.DrawBezier(
                selectedInPoint.rect.center,
                e.mousePosition,
                selectedInPoint.rect.center + Vector2.left * 50f,
                e.mousePosition - Vector2.left * 50f,
                Color.white,
                null,
                2f
            );

            GUI.changed = true;
        }

        if (selectedOutPoint != null && selectedInPoint == null)
        {
            Handles.DrawBezier(
                selectedOutPoint.rect.center,
                e.mousePosition,
                selectedOutPoint.rect.center - Vector2.left * 50f,
                e.mousePosition + Vector2.left * 50f,
                Color.white,
                null,
                2f
            );

            GUI.changed = true;
        }
    }

    private void ProcessContextMenu(Vector2 mousePosition)
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Add node"), false, () => OnClickAddNode(mousePosition));
        genericMenu.ShowAsContext();
    }

    private void OnDrag(Vector2 delta)
    {
        drag = delta;

        if (nodes != null)
            for (int i = 0; i < nodes.Count; i++)
                nodes[i].Drag(delta);
            
        GUI.changed = true;
    }

    private void OnClickAddNode(Vector2 mousePosition)
    {
        if (nodes == null)
            nodes = new List<Node>();
        
        nodes.Add(new Node(mousePosition, 200, 50, nodeStyle, selectedNodeStyle, inPointStyle, outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode));
    }

    private void OnClickInPoint(ConnectionPoint inPoint)
    {
        selectedInPoint = inPoint;

        if (selectedOutPoint != null)
        {
            if (selectedOutPoint.node != selectedInPoint.node)
            {
                CreateConnection();
                ClearConnectionSelection();
            }
            else
                ClearConnectionSelection();
        }
    }

    private void OnClickOutPoint(ConnectionPoint outPoint)
    {
        selectedOutPoint = outPoint;

        if (selectedInPoint != null)
        {
            if (selectedOutPoint.node != selectedInPoint.node)
            {
                CreateConnection();
                ClearConnectionSelection();
            }
            else
                ClearConnectionSelection();
        }
    }

    private void OnClickRemoveNode(Node node)
    {
        if (connections != null)
        {
            List<Connection> connectionsToRemove = new List<Connection>();

            for (int i = 0; i < connections.Count; i++)
                if (connections[i].inPoint == node.inPoint || connections[i].outPoint == node.outPoint)
                    connectionsToRemove.Add(connections[i]);

            for (int i = 0; i < connectionsToRemove.Count; i++)
                connections.Remove(connectionsToRemove[i]);

            connectionsToRemove = null;
        }

        nodes.Remove(node);
    }

    private void OnClickRemoveConnection(Connection connection)
    {
        connections.Remove(connection);
    }

    private void CreateConnection()
    {
        if (connections == null)
            connections = new List<Connection>();

        connections.Add(new Connection(selectedInPoint, selectedOutPoint, OnClickRemoveConnection));
    }

    private void ClearConnectionSelection()
    {
        selectedInPoint = null;
        selectedOutPoint = null;
    }
}