using UnityEngine;

namespace RyansTools
{
    public partial class Node : UIElements
    {
        public Node(Rect rect)
        {
            NodeRect = rect;
        }

        public override void Draw()
        {
            GUI.Box(NodeRect, "Display This");
        }

        public override void PollEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0 && NodeRect.Contains(e.mousePosition))
                    {
                        IsSelected = true;
                        IsDraggable = true;
                    }

                    break;

                case EventType.MouseUp:
                    if (e.button == 0)
                    {
                        IsSelected = false;
                        IsDraggable = false;
                    }

                    break;

                case EventType.MouseDrag:
                    if (e.button == 0 && IsDraggable)
                        Drag(e);
                    break;

                case EventType.KeyDown:
                    break;
                case EventType.KeyUp:
                    break;
            }

            base.PollEvents(e);
        }

        public void Drag(Event e)
        {
            NodeRect.position += e.delta;
        }
    }
}