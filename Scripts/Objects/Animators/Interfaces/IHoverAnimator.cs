using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Animators.Interfaces
{
    public interface IHoverAnimator : 
        IAnimator,
        IPointerEnterHandler,
        IPointerExitHandler {}
}