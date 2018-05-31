using System;
using UnityEngine;

namespace RyansTools
{
    public enum ConnectionPointType
    {
        Connection,
        Connected
    }

    public class ConnectionPoint : UIElements
    {
        public Node node;
        public Rect connectionRect;

        private readonly ConnectionPointType type;
        
        public override void Draw()
        {
            GUI.Button(connectionRect, "I connect stuff");
            PollEvents(Event.current);

            base.Draw();
        }

        public override void PollEvents(Event e)
        {

            node = new Node();
            //connectionRect = new Rect();
            connectionRect = new Rect(node._nodeRect.position.x, node._nodeRect.position.y, node._nodeRect.width / 2, node._nodeRect.height / 4);

            switch (type)
            {
                case ConnectionPointType.Connection:
                    break;

                case ConnectionPointType.Connected:
                    break;
            }

            base.PollEvents(e);
        }
    }
}