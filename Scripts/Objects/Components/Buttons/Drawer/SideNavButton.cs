using Libraries.Bolt.Objects.Components.Buttons;
using Libraries.Game.Enums.Types;
using UnityEngine.EventSystems;

namespace Libraries.Bolt.Objects.Components.Button.Drawer
{
// temp for now, this prob wont be base anymore? who knows
// also my button system is getting messy, it needs a good look
    public abstract class SideNavButton : BaseButton
    {
        // Properties
        // Private
        private PageType _pageType { get; set; } // this should be in base nav button...
        // Protected
        
        // Delegates
        // Public
        public delegate void OnClick(PageType pageType);
        public event OnClick OnTrigger;

        public virtual void OnStart(
            bool active, 
            PageType pageType = PageType.Undefined,
            OnClick triggerCallback = null)
        {
            base.Build(active);
            _pageType = pageType;
            OnTrigger = triggerCallback;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            OnTrigger?.Invoke(_pageType);
        }

        public abstract void OnAdjustWidth();
    }
}