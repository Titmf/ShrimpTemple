using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dodgeCounter;
    
    public SticksMovement _sticksMovement;
    
    void Awake()
    {
        _sticksMovement.OnCountChange += ChangeText;
    }
    
    private void ChangeText(int amount)
    {
        _dodgeCounter.text = amount.ToString();
    }

    private void OnDestroy()
    {
        _sticksMovement.OnCountChange -= ChangeText;
    }
}