using UnityEngine;

namespace Libraries.Bolt.Configs.Components.Chip
{
    public struct ChipConfig
    {
        public string Label { get; set; }
        public Color Color { get; set; }
        
        public ChipConfig(string label, Color color)
        {
            Label = label;
            Color = color;
        }

        public ChipConfig(Color color) : this()
        {
            Color = color;
        }
    }
}