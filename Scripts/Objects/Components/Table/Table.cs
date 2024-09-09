using System.Collections.Generic;
using System.Linq;
using Libraries.Bolt.Configs.Components.Paginator;
using Libraries.Bolt.Configs.Components.Table;
using Libraries.Bolt.Objects.Components.Paginator;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Table
{
    public class Table : BaseComponent, ITable
    {
        // Constants
        private const int COLUMN_GAP = 2;
        private const int ROW_HEIGHT = 30;
        private const int PAGE_SIZE = 5;
        
        private TableConfig _config;
        [SerializeField] private TableHeader _header;
        [SerializeField] private TableBody _body;
        [SerializeField] private TablePaginator _paginator;
        
        [SerializeField] private TableRow _rowPrefab;
        [SerializeField] private TableCell _cellPrefab;
        [SerializeField] private RectTransform _cellGapPrefab;
        private float _headerWidth => Header.Rect.sizeDelta.x;

        public TableConfig Config => _config;
        public TableHeader Header => _header;
        public TableBody Body => _body;
        public TablePaginator Paginator => _paginator;
        
        public ITable Build(TableConfig config) 
        {
            _config = config;
            Canvas.ForceUpdateCanvases();
            Header.Build(BuildHeader());
            Body.Build(BuildBody());
            Paginator.Build(new PaginatorConfig<TableRow>(PAGE_SIZE, Body.Rows));
            
            return this; 
        }

        public void UpdateBody(int col, int row, string value) => 
            Body.UpdateBody(col, row, value);

        public void UpdateBody(int col, int row, RectTransform actionButton) => 
            Body.UpdateBody(col, row, actionButton);
        
        public TableRow BuildHeader()
        {
            var index = 0;
            var row = Instantiate(_rowPrefab, Header.Rect);
            var cells = new List<TableCell>();
            
            Config.Columns.ForEach(col => 
            {
                cells.Add(BuildHeaderCell(col, row));
                
                if (index < Config.Columns.Count - 1)
                    Instantiate(_cellGapPrefab, row.Rect).sizeDelta = new Vector2(COLUMN_GAP, ROW_HEIGHT);

                index++;
            });
            
            return row.Build(cells);
        }

        public List<TableRow> BuildBody() =>
            Config.Data.Rows
                .Where(x => x.Cells.Count == Config.Columns.Count)
                .Select(_ =>
                {
                    var index = 0;
                    var row = Instantiate(_rowPrefab, Body.Rect);
                    var cells = Config.Columns
                        .Select(col =>
                        {
                            var cell = BuildBodyCell(col, row);

                            if (index < Config.Columns.Count - 1) 
                                cell.ApplyRightPadding(COLUMN_GAP);
                            index++;
                            
                            return cell;
                        })
                        .ToList();
                    
                    return row.Build(cells, ROW_HEIGHT);
                    
                })
                .ToList();

        public TableCell BuildHeaderCell(TableColumnConfig col, TableRow row) =>
            BuildCell(col, row, col.Name);

        public TableCell BuildBodyCell(TableColumnConfig col, TableRow row)
        {
            var cell = BuildCell(col, row);
            cell.Rect.sizeDelta = new Vector2(cell.Rect.sizeDelta.x + COLUMN_GAP, cell.Rect.sizeDelta.y);
            return cell;
        }

        public TableCell BuildCell(TableColumnConfig col, TableRow row, string label = "") =>
            Instantiate(_cellPrefab, row.Rect)
                .Build(
                    width: _headerWidth * col.WidthFactor - COLUMN_GAP, 
                    height: ROW_HEIGHT, 
                    label: label);
    }
}
