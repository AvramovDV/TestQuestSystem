using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Avramov.QuestSystem
{
    public class MainSceneMain : MonoBehaviour
    {
        private SystemsController _systemsController;
        private EventController _eventController;

        [Inject]
        private void Construct(SystemsController systemController, EventController eventController, List<ISystem> systems)
        {
            _systemsController = systemController;
            _eventController = eventController;

            _systemsController.Init(systems);
        }

        private void Start()
        {
            _systemsController.Activate<BootSystem>();
        }

        private void Update()
        {
            _eventController.CallEvent(Constants.Events.Update, Time.deltaTime);
        }
    }
}