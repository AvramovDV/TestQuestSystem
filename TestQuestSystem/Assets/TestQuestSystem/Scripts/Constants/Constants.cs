namespace Avramov.QuestSystem
{
    public static class Constants
    {
        public static EventsValues Events {  get; private set; } = new EventsValues();

        public class EventsValues
        {
            public string Update { get; private set; } = "Update";
            public string DestroyTarget { get; private set; } = "DestroyTarget";
        }
    }
}

