using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RyanTools
{
    public class NodeEditorWindow : EditorWindow
    {
        private List<Node> _nodes;


        /// <summary>
        /// this creates the window out of the tab that was created from this.
        /// </summary>
        [MenuItem("Ryan's/Ryan's Window")]
        private static void CreateWindow()
        {
            var window = CreateInstance<NodeEditorWindow>();
            window.Show();
        }

        /// <summary>
        /// this is just the start function for the camera.
        /// </summary>
        private void OnEnable()
        {
            var node = new Node(new Rect(100, 100, 200, 200));
            _nodes = new List<Node> {node};
        }

        /// <summary>
        /// this is just update for the camera.
        /// </summary>
        private void OnGUI()
        {
            PollEvents(Event.current);
            _nodes.ForEach(n => n.PollEvents(Event.current));
            _nodes.ForEach(n => n.Draw());
        }

        /// <summary>
        /// takes care of all the inputs or other events.
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// makes a context menu that gives
        /// one option to Add Node.
        /// </summary>
        /// <param name="e"></param>
        private void ProcessContextMenu(Event e)
        {
            var gm = new GenericMenu();
            gm.AddItem(new GUIContent("Add Node"), false, AddNode, e);
            gm.ShowAsContext();
            e.Use();
        }

        /// <summary>
        /// this is where you add the nodes to the screen from the mouse position.
        /// </summary>
        /// <param name="e"></param>
        private void AddNode(Event e)
        {
            var rect = new Rect(e.mousePosition.x, e.mousePosition.y, 200, 200);
            _nodes.Add(new Node(rect));
        }

        /// <summary>
        /// this allows you to Add the node to the screen by changing it from
        /// an the list item to an object.
        /// </summary>
        /// <param name="obj"></param>
        private void AddNode(object obj)
        {
            AddNode(obj as Event);
        }

        //TODO : start with removing nodes
    }
}