using UnityEngine;

namespace Avramov.QuestSystem
{
    public abstract class BaseQuestConfig : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public float TargetValue { get; private set; }
        [field: SerializeField] public float CurrentValue { get; private set; }

        public QuestModel GetModel()
        {
            QuestData data = new QuestData()
            {
                Id = Id,
                CurrentValue = CurrentValue,
            };

            return GetModel(data);
        }

        public QuestModel GetModel(QuestData data)
        {
            return new QuestModel(data, this);
        }

        public abstract BaseQuestLogic GetLogic(EventController eventController, QuestModel model, QuestView view);
    }
}
