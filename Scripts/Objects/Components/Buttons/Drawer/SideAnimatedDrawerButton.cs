using Libraries.Bolt.Objects.Components.Button.Drawer;
using Libraries.Bolt.Objects.Components.Drawer;
using Libraries.Game.Enums.Types;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Buttons.Drawer
{
    public class SideAnimatedDrawerButton : SideNavButton
    {
        // Constants
        private const float ActiveOpacity = 0.02f;
        private const float HoverOpacity = 0.01f;
        private const float OffOpacity = 0.00f;

        // Fields
        // Private
        private SideNavDrawerAnimated _parent;
        private RectTransform _backgroundRect;
        private Image _background;
        
        // Properties
        // Private
        private float BackgroundWidth => 
            Parent.PaddingWidth;
        
        private SideNavDrawerAnimated Parent => 
            _parent = _parent == null 
                ? GetComponentInParent<SideNavDrawerAnimated>() 
                : _parent;

        private RectTransform BackgroundRect => 
            _backgroundRect = _backgroundRect == null 
                ? GetBackground() 
                : _backgroundRect;
        
        private Image Background => 
            _background = _background == null 
                ? BackgroundRect.GetComponent<Image>() 
                : _background;
        
        // Methods
        // Public
        public override void OnStart(
            bool active, 
            PageType pageType = PageType.Undefined,
            OnClick triggerCallback = null)
        {
            base.OnStart(active, pageType, triggerCallback);
            Background.color = GetBackgroundColor(active ? ActiveOpacity : OffOpacity);
            OnAdjustWidth();
        }
        
        public override bool OnUpdate()
        {
            if (!base.OnUpdate()) return false;
            //print(BackgroundWidth);
            //print(BackgroundRect.sizeDelta.x);
            //print(BackgroundRect.rect.width);
            return true;
        }

        public override void OnAdjustWidth() => 
            BackgroundRect.sizeDelta = new Vector2(BackgroundWidth, BackgroundRect.sizeDelta.y);

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            
            if (Activated) return;
            Background.color = GetBackgroundColor(HoverOpacity);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            // Base
            base.OnPointerExit(eventData);
            
            // Condition Block
            if (Activated) return;
            Background.color = GetBackgroundColor(OffOpacity);
        }

        public override void SetButtonActive(bool active)
        {
            base.SetButtonActive(active);
            
            Background.color = GetBackgroundColor(active 
                ? ActiveOpacity 
                : Hovering 
                    ? HoverOpacity 
                    : OffOpacity);
        }
        
        // Private
        private Color GetBackgroundColor(float alpha) =>
            new(Background.color.r, Background.color.g, Background.color.b, alpha);
        
        private RectTransform GetBackground() => 
            transform
                .Find("Background")?
                .GetComponent<RectTransform>();
    }
}
