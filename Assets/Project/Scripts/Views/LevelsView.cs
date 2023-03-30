using UnityEngine;
using TestTask_AnApp.Scripts.Abstractions;

namespace TestTask_AnApp.Scripts.Views
{
    public class LevelsView : ViewBase 
    {
        [SerializeField] private Levels _levels;
        [Space]
        [SerializeField] private GameObject _nextLevelsButton;
        [SerializeField] private GameObject _prevLevelsButton;

        private void OnEnable()
        {
            _levels.OnChangeCurrentLevelsIndex += CurrentLevelsIndexChanged;
        }
        private void OnDiable()
        {
            _levels.OnChangeCurrentLevelsIndex -= CurrentLevelsIndexChanged;

        }

        private void Start()
        {
            CurrentLevelsIndexChanged(_levels.CurrentLevelsIndex);
        }

        private void CurrentLevelsIndexChanged(int index)
        {
            SetNextButtonShow(_levels.CurrentLevelsIndex != _levels.MaxLevelsIndex);
            SetPrevButtonShow(_levels.CurrentLevelsIndex != 0);
        }

        private void SetNextButtonShow(bool isShown) =>
            _nextLevelsButton.SetActive(isShown);
        private void SetPrevButtonShow(bool isShown) =>
            _prevLevelsButton.SetActive(isShown);
    }
}
