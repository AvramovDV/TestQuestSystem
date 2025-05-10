using UnityEngine;

namespace Avramov.QuestSystem
{
    public class ResultSystem : BaseSystem
    {
        private SystemsController _systemsController;
        private ScreensManager _screensManager;

        private ResultScreen _screen;

        public ResultSystem(SystemsController systemsController, ScreensManager screensManager)
        {
            _systemsController = systemsController;
            _screensManager = screensManager;
        }

        public override void Activated()
        {
            if(_screen == null)
                _screen = _screensManager.ShowScreen<ResultScreen>();

            _screen.OkButton.onClick.AddListener(OnOkClick);
        }

        public override void Deactivated()
        {
            _screen.OkButton.onClick.RemoveListener(OnOkClick);
            _screensManager.HideScreen(_screen);
            _screen = null;
        }

        private void OnOkClick()
        {
            _systemsController.ResetGameSystems();
        }
    }
}

