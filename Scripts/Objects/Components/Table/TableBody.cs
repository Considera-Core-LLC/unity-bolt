using System.Collections.Generic;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Table
{
    public class TableBody : BaseComponent
    {
        // Fields
        // Private 
        // Private Serialized
        private List<TableRow> _rows;
        
        // Properties
        // Public
        public List<TableRow> Rows => _rows;
        
        // Methods
        // Base
        public void Build(List<TableRow> rows)
        {
            _rows?.ForEach(x => Destroy(x.gameObject));
            _rows = rows;
        }

        // Public
        public void UpdateBody(int col, int row, string value) => 
            _rows[row].UpdateCell(col, value);
        
        public void UpdateBody(int col, int row, RectTransform rect) => 
            _rows[row].UpdateCell(col, rect);
    }
}