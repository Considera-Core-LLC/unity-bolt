using Libraries.Bolt.Objects.Components;
using Libraries.Bolt.Objects.Components.List;
using UnityEngine.EventSystems;

namespace Libraries.Bolt
{
    public class HoverableListTarget : 
        BaseComponent, 
        IPointerEnterHandler
    {
        private HoverableList _moreDropdown;
        
        public void OnStart(HoverableList moreDropdown) => 
            _moreDropdown = moreDropdown;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_moreDropdown.IsActive()) return;
            _moreDropdown.SetActive(true);
        }
    }
}