using System.Collections.Generic;
using Libraries.Bolt.Configs.Components.Table;
using Libraries.Bolt.Objects.Components.Paginator;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Table
{
    public interface ITable
    {
        TableHeader Header { get; }
        TableBody Body { get; }
        TablePaginator Paginator { get; }
        
        ITable Build(
            TableConfig config);
        
        void UpdateBody(
            int col, 
            int row, 
            string value);
        
        void UpdateBody(
            int col, 
            int row, 
            RectTransform actionButton);
        
        TableRow BuildHeader();
        
        List<TableRow> BuildBody();
        
        TableCell BuildHeaderCell(
            TableColumnConfig col, 
            TableRow row);
        
        TableCell BuildBodyCell(
            TableColumnConfig col,
            TableRow row);

        TableCell BuildCell(
            TableColumnConfig col,
            TableRow row,
            string label = "");
    }
}