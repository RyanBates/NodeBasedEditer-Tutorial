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
        [MenuItem("Ryan's/WindowTool")]
        private static void CreateWindow()
        {
            var window = UnityEngine.ScriptableObject.CreateInstance<NodeBasedEditor>();
            window.Show();
        }

        private void OnGUI()
        {

        }
    }
}