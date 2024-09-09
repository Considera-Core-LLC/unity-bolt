using Libraries.Bolt.Configs.Components.Paginator;
using TMPro;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Paginator
{
    public abstract class BasePaginator<TObject> : BaseComponent where TObject : BaseObject
    {
        // Fields
        // Private
        private PaginatorConfig<TObject> _config;
        // Private Serialized
        [SerializeField] private TMP_Text _pageLabel;
        [SerializeField] private GameObject _nextButton;
        [SerializeField] private GameObject _previousButton;
        
        // Methods
        // Base
        public IObject Build(PaginatorConfig<TObject> config)
        {
            _config = config;
            UpdatePaginatedBody();

            return this;
        }

        // Public
        public void NextPage()
        {
            _config.NextPage();
            UpdatePaginatedBody();
        }
        
        public void PreviousPage()
        {
            _config.PreviousPage();
            UpdatePaginatedBody();
        }
        
        // Private
        private void UpdatePaginatedBody()
        {
            var start = _config.CurrentPage * _config.PageSize;
            var end = start + _config.PageSize;
            var index = 0;
            
            _config.Elements.ForEach(row =>
            {
                row.SetActive(index >= start && index < end);
                index++;
            });
            
            _pageLabel.text = $"Page {_config.CurrentPage + 1}/{_config.MaxPage + 1}";
            
            _nextButton.SetActive(_config.CurrentPage < _config.MaxPage && _config.MaxPage > 0);
            _previousButton.SetActive(_config.CurrentPage > 0 && _config.MaxPage > 0);
            _pageLabel.gameObject.SetActive(_config.MaxPage > 0);
        }
    }
}