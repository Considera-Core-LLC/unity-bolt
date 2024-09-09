using Libraries.Bolt.Extensions;
using Libraries.Bolt.Objects.Components.Title;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Page
{
    public abstract class BaseSkillablePage : BaseComponent
    {
        // Fields
        // Private
        // Private Serialized
        [SerializeField] private BasePageSkillableTitle _title;
        [SerializeField] private protected BaseContent _content;

        // Methods
        // Base Methods
        public IObject Build(string title)
        {
            _title.Build(title);
            _content.Build();

            return this;
        }

        public override void OnStart()
        {
            _title.OnStart();
            _content.OnStart();
        }

        public override bool OnUpdate()
        {
            if (!base.OnUpdate()) return false;
            
            _title.OnUpdate();
            _content.OnUpdate();

            return true;
        }

        public override void OnRun()
        {
            _title.OnRun();
            _content.OnRun();
        }
    }
}