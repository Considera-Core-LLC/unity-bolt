using Libraries.Bolt.Extensions.Classes;
using Libraries.Bolt.Objects.Components.Buttons.Images;
using UnityEngine;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Buttons
{
    public class OutlinedImageButton : BaseImageButton
    {        
        [SerializeField] private int _outlineSize = 1;
        [SerializeField] private Outline _outline;

        private Outline Outline => _outline;
        
        public override IObject Build(
            bool active,
            Color? outlineColor = null,
            Color? labelColor = null,
            OnTrigger trigger = null) 
        {
            base.Build(active, outlineColor, labelColor, trigger);
            Background.color = BackgroundColor.SetAlpha(OffOpacity);
            Outline.effectColor = outlineColor ?? Color.white;
            Outline.effectDistance = _outlineSize.ToVector2();
            
            return this; 
        }
    }
}