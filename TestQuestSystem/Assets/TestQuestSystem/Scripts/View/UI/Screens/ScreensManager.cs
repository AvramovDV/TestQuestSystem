using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.QuestSystem
{
    public class ScreensManager : MonoBehaviour
    {
        [SerializeField] private List<BaseScreen> _screens;

        private Dictionary<Type, BaseScreen> _screensDict = new Dictionary<Type, BaseScreen>(); 

        public T ShowScreen<T>() where T : BaseScreen
        {
            if (!_screensDict.ContainsKey(typeof(T)))
                _screensDict.Add(typeof(T), InstantiateScreen<T>());

            return (T) _screensDict[typeof(T)];
        }

        public void HideScreen<T>(T screen) where T : BaseScreen
        {
            _screensDict.Remove(typeof(T));
            Destroy(screen.gameObject);
        }

        private T InstantiateScreen<T>() where T : BaseScreen
        {
            return Instantiate(GetScreen<T>(), transform);
        }

        private T GetScreen<T>() where T : BaseScreen
        {
            return (T)_screens.Find(x => x is T);
        }
    }
}