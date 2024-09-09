using UnityEngine;

namespace Libraries.Bolt.Objects.Components
{
    public abstract class BaseComponent : BaseObject
    {
        private RectTransform _rect;
        private RectTransform _padding;

        public float PaddingWidth => 
            Padding != null 
                ? Padding.rect.width 
                : 0;

        public float PaddingTopHeight =>
            Padding.anchorMax.y;

        public float PaddingBottomHeight =>
            Padding.anchorMin.y;

        public float Height =>
            Rect != null 
                ? Rect.rect.height 
                : 0;
        
        public RectTransform Rect => 
            _rect = _rect == null ? GetRect() : _rect;
        
        public RectTransform Padding => 
            _padding = _padding == null ? GetPadding() : _padding;
        
        protected virtual RectTransform GetPadding() => 
            transform
                .Find("Padding")?
                .GetComponent<RectTransform>();
        
        private RectTransform GetRect() => 
            GetComponent<RectTransform>();
        
    }
}