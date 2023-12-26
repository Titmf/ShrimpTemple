﻿using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    [CreateAssetMenu(fileName = "Shop Item N", menuName = "Scriptable Objects/New Shop Item", order = 1)]
    public class ShopItem : ScriptableObject
    {
        [Header("Item price")]
        [Space(10)]
        public int _price;
        
        [Header("Item Image")]
        [Space(10)]
        public Image _image;
    }
}