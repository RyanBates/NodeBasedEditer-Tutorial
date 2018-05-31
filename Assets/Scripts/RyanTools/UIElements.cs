using UnityEngine;

namespace RyansTools
{
    public abstract class UIElements
    {
        protected Rect _rect;

        public virtual void Draw()
        {
        }

        public virtual void PollEvents(Event e)
        {
        }
    }
}