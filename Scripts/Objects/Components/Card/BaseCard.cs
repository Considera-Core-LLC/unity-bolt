using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Components.Card
{
    public abstract class BaseCard : 
        BaseComponent,
        IPointerDownHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        protected bool isActive { get; private set; }
        protected bool isHovered { get; private set; }

        public abstract void OnPointerDown(PointerEventData eventData);

        public virtual void OnPointerEnter(PointerEventData eventData) =>
            isHovered = true;

        public virtual void OnPointerExit(PointerEventData eventData) => 
            isHovered = false;

        protected virtual void SetButtonActive(bool active) => 
            isActive = active;
    }
}