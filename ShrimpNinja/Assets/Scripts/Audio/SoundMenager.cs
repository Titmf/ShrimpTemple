using UnityEngine;
using UnityEngine.UI;

public class SoundMenager : MonoBehaviour
{
    [SerializeField] private Image _soundOnIcon;
    [SerializeField] private Image _soundOffIcon;
    
    private bool _muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("_muted"))
        {
            PlayerPrefs.SetInt("_muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        
        AudioListener.pause = _muted;
        UpdateButtonIcon();
    }

    public void OnButtonPress()
    {
        if (_muted == false)
        {
            _muted = true;
            AudioListener.pause = true;
        }

        else
        {
            _muted = false;
            AudioListener.pause = false;
        }
        
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (_muted == false)
        {
            _soundOnIcon.enabled = true;
            _soundOffIcon.enabled = false;
        }
        
        else
        {
            _soundOnIcon.enabled = false;
            _soundOffIcon.enabled = true;
        }
        
    }

    private void Load()
    {
        _muted = PlayerPrefs.GetInt("_muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("_muted", _muted ? 1 : 0);
    }
}