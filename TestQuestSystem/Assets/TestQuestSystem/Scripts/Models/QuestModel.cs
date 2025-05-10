using System;

namespace Avramov.QuestSystem
{
    public class QuestModel
    {
        private QuestData _data;
        private BaseQuestConfig _config;

        public int Id => _data.Id;

        public string Description => _config.Description;
        public float TargetValue => _config.TargetValue;
        public float CurrentValue => _data.CurrentValue;

        public float RelativeValue => CurrentValue / TargetValue;
        public bool IsCompleted => CurrentValue >= TargetValue;

        public event Action<QuestModel> CompleteEvent;

        public QuestModel(QuestData data, BaseQuestConfig config)
        {
            _data = data;
            _config = config;
        }

        public void ChangeCurrentValue(float delta)
        {
            bool isCompleted = IsCompleted;
            _data.CurrentValue += delta;
            if (isCompleted != IsCompleted)
                CompleteEvent?.Invoke(this);
        }

        public BaseQuestLogic GetLogic(EventController controller, QuestView view)
        {
            return _config.GetLogic(controller, this, view);
        }
    }
}

