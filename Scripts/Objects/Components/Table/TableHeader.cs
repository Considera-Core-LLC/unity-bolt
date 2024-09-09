namespace Libraries.Bolt.Objects.Components.Table
{
    public class TableHeader : BaseComponent
    {
        private TableRow _headerRow;
        
        public IObject Build(TableRow row)
        {
            _headerRow = row;
            
            return this;
        }
    }
}