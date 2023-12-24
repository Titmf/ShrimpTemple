using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0;
        _gameOver.SetActive(true);
    }
}