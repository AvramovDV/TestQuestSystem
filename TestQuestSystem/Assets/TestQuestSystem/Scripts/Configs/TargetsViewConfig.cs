using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.QuestSystem
{
    [CreateAssetMenu(fileName = "TargetsViewConfig", menuName = "Quest/TargetsViewConfig")]
    public class TargetsViewConfig : ScriptableObject
    {
        [SerializeField] private List<TargetViewSettings> _targets;

        public TargetView GetTarget(TargetTypeEnum type) => _targets.Find(x => x.TargetType == type).Prefab;

        [Serializable]
        public class TargetViewSettings
        {
            [field: SerializeField] public TargetTypeEnum TargetType { get; private set; }
            [field: SerializeField] public TargetView Prefab { get; private set; }
        }
    }
}
