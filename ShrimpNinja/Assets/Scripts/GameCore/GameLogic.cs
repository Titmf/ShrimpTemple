using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;

    private void Awake()
    {
        PauseGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PauseGame();
        _gameOver.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0;
    }
}