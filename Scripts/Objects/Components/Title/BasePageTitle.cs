using TMPro;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Title
{
    public abstract class BasePageTitle : BaseComponent
    {
        [SerializeField] private TMP_Text _titleText;
        
        public virtual IObject Build(string title)
        {
            _titleText.text = title;
            
            return this;
        }
    }
}