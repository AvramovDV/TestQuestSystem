using UnityEngine;

namespace Avramov.QuestSystem
{
    [CreateAssetMenu(fileName = "DestroyTargetQuestConfig", menuName = "Quest/QuestConfig/DestroyTargetQuestConfig")]
    public class DestroyTargetQuestConfig : BaseQuestConfig
    {
        [SerializeField] private TargetTypeEnum _targetType;

        public override BaseQuestLogic GetLogic(EventController eventController, QuestModel model, QuestView view)
        {
            return new DestroyTargetQuestLogic(_targetType, eventController, model, view);
        }
    }
}
