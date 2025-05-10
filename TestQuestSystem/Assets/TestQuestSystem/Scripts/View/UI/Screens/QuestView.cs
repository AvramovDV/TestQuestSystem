using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Avramov.QuestSystem
{
    public class QuestView : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text QUestText { get; private set; }
        [field: SerializeField] public TMP_Text ProgressText { get; private set; }
        [field: SerializeField] public Image CheckImage { get; private set; }
        [field: SerializeField] public Image FillImage { get; private set; }
    }
}