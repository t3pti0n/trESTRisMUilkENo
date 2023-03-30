using UnityEngine;

namespace TestTask_AnApp.Scripts
{
    public class Money : MonoBehaviour
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 9999;

        private int _value;

        [SerializeField] [Range(MIN_VALUE, MAX_VALUE)] private int _defaultValue;

        public int Value
        {
            get => _value;
            set
            {
                _value = Mathf.Clamp(value, MIN_VALUE, MAX_VALUE);
                OnValueChange?.Invoke(_value);
            }
        }

        public System.Action<int> OnValueChange;

        private void Start()
        {
            Value = _defaultValue;
        }
    }
}