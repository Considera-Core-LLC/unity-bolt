using Libraries.Bolt.Objects.Components.Chip;
using Libraries.Bolt.Objects.Components.Progress;
using UnityEngine;

namespace Libraries.Bolt.Objects.Components.Title
{
    public abstract class BasePageSkillableTitle : BasePageTitle
    {
        [SerializeField] private ChipComponent _levelChip;
        [SerializeField] private BaseProgress _levelProgress;
        
        protected ChipComponent LevelChip => 
            _levelChip;
        protected BaseProgress LevelProgress =>
            _levelProgress;
        
        public override IObject Build(string title)
        {
            base.Build(title);
            LevelChip.OnStart();
            LevelProgress.OnStart();

            return this;
        }
    }
}