using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RyanTools
{
    public class NodeEditorWindow : EditorWindow
    {
        private List<Node> _nodes;

        /// <summary>
        ///     this creates the window out of the tab that was created from this.
        ///     DONT MESS WITH THIS ANYMORE
        /// </summary>
        [MenuItem("Ryan's/Ryan's Window")]
        private static void CreateWindow()
        {
            var window = CreateInstance<NodeEditorWindow>();
            window.Show();
        }

        /// <summary>
        ///     this is just the start function for the camera.
        /// </summary>
        private void OnEnable()
        {
            var node = new Node(new Rect(100, 100, 200, 200));
            _nodes = new List<Node> {node};
        }

        /// <summary>
        ///     this is just update for the camera.
        /// </summary>
        private void OnGUI()
        {
            PollEvents(Event.current);
            _nodes.ForEach(n => n.PollEvents(Event.current));
            _nodes.ForEach(n => n.Draw());

            if (GUILayout.Button(new GUIContent("Open New Window"), EditorStyles.toolbarButton, GUILayout.Width(1400)))
                OpenNewWindow();
            if (GUILayout.Button(new GUIContent("Restart"), EditorStyles.toolbarButton, GUILayout.Width(1400)))
                Restart();
        }

        /// <summary>
        ///     takes care of all the inputs or other events.
        ///     DONT MESS WITH THIS ANYMORE
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
        ///     makes a context menu that gives
        ///     one option to Add Node.
        ///     STILL NEED TO ADD HOW TO REMOVE A SINGLE NODE
        /// </summary>
        /// <param name="e"></param>
        private void ProcessContextMenu(Event e)
        {
            var gm = new GenericMenu();

            gm.AddItem(new GUIContent("Add Node"), false, AddNode, e);
            gm.ShowAsContext();

            gm.AddItem(new GUIContent("Remove All Nodes"), false, RemoveAllNodes, e);
            gm.ShowAsContext();

            for (var i = 0; i <= _nodes.Count; i++)
                if (_nodes[i].NodeRect.Contains(e.mousePosition))
                {
                    gm.AddItem(new GUIContent("REMOVE NODE"), false, RemoveNode, e);
                    gm.ShowAsContext();
                }
        }

        /// <summary>
        ///     this is where you add the nodes to the screen from the mouse position.
        ///     FINISHED
        /// </summary>
        /// <param name="e"></param>
        private void AddNode(Event e)
        {
            var rect = new Rect(e.mousePosition.x, e.mousePosition.y, 200, 200);
            _nodes.Add(new Node(rect));
        }

        /// <summary>
        ///     this allows you to Add the node to the screen by changing it from
        ///     a list item to an object.
        ///     FINISHED
        /// </summary>
        /// <param name="obj"></param>
        private void AddNode(object obj)
        {
            AddNode(obj as Event);
        }

        /// <summary>
        ///     allows you to remove all nodes from the list
        ///     FINISHED
        /// </summary>
        /// <param name="obj"></param>
        private void RemoveAllNodes(object obj)
        {
            _nodes = new List<Node>();
        }

        /// <summary>
        ///     these allow you to remove one node at a time.
        ///     THESE SHOULD BE DONE NEED TO TEST
        /// </summary>
        /// <param name="n"></param>
        private void RemoveNode(Event e)
        {
            for (var i = 0; i <= _nodes.Count; i++)
                if (_nodes[i].NodeRect.Contains(e.mousePosition))
                    _nodes.Remove(_nodes[i]);
        }

        private void RemoveNode(object obj)
        {
            RemoveNode(obj as Event);
        }

        /// <summary>
        ///     this allows you to reset your window to how it looked when you first opened it.
        /// </summary>
        private void Restart()
        {
            OnEnable();
        }

        /// <summary>
        ///     this allows you to open a whole new window to do other stuff.
        /// </summary>
        private void OpenNewWindow()
        {
            CreateWindow();
        }
    }
}