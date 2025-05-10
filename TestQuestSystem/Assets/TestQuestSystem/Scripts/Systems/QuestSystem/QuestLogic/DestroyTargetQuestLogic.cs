namespace Avramov.QuestSystem
{
    public class DestroyTargetQuestLogic : BaseQuestLogic
    {
        private TargetTypeEnum _targetType;

        public DestroyTargetQuestLogic(TargetTypeEnum targetType, EventController eventController, QuestModel questModel, QuestView questView) : base(eventController, questModel, questView)
        {
            _targetType = targetType;
        }

        public override void Start()
        {
            _eventController.Subscribe<TargetModel>(Constants.Events.DestroyTarget, OnTargetDestroyed);
            UpdateView();
        }

        public override void Stop()
        {
            _eventController.UnSubscribe<TargetModel>(Constants.Events.DestroyTarget, OnTargetDestroyed);
        }

        protected override void UpdateView()
        {
            base.UpdateView();
            _questView.ProgressText.text = _questView.ProgressText.text = $"{_questModel.CurrentValue}/{_questModel.TargetValue}";
        }

        private void OnTargetDestroyed(TargetModel target)
        {
            if (_targetType != TargetTypeEnum.None && target.TargetType != _targetType)
                return;

            _questModel.ChangeCurrentValue(1);
            UpdateView();
        }
    }
}

