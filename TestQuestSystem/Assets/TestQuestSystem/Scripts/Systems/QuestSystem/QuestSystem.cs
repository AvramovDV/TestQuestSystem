using System.Collections.Generic;
using System.Linq;

namespace Avramov.QuestSystem
{
    public class QuestSystem : BaseSystem
    {
        private ScreensManager _screensManager;
        private EventController _eventController;
        private QuestsModel _questsModel;
        private SystemsController _systemsController;

        private QuestScreen _screen;
        private List<BaseQuestLogic> _logics;

        public QuestSystem(
            QuestsConfig questsConfig,
            ScreensManager screensManager,
            EventController eventController,
            QuestsModel questsModel,
            SystemsController systemsController)
        {
            _screensManager = screensManager;
            _eventController = eventController;
            _questsModel = questsModel;
            _systemsController = systemsController;
        }

        public override void Activated()
        {
            _questsModel.QuestCompletedEvent += OnQuestCompleted;

            if(_screen == null)
                _screen = _screensManager.ShowScreen<QuestScreen>();

            SetupLogic();
            StartLogic();
        }

        public override void Deactivated()
        {
            _questsModel.QuestCompletedEvent -= OnQuestCompleted;
            StopLogic();
            DisposeLogic();
            DisposeScreen();
        }

        private void SetupLogic()
        {
            _logics = _questsModel.Quests.Select(x => x.GetLogic(_eventController, _screen.GetQuestView(x))).ToList();
        }

        private void StartLogic()
        {
            foreach (var item in _logics)
                item.Start();
        }

        private void StopLogic()
        {
            foreach (var item in _logics)
                item.Stop();
        }

        private void DisposeLogic()
        {
            foreach (var item in _logics)
                item.Dispose();
        }

        private void DisposeScreen()
        {
            _screen.ClearQuests();
            _screensManager.HideScreen(_screen);
            _screen = null;
        }

        private void OnQuestCompleted(QuestModel quest)
        {
            var logic = _logics.Find(x => x.QuestId == quest.Id);
            logic.Stop();

            if(IsAllQuestCompleted())
                _systemsController.Activate<ResultSystem>();
        }

        private bool IsAllQuestCompleted()
        {
            return !_questsModel.Quests.Any(x => !x.IsCompleted);
        }
    }
}

