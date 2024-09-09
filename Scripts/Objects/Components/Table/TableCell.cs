using TMPro;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Table
{
    public class TableCell : BaseComponent
    {
        // Fields
        // Private 
        private RectTransform _cell;
        // Private Serialized
        [SerializeField] private TMP_Text _label;
        
        // Methods
        // Base Methods
        public TableCell Build(float width, float height, string label = "", RectTransform cell = null)
        {
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            SetLabel(label);
            if (cell != null) 
                SetCell(cell);
            return this;
        }

        // Public
        public void SetLabel(string text) => 
            _label.SetText(text);
        
        public void SetCell(RectTransform cell) => 
            _cell = Instantiate(cell, transform);

        public RectTransform UpdateCell(RectTransform cell)
        {
            _cell = cell;
            return _cell;
        }

        public TableCell ApplyRightPadding(float padding)
        {
            _label.margin = new Vector4(_label.margin.x, _label.margin.y, padding, _label.margin.w);
            return this;
        }
    }
}