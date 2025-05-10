using System;
using System.Collections.Generic;

namespace Avramov.QuestSystem
{
    public class LevelModel
    {
        private List<TargetModel> _targets;

        public IReadOnlyList<TargetModel> Targets => _targets;

        public event Action<TargetModel> TargetRemovedEvent;

        public void Init(List<TargetModel> targets)
        {
            if(_targets != null) 
                _targets.Clear();

            _targets = targets;
        }

        public void RemoveTarget(TargetModel target)
        {
            _targets.Remove(target);
            TargetRemovedEvent?.Invoke(target);
        }
    }
}

