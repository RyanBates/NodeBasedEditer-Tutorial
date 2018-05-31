using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RyansTools
{
    public class NodeEditorWindow : EditorWindow
    {
        private List<Node> _nodes;

        [MenuItem("Ryan's/Ryan's Window")]
        private static void CreateWindow()
        {
            var window = CreateInstance<NodeEditorWindow>();
            window.Show();
        }

        private void OnEnable()
        {
            var node = new Node(new Rect(100, 100, 200, 200));
            _nodes = new List<Node> {node};
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
                    if (e.button == 1)
                        ProcessContextMenu(e);
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
            var rect = new Rect(e.mousePosition.x, e.mousePosition.y, 200, 200);
            _nodes.Add(new Node(rect));
        }

        private void AddNode(object obj)
        {
            AddNode(obj as Event);
        }
    }
}