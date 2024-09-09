using Libraries.Bolt.Objects.Animators.Drawer;
using Libraries.Bolt.Objects.Animators.Interfaces;
using Libraries.Bolt.Objects.Components.Button;
using Libraries.Bolt.Objects.Components.Button.Drawer;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Drawer
{
    public class SideNavDrawerAnimated : 
        SideNavDrawer, 
        IAnimatable
    {
        // Constants
        private const float DefaultAnimationSpeed = 4.0f;

        // Fields
        // Private
        private SideNavAnimator _animator;
        
        // Properties
        // Private
        private SideNavAnimator Animator => 
            _animator ??= GetComponent<SideNavAnimator>();

        // Methods
        // Base Methods
        public IObject Build(
            float speed = DefaultAnimationSpeed,
            SideNavButton.OnClick trigger = null)
        {
            Animator.OnStart(OnAnimate, speed);
            GetButtons<SideNavButton>().ForEach(x => 
                x.OnStart(false, triggerCallback: trigger));

            return this;
        }

        public override bool OnUpdate()
        {
            if (!base.OnUpdate()) return false;
            
            OnAnimate();
            Animator.OnUpdate();
            Buttons.ForEach(x => x.OnUpdate());
            
            return true;
        }
        
        // Public Methods
        public void OnAnimate()
        {
            GetButtons<SideNavButton>()
                .ForEach(x => x.OnAdjustWidth());
            DrawerContent.sizeDelta = new Vector2(
                Animator.GetLerpedWidth(), 
                DrawerContent.sizeDelta.y);
        }
    }
}