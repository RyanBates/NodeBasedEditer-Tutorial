using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RyansTools
{
    public abstract class UIElements : MonoBehaviour
    {
        public virtual void Draw() { }
        public virtual void PollEvents(Event e) { }
    }
}