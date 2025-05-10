using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Avramov.QuestSystem
{
    public class TargetContainerView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TargetsViewConfig _targetsConfig;

        private TargetView _view;

        public event Action<TargetContainerView> ClickEvent;

        public TargetModel Target { get; private set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            ClickEvent?.Invoke(this);
        }

        public void ShowTarget(TargetModel targetModel)
        {
            ClearTarget();
            Target = targetModel;
            TargetView prefab = _targetsConfig.GetTarget(targetModel.TargetType);
            _view = Instantiate(prefab, transform);
        }

        public void CustomDestroy()
        {
            ClearTarget();
            Destroy(gameObject);
        }

        private void ClearTarget()
        {
            if(_view != null)
            {
                Destroy(_view);
                _view = null;
            }
        }
    }
}