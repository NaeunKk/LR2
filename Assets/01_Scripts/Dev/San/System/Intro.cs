using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      

public class Intro : MonoBehaviour
{
    [SerializeField]
    private string _sceneName; // 스토리 끝나고 변할 씬 이름
    [SerializeField]
    private GameObject _panel; // 이 모든 것들이 있을 패널
    [SerializeField]
    private List<float> _doTxtSecs = new List<float>(); // 텍스트별 doText 시간
    [SerializeField]
    private List<string> _txts = new List<string>(); // 나오는 텍스트
    [SerializeField]
    private List<Sprite> _sprites = new List<Sprite>(); // 뒤쪽 스프라이트

    [SerializeField]
    private TextMeshProUGUI _mainTxt; // 텍스트를 송출할 텍스트
    [SerializeField]
    private Image _image; // 스프라이트를 출력할 이미지

    [SerializeField] private AudioSource _drumSound;
    [SerializeField] private AudioSource _tadaSound;
    [SerializeField] private AudioSource _bgm;
    [SerializeField] private AudioSource _ntr;
    [SerializeField] private AudioSource _baam;

    public int num = 0;


    private void Start()
    {
        _panel.SetActive(true);
        TxtFatch();
    }
    private void Update()
    {
        TextFatch();
    }
    private void TextFatch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TxtFatch();
        }
    }
    private void DoText(TextMeshProUGUI a_text, string txt, float a_duration)
    {
        a_text.text = txt;
        a_text.maxVisibleCharacters = 0;
        DOTween.To(x => a_text.maxVisibleCharacters = (int)x, 0f, a_text.text.Length + 1, a_duration);
    }
    private void TxtFatch()
    {
        if (num >= _txts.Count)
            SceneManager.LoadScene(_sceneName);
        else
        {
            DoText(_mainTxt, _txts[num], _doTxtSecs[num]);
            if (_sprites[num] != null)
            {
                _image.sprite = _sprites[num];
                if(num == 11)
                {
                    _drumSound.Play();
                }
                if(num == 13)
                {
                    _baam.Stop();
                    _drumSound.Stop();
                    _tadaSound.Play();
                }
                if(num == 4)
                {
                    _bgm.Stop();
                    _ntr.Play();
                }
                if(num == 7)
                {
                    _ntr.Stop();
                }
                if(num == 8)
                {
                    _baam.Play();
                }
            }
            num++;
        }
    }
}
