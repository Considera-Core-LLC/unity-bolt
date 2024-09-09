using Libraries.Bolt.Objects.Animators.Interfaces;
using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Animators
{
    public abstract class PressLibraryAnimator : BaseLibraryAnimator, IPressAnimator
    {
        public void OnPointerDown(PointerEventData eventData) => 
            StartAnimation();

        public void OnPointerUp(PointerEventData eventData) => 
            StopAnimation();
    }
}