namespace Avramov.QuestSystem
{
    public abstract class BaseSystem : ISystem
    {
        public bool IsActive { get; private set; } = false;

        public void Activate()
        {
            if (IsActive)
                return;

            IsActive = true;
            Activated();
        }

        public void Deactivate()
        {
            if(!IsActive)
                return;

            IsActive = false;
            Deactivated();
        }

        public abstract void Activated();
        public abstract void Deactivated();
    }
}

