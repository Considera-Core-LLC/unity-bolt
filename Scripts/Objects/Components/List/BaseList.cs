using System.Collections.Generic;
using Libraries.Bolt.Objects.Components.Button;
using Libraries.Bolt.Objects.Components.Buttons.Images;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.Events;

namespace Libraries.Bolt.Objects.Components.List
{
    public abstract class BaseList : BaseComponent // replace with BaseListComponent
    {
        [SerializeField] protected List<BaseImageButton> _items;

        public override IObject Build()
        {
            _items.ForEach(x => x.Build(trigger: OnClick));
            
            return this;
        }

        private void OnClick() => 
            gameObject.SetActive(false);
    }
}