using UnityEngine;

namespace TestTask_AnApp.Scripts.Abstractions
{
    [RequireComponent(typeof(RectTransform))]
    public class ViewBase : MonoBehaviour
    {
        public virtual void Show() =>
            gameObject.SetActive(true);
        public virtual void Hide() =>
            gameObject.SetActive(false);
    }
}
