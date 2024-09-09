using System;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components
{
    public abstract class AnimatedComponent : BaseComponent
    {
        public bool Animate;
        public float AnimateTimer;
        public float AnimateTimerSpeed;
        
        private float AnimateDeltaTime => Time.deltaTime * AnimateTimerSpeed;

        public override bool OnUpdate()
        {
            if (!base.OnUpdate()) return false;
            
            switch (Animate)
            {
                case true when AnimateTimer < 1.0f / AnimateTimerSpeed:
                    AnimateTimer += AnimateDeltaTime;
                    break;
                case false when AnimateTimer > 0:
                    AnimateTimer -= AnimateDeltaTime;
                    break;
            }

            return true;
        }
        
        protected float Lerp(Func<float, float> baseFunc, float min, float max) => 
            Mathf.Lerp(min, max, baseFunc(AnimateTimer * AnimateTimerSpeed));
    }
}