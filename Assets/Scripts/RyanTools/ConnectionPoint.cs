using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;


namespace RyansTools
{
    public enum ConnectionPointType { In, Out, Connected }

    public class ConnectionPoint : UIElements
    {
        public Node node;
        public Rect connectionRect;

        ConnectionPointType type;

        public Action<ConnectionPoint> OnClickConnectionPoint;


        public ConnectionPoint() {  }

        public ConnectionPoint(Node node, ConnectionPointType type, ConnectionPointType type2, Action<ConnectionPoint> OnClickConnectionPoint)
        {
            this.node = node;
            this.type = type;
            type2 = type;
            this.OnClickConnectionPoint = OnClickConnectionPoint;
            connectionRect = new Rect(0, 0, 10, 20);
        }

        public override void Draw()
        {
            switch (type)
            {
                case ConnectionPointType.In:
                    connectionRect.center = new Vector2(node.nodeRect.center.x + node.nodeRect.x, node.nodeRect.center.y);
                    break;

                case ConnectionPointType.Out:
                    connectionRect.center = new Vector2(node.nodeRect.center.x + node.nodeRect.x, node.nodeRect.center.y);
                    break;

                case ConnectionPointType.Connected:
                    OnClickConnectionPoint(this);
                    break;
            }


            base.Draw();
        }

        public override void PollEvents(Event e)
        {



            base.PollEvents(e);
        }
    }
}