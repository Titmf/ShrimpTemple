using GameCore.Shop;

using TMPro;

using UnityEngine;

namespace UI_other
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyCounter;
        [SerializeField] private TextMeshProUGUI _myBestScore;
        
        public ShopMenager _ShopMenager;
        
        void Awake()
        {
            _ShopMenager.OnMoneySpended += ChangeMoneyCountText;
        }

        private void Start()
        {
            _myBestScore.text = "Your Best Score: " + PlayerPrefs.GetInt("_bestScore") + "!";
        }

        private void ChangeMoneyCountText(int amount)
        {
            _moneyCounter.text = "Your coins: " + amount;
        }

        private void OnDestroy()
        {
            _ShopMenager.OnMoneySpended -= ChangeMoneyCountText;
        }
    }
}