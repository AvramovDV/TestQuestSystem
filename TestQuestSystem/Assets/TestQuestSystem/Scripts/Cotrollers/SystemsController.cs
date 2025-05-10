using System;
using System.Collections.Generic;

namespace Avramov.QuestSystem
{
    public class SystemsController
    {
        private Dictionary<Type, ISystem> _systemsDict = new Dictionary<Type, ISystem>();

        public void Init(List<ISystem> systems)
        {
            foreach (ISystem system in systems)
                _systemsDict.Add(system.GetType(), system);
        }

        public void Activate<T>()
        {
            _systemsDict[typeof(T)].Activate();
        }

        public void Dectivate<T>()
        {
            _systemsDict[typeof(T)].Deactivate();
        }
    }
}

