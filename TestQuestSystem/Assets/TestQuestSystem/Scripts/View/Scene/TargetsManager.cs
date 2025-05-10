using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.QuestSystem
{
    public class TargetsManager : MonoBehaviour
    {
        [SerializeField] private TargetContainerView _targetPrefab;
        [SerializeField] private Transform _spawnContainer;

        private List<TargetContainerView> _targets = new List<TargetContainerView>();

        public event Action<TargetContainerView> SelectTargetEvent;

        public void SpawnTargets(IReadOnlyList<TargetModel> targets)
        {
            ClearTargets();
            foreach (var target in targets)
            {
                Vector3 position = GetRandomPosition();
                var view = Instantiate(_targetPrefab, position, Quaternion.identity, transform);
                view.ShowTarget(target);
                view.ClickEvent += OnTargetClick;
                _targets.Add(view);
            }
        }

        public void ClearTargets()
        {
            if( _targets.Count > 0)
            {
                foreach (var target in _targets)
                {
                    target.ClickEvent -= OnTargetClick;
                    Destroy(target.gameObject);
                }
                _targets.Clear();
            }
        }

        public TargetContainerView GetTarget(TargetModel targetModel) => _targets.Find(x => x.Target == targetModel);

        public void DestroyTarget(TargetContainerView target)
        {
            target.ClickEvent -= OnTargetClick;
            _targets.Remove(target);
            target.CustomDestroy();
        }

        private Vector3 GetRandomPosition()
        {
            float x = UnityEngine.Random.Range(-0.5f, 0.5f);
            float y = 0f;
            float z = UnityEngine.Random.Range(-0.5f, 0.5f);
            Vector3 position = new Vector3(x, y, z);
            return _spawnContainer.TransformPoint(position);
        }

        private void OnTargetClick(TargetContainerView target)  => SelectTargetEvent?.Invoke(target);
    }
}