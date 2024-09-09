using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Progress
{
    public abstract class BaseProgress : BaseComponent
    {
        private const float Brightness = 1.0f / 2.0f; // range from 0.0f to 1.0f, domain from 1.0f to 4.0f with log curve or exp
        [SerializeField] private double _left;
        [SerializeField] private double _right;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _background;
        [SerializeField] private Image _fill;
        [SerializeField] private Color _fillColor;
        private Color _backgroundColor => new(
            _fillColor.r * Brightness, 
            _fillColor.g * Brightness,
            _fillColor.b * Brightness,
            _fillColor.a);

        public override IObject Build()
        {
            _fill.color = _fillColor;
            _background.color = _backgroundColor;
            
            return this;
        }
        
        public void SetProgress(float progress) => 
            _fill.fillAmount = progress;
        
        public void SetProgress(double left, double right)
        {
            _left = left;
            _right = right;
            _fill.fillAmount = GetProgress();
        }
        
        public void SetLabel(string label) => 
            _label.text = label;

        public float GetProgress() => 
            _left / _right < 0.0001f 
                ? 0 : _left / _right > 1.0001f 
                    ? 1 : (float)(_left / _right);
        
        public float GetProgressPercent() => 
            GetProgress() * 100;
        
        public string GetProgressPercentString(int decimals = 0) => 
            $"{GetProgressPercent().ToString($"F{decimals}")}%";
    }
}