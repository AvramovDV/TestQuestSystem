using UnityEngine;
using Zenject;

namespace Avramov.QuestSystem
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "Quest/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private QuestsConfig _questsConfig;

        public override void InstallBindings()
        {
            Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
            Container.Bind<QuestsConfig>().FromInstance(_questsConfig).AsSingle();
        }
    }
}
