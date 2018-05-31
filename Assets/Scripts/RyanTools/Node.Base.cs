using RyanTools;
using UnityEngine;

namespace RyanTools
{
    public partial class Node : UIElements
    {
        /// <summary>
        /// this is the constructor
        /// </summary>
        /// <param name="rect"></param>
        public Node(Rect rect)
        {
            NodeRect = rect;
        }

        /// <summary>
        /// this is to make the objects.
        /// </summary>
        public override void Draw()
        {
            GUI.Box(NodeRect, "Display This");
        }


        /// <summary>
        /// the events or inputs
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// a function just to take care of an event above
        /// </summary>
        /// <param name="e"></param>
        public void Drag(Event e)
        {
            NodeRect.position += e.delta;
        }
    }
}