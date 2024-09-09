using Libraries.Bolt.Objects.Components.List;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Buttons.Icon
{
    public class MoreIconButton : IconButton<bool>
    {
        // make dropdown a base class and a MoreButtonDropdownComponent and then make it so that the icon is OnHover and so is the dropdown
        [SerializeField] private HoverableList _dropdown;
        [SerializeField] private HoverableListTarget _target;
        
        public override void OnStart()
        {
            _dropdown.OnStart();
            _target.OnStart(_dropdown);
        }
    }
}