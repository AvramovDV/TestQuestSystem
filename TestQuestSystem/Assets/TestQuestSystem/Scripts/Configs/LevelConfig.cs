using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Avramov.QuestSystem
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Quest/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<TargetSettings> _targets;

        public List<TargetModel> GetTargets() => _targets.Select(x => new TargetModel(x.TargetType)).ToList();

        [Serializable]
        public class TargetSettings
        {
            [field: SerializeField] public TargetTypeEnum TargetType { get; private set; }
        }
    }
}
