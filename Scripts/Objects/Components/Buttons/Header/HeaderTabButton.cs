using Libraries.Bolt.Objects.Components.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Button.Header
{
    public class HeaderTabButton : BaseButton
    {
        // Constants
        private const float ActiveOpacity = 1.0f;
        private const float HoverOpacity = 0.1f;
        private const float OffOpacity = 0.00f;

        // Fields
        // Private
        private int _id;
        // Private Serialized
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _bottomBorder;
        [SerializeField] private Color _bottomBorderColor;

        // Properties
        private float BackgroundWidth => PaddingWidth;
        
        // Public
        public int Id => _id;
        
        // Delegates
        // Public
        public delegate void OnClick(int index);
        public event OnClick OnTrigger;

        // Methods
        // Base Methods
        public IObject Build(
            int index,
            bool active, 
            string label = "",
            OnClick triggerCallback = null) 
        {
            _id = index;
            _bottomBorder.color = GetBackgroundColor(active ? ActiveOpacity : OffOpacity);
            _label.SetText(label);
            OnTrigger = triggerCallback;

            return this;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            OnTrigger?.Invoke(_id);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            
            if (Activated) return;
            _bottomBorder.color = GetBackgroundColor(HoverOpacity);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            
            if (Activated) return;
            _bottomBorder.color = GetBackgroundColor(OffOpacity);
        }

        public override void SetButtonActive(bool active)
        {
            base.SetButtonActive(active);
            
            _bottomBorder.color = GetBackgroundColor(active 
                ? ActiveOpacity 
                : Hovering 
                    ? HoverOpacity 
                    : OffOpacity);
        }
        
        // Private Methods
        private Color GetBackgroundColor(float alpha) =>
            new(_bottomBorderColor.r, _bottomBorderColor.g, _bottomBorderColor.b, alpha);

    }
}
