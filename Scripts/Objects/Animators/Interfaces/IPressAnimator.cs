using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Animators.Interfaces
{
    public interface IPressAnimator : 
        IAnimator,
        IPointerDownHandler,
        IPointerUpHandler {}
}