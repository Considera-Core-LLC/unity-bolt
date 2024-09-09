using System.Collections.Generic;
using System.Linq;

namespace Libraries.Bolt.Configs.Components.Table
{
    public struct TableDataRowConfig
    {
        public List<string> Cells;
        
        public TableDataRowConfig(int cellCount)
        {
            Cells = new string[cellCount].ToList();
        }
    }
}