using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace RyansTools
{
    public partial class Node : UIElements
    {
        public Node() { }

        public Node(Vector2 position, float width, float height/*, Action<ConnectionPoint> OnClickConnectionPoint, Action<Node> OnClickRemoveNode*/)
        {
            nodeRect = new Rect(position.x, position.y, width, height);
            connectionPoint = new ConnectionPoint(this, ConnectionPointType.In, ConnectionPointType.Out, OnClickConnectionPoint);
            OnRemoveNode = OnClickRemoveNode; 
        }

        public override void Draw()
        {
            nodeRect = new Rect(e.mousePosition.x, e.mousePosition.y, 10,10);

            connectionPoint.Draw();
            GUI.Box(nodeRect, "");
            
            //this is to make the text box on the node
            var contextBox = new Rect(nodeRect.position.x, nodeRect.position.y, nodeRect.width / 2, nodeRect.height / 4);
            contextBox.center = nodeRect.center - new Vector2(0, 25);
            data = EditorGUI.TextField(contextBox, data);

            base.Draw();
        }

        public override void PollEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    {
                        if (e.button == 0 && nodeRect.Contains(e.mousePosition))
                        {
                            isSelected = true;
                            isDraggable = true;
                        }
                    }break;

                case EventType.MouseUp:
                    {
                        if (e.button == 0)
                            isDraggable = false;
                    }break;

                case EventType.MouseDrag:
                    {
                        if (e.button == 0 && isDraggable)
                        {
                            Drag(e.delta);
                            e.Use();
                        }
                    }break;
            }

            base.PollEvents(e);
        }

        public void Drag(Vector2 delta)
        {
            nodeRect.position += delta;
        }
    }
}