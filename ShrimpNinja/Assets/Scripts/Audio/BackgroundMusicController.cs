using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicController : MonoBehaviour
{
    //[SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private Image _musicOnIcon;
    [SerializeField] private Image _musicOffIcon;
    
    private bool _musicMuted = false;
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("_musicMuted"))
        {
            PlayerPrefs.SetInt("_musicMuted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        //_backgroundMusic.volume = 0;
    }

    public void OnButtonPress()
    {
        if (_musicMuted == false)
        {
            _musicMuted = true;
            //_backgroundMusic.volume = 0;
        }

        else
        {
            _musicMuted = false;
            //_backgroundMusic.volume = 1;
        }
        
        Save();
        UpdateButtonIcon();
    }
    
    private void UpdateButtonIcon()
    {
        if (_musicMuted == false)
        {
            _musicOnIcon.enabled = true;
            _musicOffIcon.enabled = false;
        }
        
        else
        {
            _musicOnIcon.enabled = false;
            _musicOffIcon.enabled = true;
        }
        
    }

    private void Load()
    {
        _musicMuted = PlayerPrefs.GetInt("_musicMuted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("_musicMuted", _musicMuted ? 1 : 0);
    }
}