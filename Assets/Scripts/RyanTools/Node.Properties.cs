using UnityEngine;
using System;


namespace RyansTools
{

    public partial class Node
    {
        Event e;

        public Rect _nodeRect;
        public Connection _connection;
        public ConnectionPoint _connectionPoint;

        private string _data;

        public bool isSelected, isDraggable;
    }
}