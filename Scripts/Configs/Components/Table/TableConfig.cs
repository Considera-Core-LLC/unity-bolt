using System.Collections.Generic;
using System.Linq;

namespace Libraries.Bolt.Configs.Components.Table
{
    public struct TableConfig
    {
        public readonly List<TableColumnConfig> Columns;
        public readonly TableDataConfig Data;

        public TableConfig(List<TableColumnConfig> cols, int rowCount)
        {
            Columns = cols;
            Data = new TableDataConfig
            {
                Rows = new TableDataRowConfig[rowCount].Select(_ => new TableDataRowConfig(cols.Count)).ToList()
            };
        }
    }
}