using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void OpenGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Main");
    }
}