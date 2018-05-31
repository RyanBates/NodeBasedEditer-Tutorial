using UnityEngine;
using System;


namespace RyansTools
{

    public partial class Node
    {
        Event e;

        public Rect nodeRect;
        public Connection connection;
        public ConnectionPoint connectionPoint;

        public string data;

        public bool isSelected;
        public bool isDraggable;

        public Action<Node> OnRemoveNode;
    }
}