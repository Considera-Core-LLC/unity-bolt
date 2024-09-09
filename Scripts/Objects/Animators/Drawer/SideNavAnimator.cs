using System;

namespace Libraries.Bolt.Objects.Animators.Drawer
{
    public class SideNavAnimator : HoverLibraryAnimator
    {
        private const float DefaultAnimationSpeed = 4.0f;
        private const float DefaultMinWidth = 100.0f;
        private const float DefaultMaxWidth = 400.0f;

        public void OnStart(OnAnimate callback, float speed = DefaultAnimationSpeed) => 
            base.OnStart(callback, false, speed, DefaultMinWidth, DefaultMaxWidth);

        public float GetLerpedWidth() => Lerp(BaseWidth);

        private static readonly Func<float, float> BaseWidth = t => t switch
        {
            <= 0 => 0,
            >= 1 => 1,
            _ => (float)(1.0 / (1.0 + Math.Pow(Math.E, -20.0 * (t - 0.3))))
        };
    }
}