using UnityEngine;

namespace TestTask_AnApp.Scripts.Testing
{
    public class MoneyTest : MonoBehaviour
    {
        [SerializeField] private Money _money;
        [SerializeField] [Range(0, 1000)] private int _dirtyMoneyValue = 98;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                _money.Value += _dirtyMoneyValue;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                _money.Value -= _dirtyMoneyValue;
        }
    }
}
