using Libraries.Bolt.Extensions.Classes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Buttons.Images
{
    public class RaisedImageButton : BaseImageButton
    {
        [SerializeField] private Vector2 _shadowDistance = Vector2.one;
        [SerializeField] private Shadow _shadow;
        
        private Shadow Shadow => _shadow;
        
        public override IObject Build(
            bool active = true,
            Color? outlineColor = null,
            Color? labelColor = null,
            OnTrigger trigger = null) 
        {
            base.Build(active, outlineColor, labelColor, trigger);
            Background.color = BackgroundColor.SetAlpha(OffOpacity);
            Shadow.effectColor = outlineColor ?? Color.white;
            Shadow.effectDistance = _shadowDistance;
            
            return this;
        }

        public override void OnPointerDown(PointerEventData eventData) {
            base.OnPointerDown(eventData);
            Shadow.effectDistance = Vector2.zero; } // temp - i will need to change the position of the background so i need to ensure that background is a child object of the button

        public override void OnPointerUp(PointerEventData eventData) {
            base.OnPointerUp(eventData); 
            Shadow.effectDistance = _shadowDistance; }
    }
}