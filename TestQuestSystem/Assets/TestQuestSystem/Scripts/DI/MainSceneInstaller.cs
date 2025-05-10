using Zenject;

namespace Avramov.QuestSystem
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallModels();
            InstallControllers();
            InstallSceneObjects();
            InstallSystems();
        }

        private void InstallModels()
        {
            Container.Bind<LevelModel>().AsSingle();
            Container.Bind<QuestsModel>().AsSingle();
        }

        private void InstallControllers()
        {
            Container.Bind<SystemsController>().AsSingle();
            Container.Bind<EventController>().AsSingle();
        }

        private void InstallSceneObjects()
        {
            Container.Bind<TargetsManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ScreensManager>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallSystems()
        {
            Container.BindInterfacesAndSelfTo<BootSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TargetsSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<QuestSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResultSystem>().AsSingle();
        }
    }
}

