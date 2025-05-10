namespace Avramov.QuestSystem
{
    public static class SystemsControllerExtentions
    {
        public static void SetupGameSystems(this SystemsController systemsController)
        {
            systemsController.Dectivate<BootSystem>();

            systemsController.Activate<TargetsSystem>();
            systemsController.Activate<QuestSystem>();
        }

        public static void ResetGameSystems(this SystemsController systemsController)
        {
            systemsController.Dectivate<TargetsSystem>();
            systemsController.Dectivate<QuestSystem>();
            systemsController.Dectivate<ResultSystem>();

            systemsController.Activate<BootSystem>();
        }
    }
}

