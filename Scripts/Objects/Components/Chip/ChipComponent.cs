using Libraries.Bolt.Configs.Components.Chip;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Libraries.Bolt.Objects.Components.Chip
{
    public class ChipComponent : BaseComponent
    {
        [SerializeField] private TMP_Text _chipText;
        [SerializeField] private Image _chipImage;
        
        public void Build(ChipConfig config)
        {
            SetText(config.Label);
            SetChipColor(config.Color);
        }

        public void SetTextColor(Color color) =>
            _chipText.color = color;
        
        public void SetText(string text) =>
            _chipText.SetText(text);
        
        public void SetChipColor(Color color) =>
            _chipImage.color = color;
    }
}