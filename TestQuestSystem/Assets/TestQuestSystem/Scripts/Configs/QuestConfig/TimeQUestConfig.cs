using UnityEngine;

namespace Avramov.QuestSystem
{
    [CreateAssetMenu(fileName = "TimeQUestConfig", menuName = "Quest/QuestConfig/TimeQUestConfig")]
    public class TimeQUestConfig : BaseQuestConfig
    {
        public override BaseQuestLogic GetLogic(EventController eventController, QuestModel model, QuestView view)
        {
            return new TimeQuestLogic(eventController, model, view);
        }
    }
}
