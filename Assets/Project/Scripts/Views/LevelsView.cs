using UnityEngine;
using UnityEngine.UI;
using TestTask_AnApp.Scripts.Abstractions;

namespace TestTask_AnApp.Scripts.Views
{
    public class LevelsView : ViewBase 
    {
        private const int LEVELS_PANELS_DISTANCE = 10;

        [SerializeField] [Range(0f, 2f)] private float _animationTime;
        [SerializeField] [Range(0f, 3f)] private float _switchLevelsAnimationTime;
        [Space]
        [SerializeField] private RectTransform _nextLevelsButtonTransform;
        [SerializeField] private RectTransform _prevLevelsButtonTransform;
        [Space]
        [SerializeField] private Transform _levelsPanelsParent;
        [SerializeField] private RectTransform[] _levelsPanelTransforms;
        [Space]
        [SerializeField] private int _defaultLevelsIndex;

        private Button[] _buttons;

        private int _maxLevelsIndex;
        private int _currentLevelsIndex;
        private CanvasGroup _levelsView;

        private void Awake()
        {
            _maxLevelsIndex = _levelsPanelTransforms.Length - 1;
            _levelsView = this.GetComponent<CanvasGroup>();

            _buttons = GetComponentsInChildren<Button>();
        }

        private void Start()
        {
            var startPosition = _levelsPanelTransforms[0].position;
            for (int i = 0; i < _levelsPanelTransforms.Length; i++)
                _levelsPanelTransforms[i].position = startPosition + new Vector3(0, i * LEVELS_PANELS_DISTANCE, 0);

            _levelsPanelsParent.position += new Vector3(0, _defaultLevelsIndex * LEVELS_PANELS_DISTANCE, 0);
            _currentLevelsIndex = _defaultLevelsIndex;
            SetNextButtonShow(_currentLevelsIndex != _maxLevelsIndex);
            SetPrevButtonShow(_currentLevelsIndex != 0);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            
            _levelsView.alpha = 0;
            _levelsView.LeanAlpha(1, _animationTime);
        }
        public override void Hide()
        {
            _levelsView
                .LeanAlpha(0, _animationTime)
                .setOnComplete(() => gameObject.SetActive(false));
        }

        private void SetNextButtonShow(bool isShown) =>
            _nextLevelsButtonTransform.gameObject.SetActive(isShown);
        private void SetPrevButtonShow(bool isShown) =>
            _prevLevelsButtonTransform.gameObject.SetActive(isShown);

        private void SetButtonsActive(bool isActived)
        {
            foreach (var button in _buttons)
                button.enabled = isActived;
        }

        public void MoveToNextLevels() =>
            MoveTo(_currentLevelsIndex + 1);
        public void MoveToPrevLevels() =>
            MoveTo(_currentLevelsIndex - 1);

        private void MoveTo(int levelsIndex)
        {
            SetButtonsActive(false);

            var position = new Vector3(0, (_currentLevelsIndex - levelsIndex) * LEVELS_PANELS_DISTANCE, 0) + _levelsPanelsParent.position;
            _levelsPanelsParent
                .LeanMove(position, _switchLevelsAnimationTime)
                .setEaseInOutQuint()
                .setOnComplete(() => SetButtonsActive(true));
            _currentLevelsIndex = levelsIndex;

            SetNextButtonShow(_currentLevelsIndex != _maxLevelsIndex);
            SetPrevButtonShow(_currentLevelsIndex != 0);
        }
    }
}
