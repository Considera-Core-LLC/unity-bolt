using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Drawer
{
    public abstract class BaseDrawer : BaseComponent
    {
        // Constants
        private const string DrawerContentName = "DrawerContent";
        
        // Fields
        // Private
        private RectTransform _drawerContent;
        // Protected
        protected RectTransform DrawerContent => 
            _drawerContent = _drawerContent == null 
                ? GetDrawerContent() 
                : _drawerContent;
        
        // Methods
        // Protected
        protected override RectTransform GetPadding() => 
            transform
                .Find("DrawerContent")?
                .Find("Padding")?
                .GetComponent<RectTransform>();

        // Private
        private RectTransform GetDrawerContent() => 
            transform
                .Find(DrawerContentName)
                .GetComponent<RectTransform>();
    }
}