using System.Collections.Generic;
using Libraries.Bolt.Extensions.UI;
using Libraries.Bolt.Objects.Components.Buttons.Drawer;
using Libraries.Sparky.Configs.Research;
using UnityEngine;
using UnityEngine.Serialization;

namespace Libraries.Bolt.Extensions.Drawers
{
    public class DrawerExtension : BaseExtension
    {
        // Fields
        // Private
        private List<DrawerButton> _buttons;
        protected event TriggerCallback m_onTrigger;
        // Private Serialized
        [SerializeField] protected DrawerButton m_drawerButtonPrefab;
        
        // Properties
        // Public
        public List<DrawerButton> Buttons => _buttons;
        
        // Delegates
        // Public
        public delegate void TriggerCallback(int index);
        
        // Methods
        // Base
        public virtual void Build(TriggerCallback triggerCallback)
        {
            _buttons = new List<DrawerButton>();
            m_onTrigger = triggerCallback;
        }

        protected void Trigger(int index) => 
            m_onTrigger?.Invoke(index);
    }
}