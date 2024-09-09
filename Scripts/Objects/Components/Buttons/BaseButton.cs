using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Components.Buttons
{
    public abstract class BaseButton : 
        BaseComponent,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerEnterHandler,
        IPointerExitHandler 
    {
        private bool _activated;
        private bool _hovering;
        private bool _down;

        protected bool Activated => _activated;
        protected bool Hovering => _hovering;
        protected bool Down => _down;
        
        // Methods
        // Base
        public virtual IObject Build(bool active)
        {
            _activated = active;
            
            return this;
        }

        // Public
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            SetButtonActive(true);
            _down = true;
        }

        public virtual void OnPointerUp(PointerEventData eventData) =>
            _down = false;
        
        public virtual void OnPointerEnter(PointerEventData eventData) =>
            _hovering = true;

        public virtual void OnPointerExit(PointerEventData eventData) => 
            _hovering = false;

        public virtual void SetButtonActive(bool active) => 
            _activated = active;
    }
}