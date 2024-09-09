using System;
using System.Collections.Generic;
using System.Linq;
using Libraries.Bolt.Objects.Components.Button;
using Libraries.Bolt.Objects.Components.Buttons;

namespace Libraries.Bolt.Objects.Components.Drawer
{
    [Serializable]
    public class SideNavDrawer : BaseDrawer
    {
        // Properties
        // Private
        private List<BaseButton> _buttons { get; set; }
        // Public
        public List<BaseButton> Buttons => 
            _buttons = _buttons == null || !_buttons.Any()
                ? GetComponentsInChildren<BaseButton>().ToList()
                : _buttons;

        // Methods
        // Base Methods
        public override void OnStart()
        {
            Buttons.ForEach(x => x.OnStart());
            if (Buttons.Any())
                Buttons.First().Build(true);
        }
        
        // Protected Methods
        protected List<TButton> GetButtons<TButton>() 
            where TButton : BaseButton => 
            Buttons.OfType<TButton>().ToList();
        
        // Public Methods
        public void DeactivateAllButtons() => 
            Buttons.ForEach(x => x.SetButtonActive(false));
    }
}