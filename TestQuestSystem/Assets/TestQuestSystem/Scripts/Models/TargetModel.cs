namespace Avramov.QuestSystem
{
    public class TargetModel
    {
        public TargetTypeEnum TargetType { get; private set; }

        public TargetModel(TargetTypeEnum targetType)
        {
            TargetType = targetType;
        }
    }
}

