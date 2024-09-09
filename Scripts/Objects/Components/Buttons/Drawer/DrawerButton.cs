using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Buttons.Drawer
{
    public class DrawerButton : BaseButton // needs to inherit imagebutton at some point
    {
        // Constants
        private const float ActiveOpacity = 0.02f;
        private const float HoverOpacity = 0.01f;
        private const float OffOpacity = 0.00f;

        // Fields
        // Private
        private Image _background;
        private TMP_Text _label;

        // Properties
        // Private
        private Image Background => GetComponent(ref _background);
        private TMP_Text Label => GetComponentInChildren(ref _label);
        // Auto
        public int Id { get; private set; }
        
        // Delegates
        // Public
        public delegate void OnClick(int index);
        public event OnClick OnTrigger;
        
        // Methods
        // Base
        public void OnStart(
            bool active, 
            int index,
            OnClick triggerCallback = null) 
        {
            base.Build(active);
            Background.color = GetBackgroundColor(active ? ActiveOpacity : OffOpacity);
            Id = index;
            OnTrigger = triggerCallback;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            OnTrigger?.Invoke(Id);
        }
            
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            
            if (Activated) return;
            Background.color = GetBackgroundColor(HoverOpacity);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            
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
        
        // Public
        public void SetLabel(string label) =>
            Label.SetText(label);
        
        // Private
        private Color GetBackgroundColor(float alpha) =>
            new(Background.color.r, Background.color.g, Background.color.b, alpha);
    }
}
