using System;
using System.Collections.Generic;

namespace Avramov.QuestSystem
{
    public class QuestsModel
    {
        private List<QuestModel> _quests;

        public IReadOnlyList<QuestModel> Quests => _quests;

        public event Action<QuestModel> QuestCompletedEvent;

        public void Init(List<QuestModel> quests)
        {
            if (_quests != null)
                Clear();

            _quests = quests;
            Subscribe();
        }

        public void Clear()
        {
            Unsubscribe();
            _quests.Clear();
        }

        private void Subscribe()
        {
            foreach (QuestModel quest in _quests)
                quest.CompleteEvent += CallQuestCompleted;
        }

        private void Unsubscribe()
        {
            foreach (QuestModel quest in _quests)
                quest.CompleteEvent -= CallQuestCompleted;
        }

        private void CallQuestCompleted(QuestModel quest) => QuestCompletedEvent?.Invoke(quest);
    }
}

