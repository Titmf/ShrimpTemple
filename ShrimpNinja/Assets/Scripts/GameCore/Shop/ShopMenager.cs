using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Shop
{
    public class ShopMenager : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private ShopItemSo[] _shopItemSo;

        [Space(10)]
        [SerializeField] private ShopItemTemplate[] _shopItemTemplates;

        [Space(10)]
        [SerializeField] private Button[] _shopButtons;

        [Space(10)] [SerializeField] private ShopItemSo CurrentSkin;
        
        private int _money;
        
        public delegate void SpendMoneyDelegate(int amount);
        public event SpendMoneyDelegate OnMoneySpended;
        
        private void Start()
        {
            LoadPanels();
            
            if (!PlayerPrefs.HasKey("_money"))
            {
                PlayerPrefs.SetInt("_money", 0);
                LoadMoneyCount();
            }
            else
            {
                LoadMoneyCount();
            }
            
            OnMoneySpended?.Invoke(_money);
            CheckPurchasable();
        }

        public void BuySomething(int NumberButton)
        {
            _money -= _shopItemSo[NumberButton]._price;
            
            OnMoneySpended?.Invoke(_money);

            _shopItemSo[NumberButton]._price = 0;

            CurrentSkin._sprite = _shopItemSo[NumberButton]._sprite;
            
            LoadPanels();
            
            CheckPurchasable();
        }

        private void CheckPurchasable()
        {
            for (int i = 0; i < _shopItemSo.Length; i++)
            {
                if (_money >= _shopItemSo[i]._price)
                {
                    _shopButtons[i].interactable = true;
                }
                else
                {
                    _shopButtons[i].interactable = false;
                }
            }
        }

        private void LoadPanels()
        {
            for (int i = 0; i < _shopItemSo.Length; i++)
            {
                _shopItemTemplates[i]._foodSkin.sprite = _shopItemSo[i]._sprite;
                _shopItemTemplates[i]._costText.text = "Coins: " + _shopItemSo[i]._price;
                if (_shopItemSo[i]._price == 0)
                {
                    _shopItemTemplates[i]._costText.text = "Owned";
                }
            }
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
            SaveMoneyCount();
        }
    }
}