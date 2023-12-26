using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCounter;
    [SerializeField] private TextMeshProUGUI _bestScoreCounter;
    
    public ShrimpGameLogic _shrimpGameLogic;

    void Awake()
    {
        _shrimpGameLogic.OnScoreChanged += ChangeScoreText;
        _shrimpGameLogic.ThenShowBestScore += ChangeBestScoreText;
    }
    private void ChangeBestScoreText(int amount)
    {
        _bestScoreCounter.text = "Best Score: " + amount.ToString();
    }

    private void ChangeScoreText(int amount)
    {
        _scoreCounter.text = amount.ToString();
    }

    private void OnDestroy()
    {
        _shrimpGameLogic.OnScoreChanged -= ChangeScoreText;
        _shrimpGameLogic.ThenShowBestScore -= ChangeBestScoreText;
    }
}