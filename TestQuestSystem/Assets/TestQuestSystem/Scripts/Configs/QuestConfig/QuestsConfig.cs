using System.Collections.Generic;
using UnityEngine;

namespace Avramov.QuestSystem
{
    [CreateAssetMenu(fileName = "QuestsConfig", menuName = "Quest/QuestsConfig")]
    public class QuestsConfig : ScriptableObject
    {
        [SerializeField] private List<BaseQuestConfig> _quests;

        public IReadOnlyList<BaseQuestConfig> Quests => _quests;
    }
}
