using GameCore;

using UnityEngine;
using UnityEngine.UI;

public class NinjaFoodGameLogic : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private int _scoreCheckpointForCoins;
    [SerializeField] private int _AddCoinsAmount;
    [SerializeField] private ShopItemSo CurrentSkinSo;
    [SerializeField] private Image CurrentSkinImage;
    
    private int _score;
    private int _bestScore;

    public SticksMovement _sticksMovement;

    public delegate void AddToScoreDelegate(int amount);
    public event AddToScoreDelegate OnScoreChanged;
    
    public delegate void ShowBestScoreDelegate(int amount);
    public event ShowBestScoreDelegate ThenShowBestScore;
    
    public delegate void AddCoinsDelegate(int amount);
    public event AddCoinsDelegate OnScoreCheckpoints;

    private void Awake()
    {
        _sticksMovement.ThenDodged += AddCountToScore;
        
        PauseGame();
    }
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("_bestScore"))
        {
            PlayerPrefs.SetInt("_bestScore", 0);
            LoadBestScore();
        }
        else
        {
            LoadBestScore();
        }
        
        CurrentSkinImage.sprite = CurrentSkinSo._sprite;
    }
    
    public void StartNewGame()
    {
        UnPauseGame();
        
        _score = 0;
        OnScoreChanged?.Invoke(_score);
        
        _sticksMovement.StartGame(); 
    }
    
    private void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PauseGame();
        
        _sticksMovement.StopGame();
        
        _gameOver.SetActive(true);
        
        ThenShowBestScore?.Invoke(_bestScore);
    }

    private void AddCountToScore(int addedCount)
    {
        _score += addedCount;

        OnScoreChanged?.Invoke(_score);

        if (_score % _scoreCheckpointForCoins == 0)
        {
            OnScoreCheckpoints?.Invoke(_AddCoinsAmount);
        }
        
        if (_score > _bestScore)
        {
            _bestScore = _score;
            
            SaveBestScore();
        }
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    private void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt("_bestScore");
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("_bestScore", _bestScore);
    }
    
    private void OnDestroy()
    {
        _sticksMovement.ThenDodged -= AddCountToScore;
    }
}