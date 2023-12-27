using GameCore.Shop;

using TMPro;

using UnityEngine;

namespace UI_other
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyCounter;
        
        public ShopMenager _ShopMenager;
        
        void Awake()
        {
            _ShopMenager.OnMoneySpended += ChangeMoneyCountText;
        }
        
        private void ChangeMoneyCountText(int amount)
        {
            _moneyCounter.text = "Coins: " + amount;
        }

        private void OnDestroy()
        {
            _ShopMenager.OnMoneySpended -= ChangeMoneyCountText;
        }
    }
}