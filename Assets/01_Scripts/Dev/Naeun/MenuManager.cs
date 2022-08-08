using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region option
    [Header("옵션")]
    [SerializeField] private Image _option;
    [SerializeField] private bool _optionCheck = false;
    #endregion

    #region sound
    [Header("사운드")]
    public AudioSource _audioSource;
    [SerializeField] Slider _slider;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_optionCheck)
        {
            OptionOpen();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _optionCheck)
        {
            OptionClose();
            _optionCheck = false;
        }
    }

    public void OptionOpen()
    {
        _option.gameObject.SetActive(true);
        _optionCheck = true;
    }
    public void OptionClose()
    {
        _option.gameObject?.SetActive(false);
    }

    public void GoToInGame()
    {
        SceneManager.LoadScene("P");
    }

    public void Volume()
    {
        SetMuisc(_slider.value);
    }

    private void SetMuisc(float volume)
    {
        _audioSource.volume = volume;
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
}
