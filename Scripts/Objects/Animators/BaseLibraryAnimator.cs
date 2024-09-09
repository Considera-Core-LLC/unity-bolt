using System;
using UnityEngine;

namespace Libraries.Bolt.Objects.Animators
{
    public class BaseLibraryAnimator : BaseAnimator
    {
        public bool Animate;
        public bool Animating { get; private set; }
        protected float Timer;
        protected float Speed;
        protected float Min;
        protected float Max;
        
        public delegate void OnAnimate();
        public OnAnimate AnimationCallback { get; set; }
        
        private float AnimateDeltaTime => Time.deltaTime * Speed;
        private float _maxTime => 1.0f / Speed;

        protected float Lerp(Func<float, float> f) => 
            Mathf.Lerp(Min, Max, f(Timer * Speed));

        protected void OnStart(OnAnimate callback, bool start, float speed, float min, float max)
        {
            AnimationCallback = callback;
            Animate = start;
            Speed = speed;
            Min = min;
            Max = max;
        }
        
        public override bool OnUpdate()
        {
            if (!base.OnUpdate()) return false;
            
            if (Animating)
                InvokeAnimate();
            
            switch (Animate)
            {
                case true when Timer < _maxTime:
                    Timer += AnimateDeltaTime;
                    Animating = true;
                    break;
                case true when Timer >= _maxTime:
                    Timer = _maxTime;
                    Animating = false;
                    break;
                case false when Timer > 0:
                    Timer -= AnimateDeltaTime;
                    Animating = true;
                    break;
                case false when Timer <= 0:
                    Timer = 0;
                    Animating = false;
                    break;
                case true when Animating:
                    Animating = false;
                    break;
            }

            return true;
        }

        public void StartAnimation() => 
            Animate = true;

        public void StopAnimation() => 
            Animate = false;

        private void InvokeAnimate() => AnimationCallback?.Invoke();
    }
}