using UnityEngine;

public class DontDestroyBackgroundMusic : MonoBehaviour
{
    private static DontDestroyBackgroundMusic s_dontDestroyBackgroundMusic;

    private void Awake()
    {
        if (s_dontDestroyBackgroundMusic == null)
        {
            s_dontDestroyBackgroundMusic = this;
            DontDestroyOnLoad(s_dontDestroyBackgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}