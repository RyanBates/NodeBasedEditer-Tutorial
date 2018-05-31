using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RyansTools
{
    public class NodeEditorWindow : EditorWindow
    {
        private Node _node;
        private List<Node> _nodes;
        [MenuItem("Ryan's/Ryan's Window")]
        private static void CreateWindow()
        {
            var window = CreateInstance<NodeEditorWindow>();
            window.Show();
        }
        private void OnEnable()
        {
            _node = new Node {_nodeRect = new Rect(100, 100, 200, 200)};
            _nodes = new List<Node> {_node};
        }


        private void OnGUI()
        {
            PollEvents(Event.current);
            _nodes.ForEach(n => n.PollEvents(Event.current));
            _nodes.ForEach(n => n.Draw());
        }


        private void PollEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 1 && !_node._nodeRect.Contains(e.mousePosition))
                    {
                        ProcessContextMenu(e);
                    }
                    break;
            }            
        }

        private void ProcessContextMenu(Event e)
        {
            var gm = new GenericMenu();
            gm.AddItem(new GUIContent("Add Node"), false, AddNode, e);
            gm.ShowAsContext();
            e.Use();
        }

        private void AddNode(Event e)
        {
            _nodes.Add(new Node() {_nodeRect = new Rect(e.mousePosition, new Vector2(_node._nodeRect.width, _node._nodeRect.height))});
        }

        private void AddNode(object obj)
        {
            AddNode(obj as Event);
        }
    }
}