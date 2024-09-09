using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Components.List
{
    public class HoverableList : 
        BaseList,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => 
            gameObject.SetActive(true);

        public void OnPointerExit(PointerEventData eventData) => 
            gameObject.SetActive(false);
    }
}