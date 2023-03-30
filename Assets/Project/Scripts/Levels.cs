using UnityEngine;

namespace TestTask_AnApp.Scripts
{
    public class Levels : MonoBehaviour 
    {
        private const int LEVELS_PANELS_DISTANCE = 20;

        [SerializeField] private RectTransform _levelsPanelsParent;
        [SerializeField] private RectTransform[] _levelsPanels;
        [SerializeField] private int _defaultLevelsIndex;

        private int _currentLevelsIndex;

        public System.Action<int> OnChangeCurrentLevelsIndex;

        public int MaxLevelsIndex { get; private set; }
        public int CurrentLevelsIndex 
        { 
            get => _currentLevelsIndex;
            private set
            {
                if (_currentLevelsIndex == value)
                    return;

                _currentLevelsIndex = value;
                OnChangeCurrentLevelsIndex?.Invoke(_currentLevelsIndex);
            } 
        }

        private void Awake()
        {
            MaxLevelsIndex = _levelsPanels.Length - 1;
        }

        private void Start()
        {
            var startPosition = _levelsPanels[0].position;
            for (int i = 0; i < _levelsPanels.Length; i++)
                _levelsPanels[i].position = startPosition + new Vector3(0, i * LEVELS_PANELS_DISTANCE, 0);

            MoveTo(_defaultLevelsIndex);
        }

        public void MoveToNextLevels() =>
            MoveTo(CurrentLevelsIndex + 1);
        public void MoveToPrevLevels() =>
            MoveTo(CurrentLevelsIndex - 1);

        private void MoveTo(int levelsIndex)
        {
            _levelsPanelsParent.position += new Vector3(0, (CurrentLevelsIndex - levelsIndex) * LEVELS_PANELS_DISTANCE, 0);
            CurrentLevelsIndex = levelsIndex;
        }
    }
}
