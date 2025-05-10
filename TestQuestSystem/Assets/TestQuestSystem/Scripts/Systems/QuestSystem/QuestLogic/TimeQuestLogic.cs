namespace Avramov.QuestSystem
{
    public class TimeQuestLogic : BaseQuestLogic
    {
        public TimeQuestLogic(EventController eventController, QuestModel questModel, QuestView questView) : base(eventController, questModel, questView)
        {
        }

        public override void Start()
        {
            _eventController.Subscribe<float>(Constants.Events.Update, Update);
            UpdateView();
        }

        public override void Stop()
        {
            _eventController.UnSubscribe<float>(Constants.Events.Update, Update);
        }

        protected override void UpdateView()
        {
            base.UpdateView();
            _questView.ProgressText.text = GetTimeString(_questModel.CurrentValue);
        }

        private void Update(float deltaTime)
        {
            _questModel.ChangeCurrentValue(deltaTime);
            UpdateView();

        }

        private string GetTimeString(float time)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time % 60;
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

