using UnityEngine;

namespace TestTask_AnApp.Scripts
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        
        private int _screenWidth; 
        private int _screenHeight; 

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();

            if (_canvas == null)
                throw new System.NullReferenceException("Canvas not found");
        }

        private void Update()
        {
            if (Screen.width != _screenWidth || Screen.height != _screenHeight)
            {
                ResizeRectTransform();

                _screenWidth = Screen.width;
                _screenHeight = Screen.height;
            }
        }

        private void ResizeRectTransform()
        {
            var safeAreaRect = Screen.safeArea;

            var anchorMin = safeAreaRect.position;
            var anchorMax = safeAreaRect.position + safeAreaRect.size;

            anchorMin.x /= _canvas.pixelRect.width;
            anchorMin.y /= _canvas.pixelRect.height;
            anchorMax.x /= _canvas.pixelRect.width;
            anchorMax.y /= _canvas.pixelRect.height;
 
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }
    }
}
