using UnityEngine;

namespace TestTask_AnApp.Scripts
{
    public class Options : MonoBehaviour
    {
        [SerializeField] private bool _isSoundOn;
        [SerializeField] private bool _isMusicOn;
        [Space]
        [SerializeField] private Transform _sounds;
        [SerializeField] private AudioSource _musicSource;
        [Space]
        [SerializeField] private AudioClip _currentBackgroundMusic;

        private AudioSource[] _soundSources;

        public bool IsSoundOn 
        { 
            get => _isSoundOn; 
            set
            {
                if (_isSoundOn == value)
                    return;

                _isSoundOn = value;

                SetSoundsMute(!_isSoundOn);
            }
        }
        public bool IsMusicOn 
        { 
            get => _isMusicOn; 
            set
            {
                if (_isMusicOn == value)
                    return;

                _isMusicOn = value;

                if (_isMusicOn)
                    _musicSource.Play();
                else
                    _musicSource.Stop();
            }
        }

        public AudioClip CurrentBackgroundMusic
        {
            get => _currentBackgroundMusic;
            set
            {
                _currentBackgroundMusic = value;
                _musicSource.clip = _currentBackgroundMusic;
            }
        }

        private void Awake()
        {
            _soundSources = _sounds.GetComponentsInChildren<AudioSource>();
            _musicSource.clip = _currentBackgroundMusic;
        }

        private void Start()
        {
            if (_isMusicOn)
                _musicSource.Play();
        }
    
        private void SetSoundsMute(bool isMuted)
        {
            foreach (var soundSource in _soundSources)
                soundSource.mute = isMuted;
        }
    }
}
