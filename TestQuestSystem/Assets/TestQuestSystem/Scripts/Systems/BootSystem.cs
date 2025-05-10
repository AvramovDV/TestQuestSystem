using System.Collections.Generic;
using System.Linq;

namespace Avramov.QuestSystem
{
    public class BootSystem : BaseSystem
    {
        private LevelModel _levelModel;
        private QuestsModel _questsModel;
        private LevelConfig _levelConfig;
        private TargetsManager _targetsManager;
        private SystemsController _systemsController;
        private QuestsConfig _questsConfig;

        public BootSystem(
            LevelModel levelModel,
            QuestsModel questsModel,
            LevelConfig levelConfig,
            TargetsManager targetsManager,
            SystemsController systemsController,
            QuestsConfig questsConfig)
        {
            _levelModel = levelModel;
            _questsModel = questsModel;
            _levelConfig = levelConfig;
            _targetsManager = targetsManager;
            _systemsController = systemsController;
            _questsConfig = questsConfig;
        }

        public override void Activated()
        {
            SetupTargets();
            SetupQuests();

            _systemsController.SetupGameSystems();
        }

        public override void Deactivated()
        {
            
        }

        private void SetupTargets()
        {
            var targets = _levelConfig.GetTargets();
            _levelModel.Init(targets);
            _targetsManager.SpawnTargets(targets);
        }

        private void SetupQuests()
        {
            List<QuestModel> quests = _questsConfig.Quests.Select(x => x.GetModel()).ToList();
            _questsModel.Init(quests);
        }
    }
}

