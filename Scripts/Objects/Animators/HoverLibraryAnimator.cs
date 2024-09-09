using Libraries.Bolt.Objects.Animators.Interfaces;
using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Animators
{
    public abstract class HoverLibraryAnimator : BaseLibraryAnimator, IHoverAnimator
    {
        public void OnPointerEnter(PointerEventData eventData) => 
            StartAnimation();

        public void OnPointerExit(PointerEventData eventData) => 
            StopAnimation();
    }
}