using Unity.VectorGraphics;
using UnityEngine;
using TestTask_AnApp.Scripts.Abstractions;

namespace TestTask_AnApp.Scripts.Views
{
    public class OptionsView : ViewBase
    {
        [SerializeField] [Range(0f, 1f)] private float _animationTime;
        [Space]
        [SerializeField] private Sprite _soundOnSprite;
        [SerializeField] private Sprite _soundOffSprite;
        [SerializeField] private Sprite _musicOnSprite;
        [SerializeField] private Sprite _musicOffSprite;
        [Space]
        [SerializeField] private SVGImage _soundSpriteHolder;
        [SerializeField] private SVGImage _musicSpriteHolder;
        [Space]
        [SerializeField] private Options _options;
        [Space]
        [SerializeField] private RectTransform _optionsPanel;

        private CanvasGroup _optionsView;

        private void Awake()
        {
            _optionsView = this.GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            SetSoundActive(_options.IsSoundOn);
            SetMusicActive(_options.IsMusicOn);
        }

        public void SwitchSound()
        {
            var value = !_options.IsSoundOn;
            _options.IsSoundOn = value;
            SetSoundActive(value);
        }
        public void SwitchMusic()
        {
            var value = !_options.IsMusicOn;
            _options.IsMusicOn = value;
            SetMusicActive(value);
        }

        public override void Show()
        {
            gameObject.SetActive(true);

            _optionsView.alpha = 0;
            _optionsView
                .LeanAlpha(1, _animationTime);
        }
        public override void Hide()
        {
            _optionsView
                .LeanAlpha(0, _animationTime)
                .setOnComplete(() => gameObject.SetActive(false));
        }

        private void SetSoundActive(bool value) =>
            _soundSpriteHolder.sprite = value ? _soundOnSprite : _soundOffSprite;
        private void SetMusicActive(bool value) =>
            _musicSpriteHolder.sprite = value ? _musicOnSprite : _musicOffSprite;
    }
}
