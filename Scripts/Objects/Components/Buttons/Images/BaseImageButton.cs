using Libraries.Bolt.Extensions.Classes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Buttons.Images
{
    public abstract class BaseImageButton : BaseButton
    {
        protected const float ActiveOpacity = 0.02f;
        protected const float HoverOpacity = 0.01f;
        protected const float OffOpacity = 0.00f;
        
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Color _labelColor = Color.white;
        [SerializeField] private Image _background;
        [SerializeField] private Color _backgroundColor = Color.white;

        protected TMP_Text Label => _label;
        protected Color LabelColor => _label.color;
        protected Image Background => _background;
        protected Color BackgroundColor => _background.color;

        public delegate void OnTrigger();
        protected event OnTrigger m_trigger;
        
        // todo: add static button handler field that will handle errors. so if this static button handler is null, throw a hard error coz its likely a dev bug
        // if it isnt, itll just send a notification popup instead of crashing the game

        public virtual IObject Build(
            bool active = true,
            Color? backgroundColor = null,
            Color? labelColor = null,
            OnTrigger trigger = null)
        {
            base.Build(active);
            Background.color = backgroundColor ?? _backgroundColor;
            Label.color = labelColor ?? _labelColor;
            m_trigger = trigger;
            return this;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            m_trigger?.Invoke();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (Activated) return;
            Background.color = GetBackgroundColor(HoverOpacity);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (Activated) return;
            Background.color = GetBackgroundColor(OffOpacity);
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
        
        public void SetText(string text) => 
            _label.text = text;
        
        public void SetColor(Color color) =>
            _background.color = color;

        private Color GetBackgroundColor(float alpha) => 
            BackgroundColor.SetAlpha(alpha);
    }
}
