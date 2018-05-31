using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;

public enum SingleConnectionPointType { In, Out, Connected }

public class BoxCreatorWindow : UnityEditor.EditorWindow
{
    private List<Rect> boxs = new List<Rect>();

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
        DrawConnectionPoint();
        DrawConnection();
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
    }

    Rect rect = new Rect();
    private Action<BoxCreatorWindow> OnClickConnectionPoint;
    private void DrawConnectionPoint()
    {
        rect.y = box.y + (box.height * 0.5f) - rect.height * 0.5f;

        switch (type)
        {
            case SingleConnectionPointType.In:
                rect.center = box.center;
                break;

            case SingleConnectionPointType.Out:
                rect.center = box.center;
                break;

            case SingleConnectionPointType.Connected:
                OnClickConnectionPoint(this);
                break;
        }

        if (GUI.Button(rect, ""))
        {
            if (OnClickConnectionPoint != null)
                OnClickConnectionPoint(this);
        }
    }

    private Action<BoxCreatorWindow> OnClickRemoveConnection;
    private void DrawConnection()
    {
        Handles.DrawBezier(
        rect.center,
        rect.center,
        rect.center + Vector2.left * 50f,
        rect.center - Vector2.left * 50f,
        Color.black,
        null,
        2f);

        if (Handles.Button((rect.center + box.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleCap))
        {
            if (OnClickRemoveConnection != null)
                OnClickRemoveConnection(this);
        }
    }

    private bool isSelected = false;
    private bool isDragged = false;
    private void ProcessEvent(Event e)
    {
        ///selecting the box
        if (e.button == 0 && box.Contains(e.mousePosition))
        {
            isSelected = true;
            isDragged = true;
        }

        else
        {
            isSelected = false;
            isDragged = false;
        }

        ///allowing the user to let go
        if (e.button == 0)
            isDragged = false;

        ///dragging the box
        if (e.button == 0 && isDragged == true)
        {
            box.position += e.delta;
        }
    }
}