using System;
using System.Collections.Generic;

namespace Avramov.QuestSystem
{
    public class EventController
    {
        private Dictionary<string, object> _containers = new Dictionary<string, object>();

        public void Subscribe<T>(string name, Action<T> action) => GetContainer<T>(name).Event += action;

        public void UnSubscribe<T>(string name, Action<T> action) => GetContainer<T>(name).Event -= action;

        public void CallEvent<T>(string name, T value) => GetContainer<T>(name).CallEvent(value);

        private Container<T> GetContainer<T>(string name)
        {
            if(!_containers.ContainsKey(name))
                _containers.Add(name, new Container<T>());

            return (Container<T>)_containers[name];
        }

        public class Container<T>
        {
            public event Action<T> Event;

            public void CallEvent(T value) => Event?.Invoke(value);
        }
    }
}

