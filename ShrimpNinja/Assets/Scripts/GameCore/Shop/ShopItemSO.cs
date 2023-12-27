using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "Shop Item N", menuName = "Scriptable Objects/New Shop Item", order = 1)]
    public class ShopItemSo : ScriptableObject
    {
        [Header("Item price")]
        [Space(10)]
        public int _price;
        
        [Header("Item Image")]
        [Space(10)]
        public Sprite _sprite;
    }
}