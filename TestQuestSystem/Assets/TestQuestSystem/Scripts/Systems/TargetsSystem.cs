namespace Avramov.QuestSystem
{
    public class TargetsSystem : BaseSystem
    {
        private LevelModel _levelModel;
        private TargetsManager _targetsManager;
        private EventController _eventController;

        public TargetsSystem(LevelModel levelModel, TargetsManager targetsManager, EventController eventController)
        {
            _levelModel = levelModel;
            _targetsManager = targetsManager;
            _eventController = eventController;
        }

        public override void Activated()
        {
            _targetsManager.SelectTargetEvent += OnSelectTarget;
        }

        public override void Deactivated()
        {
            _targetsManager.SelectTargetEvent -= OnSelectTarget;
            _targetsManager.ClearTargets();
        }

        private void OnSelectTarget(TargetContainerView target)
        {
            _levelModel.RemoveTarget(target.Target);
            _targetsManager.DestroyTarget(target);
            _eventController.CallEvent(Constants.Events.DestroyTarget, target.Target);
        }
    }
}

