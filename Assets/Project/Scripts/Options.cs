using System.Net.Sockets;
using System.Collections.Specialized;
using UnityEngine;

namespace TestTask_AnApp.Scripts
{
    public class Options : MonoBehaviour
    {
        [SerializeField] private bool _isSoundOn;
        [SerializeField] private bool _isMusicOn;

        public bool IsSoundOn 
        { 
            get => _isSoundOn; 
            set
            {
                _isSoundOn = value;
                Debug.Log($"Sound: {_isSoundOn}");
            }
        }
        public bool IsMusicOn 
        { 
            get => _isMusicOn; 
            set
            {
                _isMusicOn = value;
                Debug.Log($"Music: {_isMusicOn}");
            }
        }
    }
}
