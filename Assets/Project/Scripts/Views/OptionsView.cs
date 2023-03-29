using Unity.VectorGraphics;
using UnityEngine;
using TestTask_AnApp.Scripts.Abstractions;

namespace TestTask_AnApp.Scripts.Views
{
    public class OptionsView : ViewBase
    {
        [SerializeField] private Sprite _soundOnSprite;
        [SerializeField] private Sprite _soundOffSprite;
        [SerializeField] private Sprite _musicOnSprite;
        [SerializeField] private Sprite _musicOffSprite;
        [Space]
        [SerializeField] private SVGImage _soundSpriteHolder;
        [SerializeField] private SVGImage _musicSpriteHolder;
        [Space]
        [SerializeField] private Options _options;

        public void SwitchSound()
        {
            var value = !_options.IsSoundOn;
            _options.IsSoundOn = value;
            _soundSpriteHolder.sprite = value ? _soundOnSprite : _soundOffSprite;
        }
        public void SwitchMusic()
        {
            var value = !_options.IsMusicOn;
            _options.IsMusicOn = value;
            _musicSpriteHolder.sprite = value ? _musicOnSprite : _musicOffSprite;
        }
    }
}
