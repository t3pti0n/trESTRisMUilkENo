using TMPro;
using UnityEngine;
using TestTask_AnApp.Scripts.Abstractions;

namespace TestTask_AnApp.Scripts.Views
{
    public class MenuView : ViewBase 
    { 
        [SerializeField] private Money _money;
        [Space]
        [SerializeField] private TextMeshProUGUI _moneyText;

        private void OnEnable()
        {
            _money.OnValueChange += ChangeMoneyValue;
        }
        private void OnDisable()
        {
            _money.OnValueChange -= ChangeMoneyValue;
        }

        private void ChangeMoneyValue(int money)
        {
            _moneyText.text = _money.Value.ToString();
        }
    }
}