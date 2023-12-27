using UnityEngine;

namespace GameCore
{
    public class CoinPocket : MonoBehaviour
    {
        public NinjaFoodGameLogic _NinjaFoodGameLogic;

        private int _money;
        
        public delegate void EarnMoneyDelegate(int amount);
        public event EarnMoneyDelegate OnMoneyEarned;
        
        private void Awake()
        {
            _NinjaFoodGameLogic.OnScoreCheckpoints += AddMoneyToPocket;
        }

        void Start()
        {
            if (!PlayerPrefs.HasKey("_money"))
            {
                PlayerPrefs.SetInt("_money", 0);
                LoadMoneyCount();
            }
            else
            {
                LoadMoneyCount();
            }
            
            OnMoneyEarned?.Invoke(_money);
        }
        
        private void AddMoneyToPocket(int amount)
        {
            _money += amount;
            
            OnMoneyEarned?.Invoke(_money);
            
            SaveMoneyCount();
        }

        private void LoadMoneyCount()
        {
            _money = PlayerPrefs.GetInt("_money");
        }
        private void SaveMoneyCount()
        {
            PlayerPrefs.SetInt("_money", _money);
        }

        private void OnDestroy()
        {
            _NinjaFoodGameLogic.OnScoreCheckpoints -= AddMoneyToPocket;
        }
    }
}