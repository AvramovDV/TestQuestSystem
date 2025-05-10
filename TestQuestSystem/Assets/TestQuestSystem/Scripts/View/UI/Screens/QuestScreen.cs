using System.Collections.Generic;
using UnityEngine;

namespace Avramov.QuestSystem
{
    public class QuestScreen : BaseScreen
    {
        [SerializeField] private QuestView _prefab;
        [SerializeField] private Transform _questsContainer;

        private Dictionary<QuestModel, QuestView> _questsDict = new Dictionary<QuestModel, QuestView>();

        public QuestView GetQuestView(QuestModel model)
        {
            if(!_questsDict.ContainsKey(model))
                _questsDict.Add(model, Instantiate(_prefab, _questsContainer));

            return _questsDict[model];
        }

        public void ClearQuests()
        {
            foreach (var item in _questsDict)
            {
                Destroy(item.Value.gameObject);
            }
            _questsDict.Clear();
        }
    }
}