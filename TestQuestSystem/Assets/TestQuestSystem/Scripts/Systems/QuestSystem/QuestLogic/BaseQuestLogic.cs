namespace Avramov.QuestSystem
{
    public abstract class BaseQuestLogic
    {
        protected EventController _eventController { get; private set; }
        protected QuestModel _questModel { get; private set; }
        protected QuestView _questView { get; private set; }

        public int QuestId => _questModel.Id;

        public BaseQuestLogic(EventController eventController, QuestModel questModel, QuestView questView)
        {
            _eventController = eventController;
            _questModel = questModel;
            _questView = questView;
        }

        public abstract void Start();

        public abstract void Stop();

        public void Dispose()
        {
            Stop();
            _eventController = null;
            _questModel = null;
            _questView = null;
        }

        protected virtual void UpdateView()
        {
            _questView.QUestText.text = _questModel.Description;
            _questView.CheckImage.enabled = _questModel.IsCompleted;
            _questView.FillImage.fillAmount = _questModel.RelativeValue;
        }
    }
}

