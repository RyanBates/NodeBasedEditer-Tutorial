using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;

namespace RyansTools
{
    public class NodeEditorWindow : UnityEditor.EditorWindow
    {
        private Node node;
        private ConnectionPoint connectionPoint;
        private Connection connection;


        private List<Node> nodes;
        private List<Connection> connections;

        [MenuItem("Ryan's/Ryan's Window")]
        private static void CreateWindow()
        {
            var window = UnityEngine.ScriptableObject.CreateInstance<NodeEditorWindow>();
            window.Show();
        }

        private void OnGUI()
        {
            DrawNode();
            DrawConnectionPoint();
            DrawConnection();

            node.PollEvents(Event.current);
        }

        private void AddNodes(Vector2 mousePosition)
        {
            if (nodes == null)
                nodes = new List<Node>();

            nodes.Add(new Node(mousePosition, 200, 50));
        }

        private void ProcessContextMenu(Vector2 mousePosition)
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Add node"), false, () => AddNodes(mousePosition));
            genericMenu.ShowAsContext();
        }

        private void DrawNode()
        {
            if(nodes != null)
            {
                for(int i = 0; i <= nodes.Count; i++)
                {
                    nodes[i].Draw();
                }
            }
        }

        private void DrawConnectionPoint()
        {

        }

        private void DrawConnection()
        {

        }


    }
}