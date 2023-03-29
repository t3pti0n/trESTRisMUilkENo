using UnityEngine;

namespace TestTask_AnApp.Scripts
{
    public class Money : MonoBehaviour
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 9999;

        private int _value;

        [SerializeField] [Range(MIN_VALUE, MAX_VALUE)] private int DefaultValue;

        public int Value
        {
            get => _value;
            set
            {
                _value = Mathf.Clamp(value, MIN_VALUE, MAX_VALUE);
                OnValueChange?.Invoke(_value);
            }
        }

        public System.Action<int> OnValueChange { get; }
    }
}