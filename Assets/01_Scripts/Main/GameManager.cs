using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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

    private TextMeshProUGUI crtProgressTxt; // 현재 진행률 표시할 텍스트

    private int test = 0;

    public int _stage
    {
        get => test;
        set
        {
            Debug.Log($"스테이지 값 변경 {value}");
            test = value;
        }
    }

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

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _option = GameObject.Find("Manager/Canvas/Option").GetComponent<Image>();
        _slider = GameObject.Find("Manager/Canvas/Option/Sound").GetComponent<Slider>();
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
        crtProgressTxt.gameObject.SetActive(true);
        SceneManager.LoadScene("P");
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
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
