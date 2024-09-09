using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Buttons.Icon
{
    public abstract class IconButton<T> : BaseButton
    {
        private const float ActiveOpacity = 0.10f;
        private const float HoverOpacity = 0.01f;
        private const float OffOpacity = 0.00f;

        private T _viewType;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _background;
        [SerializeField] private Color _iconColor;
        [SerializeField] private Color _backgroundColor;
        
        public T ViewType => _viewType;
        
        public delegate void OnClick(T type);
        public event OnClick OnTrigger;

        public void Build(
            bool active,
            T viewType,
            OnClick triggerCallback = null) 
        {
            base.Build(active);
            
            _viewType = viewType;
            OnTrigger = triggerCallback;
            
            _background.color = GetBackgroundColor(active ? ActiveOpacity : OffOpacity);
            _icon.color = _iconColor;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            OnTrigger?.Invoke(_viewType);
        }
        
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            
            if (Activated) return;
            _background.color = GetBackgroundColor(HoverOpacity);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            
            if (Activated) return;
            _background.color = GetBackgroundColor(OffOpacity);
        }

        public override void SetButtonActive(bool active)
        {
            base.SetButtonActive(active);
            
            _background.color = GetBackgroundColor(active 
                ? ActiveOpacity 
                : Hovering 
                    ? HoverOpacity 
                    : OffOpacity);
        }
        
        private Color GetBackgroundColor(float alpha) =>
            new(_backgroundColor.r, _backgroundColor.g, _backgroundColor.b, alpha);

    }
}
