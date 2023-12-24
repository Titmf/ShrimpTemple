using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}