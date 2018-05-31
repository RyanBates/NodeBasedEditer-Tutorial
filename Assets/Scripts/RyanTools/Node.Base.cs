using System;
using UnityEditor;
using UnityEngine;

namespace RyansTools
{
    public partial class Node : UIElements
    {
        public override void Draw()
        {
            GUI.Box(_nodeRect, "Display This");
        }

        public override void PollEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0 && _nodeRect.Contains(e.mousePosition))
                    {
                        isSelected = true;
                        isDraggable = true;
                    }
                    break;
                case EventType.MouseUp:
                    if (e.button == 0)
                    {
                        isSelected = false;
                        isDraggable = false;
                    }
                    break;
                case EventType.MouseMove:
                    break;
                case EventType.MouseDrag:
                    if(e.button == 0 && isDraggable)
                        Drag(e);
                    break;
                case EventType.Repaint:
                    break;
            }
            base.PollEvents(e);
        }

        public void Drag(Event e)
        {
            _nodeRect.position += e.delta;
        }
    }
}