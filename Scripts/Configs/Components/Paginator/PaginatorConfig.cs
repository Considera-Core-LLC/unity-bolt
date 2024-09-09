using System.Collections.Generic;
using UnityEngine;

namespace Libraries.Bolt.Configs.Components.Paginator
{
    public class PaginatorConfig<TObject> where TObject : MonoBehaviour
    {
        // Fields
        // Private
        public int PageSize { get; }
        public int CurrentPage { get; private set; }
        public List<TObject> Elements { get; }
        
        // Properties
        // Public
        public int MaxPage => 
            Mathf.CeilToInt((float)Elements.Count / PageSize) - 1;
        
        // Constructor
        public PaginatorConfig(int pageSize, List<TObject> elements)
        {
            PageSize = pageSize;
            Elements = elements;
            CurrentPage = 0;
        }
        
        // Methods
        // Public
        public void NextPage() => 
            CurrentPage += CurrentPage < MaxPage ? 1 : 0;
        
        public void PreviousPage() =>
            CurrentPage -= CurrentPage > 0 ? 1 : 0;
    }
}
