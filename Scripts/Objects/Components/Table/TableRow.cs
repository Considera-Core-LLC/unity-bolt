using System.Collections.Generic;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Table
{
    public class TableRow : BaseComponent
    {
        private List<TableCell> _cells;

        public TableRow Build(List<TableCell> cells, float height = 0)
        {
            _cells = cells;
            if (height > 0) 
                Rect.sizeDelta = new Vector2(Rect.sizeDelta.x, height);
            
            return this;
        }
        
        public void UpdateCell(int col, string value) => 
            _cells[col].SetLabel(value);
        
        public void UpdateCell(int col, RectTransform rect) => 
            _cells[col].SetCell(rect);
    }
}