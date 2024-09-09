namespace Libraries.Bolt.Configs.Components.Table
{
    public struct TableColumnConfig
    {
        public string Name;
        public readonly float WidthFactor;
        
        public TableColumnConfig(string name, float widthFactor)
        {
            Name = name;
            WidthFactor = widthFactor;
        }
    }
}