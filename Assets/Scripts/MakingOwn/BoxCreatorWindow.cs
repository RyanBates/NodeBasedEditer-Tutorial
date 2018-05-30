using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;


public enum SingleConnectionPointType { In, Out, Connected }

public class BoxCreatorWindow : UnityEditor.EditorWindow
{
    Rect box = new Rect(100, 100, 200, 100);

    private SingleConnectionPointType type;

    [MenuItem("Ryan's/BoxMaker")]
    private static void MakeWindow()
    {
        var window = ScriptableObject.CreateInstance<BoxCreatorWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        DrawBox();
        ProcessEvent(Event.current);
    }

    private string data;
    private void DrawBox()
    {     
        GUI.Box(box, "");
        ///text box
        var contextBox = new Rect(box.position.x, box.position.y, box.width / 2, box.height / 4);
        contextBox.center = box.center - new Vector2(0, 25);
        data = EditorGUI.TextField(contextBox, data);
        ///connection point
        var connectpoint = new Rect(box.position.x, box.position.y, 1, 1);
        connectpoint.center = box.center;
        
    }


    private bool isSelected = false;
    private bool isDragged = false;
    private void ProcessEvent(Event e)
    {
        ///selecting the box
        if (Input.GetMouseButtonDown(0) && box.Contains(e.mousePosition))
        {
            isSelected = true;
            isDragged = true;
        }

        ///allowing the user to let go
        if (Input.GetMouseButtonUp(0))
            isDragged = false;

        ///dragging the box
        if (Input.GetMouseButtonDown(0) && isDragged == true)
        {
            box.position += Event.current.delta;
        }
    }
}