using GameCore;

using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCounter;
    [SerializeField] private TextMeshProUGUI _bestScoreCounter;
    [SerializeField] private TextMeshProUGUI _coinCounter;

    public NinjaFoodGameLogic _ninjaFoodGameLogic;
    public CoinPocket _CoinPocket;

    void Awake()
    {
        _ninjaFoodGameLogic.OnScoreChanged += ChangeScoreText;
        _ninjaFoodGameLogic.ThenShowBestScore += ChangeBestScoreText;
        _CoinPocket.OnMoneyEarned += ChangeCoinCounterText;
    }
    
    private void ChangeCoinCounterText(int amount)
    {
        _coinCounter.text = "Coins: " + amount;
    }
    
    private void ChangeBestScoreText(int amount)
    {
        _bestScoreCounter.text = "Best Score: " + amount;
    }

    private void ChangeScoreText(int amount)
    {
        _scoreCounter.text = "Score: " + amount;
    }

    private void OnDestroy()
    {
        _ninjaFoodGameLogic.OnScoreChanged -= ChangeScoreText;
        _ninjaFoodGameLogic.ThenShowBestScore -= ChangeBestScoreText;
        _CoinPocket.OnMoneyEarned -= ChangeCoinCounterText;
    }
}