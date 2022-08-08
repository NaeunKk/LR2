using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    #region 진행률
    [Header("최종 지점 Y좌표")]
    [SerializeField] private float _endPosY; // 최종 지점의 Y좌표
    private float _crtPosY; // 현재 Y좌표

    [SerializeField] private Transform _trmL; // L의 위치
    [SerializeField] private Transform _trmR; // R의 위치

    [Header("현재 진행률 표시할 텍스트")]
    public TextMeshProUGUI crtProgressTxt; // 현재 진행률 표시할 텍스트
    #endregion

    private void Start()
    {
        crtProgressTxt = GameObject.Find("Manager/Canvas/Progress").GetComponent<TextMeshProUGUI>();
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }

    private void Update()
    {
        CurrentProgress();
    }

    

    private void CurrentProgress()
    {
        if (_trmL != null && _trmR != null)
        {
            if (_trmL.position.y > _trmR.position.y)
                _crtPosY = _trmL.position.y;
            else
                _crtPosY = _trmR.position.y;

            float crtProgress = Mathf.Floor(Mathf.Lerp(0, 100, _crtPosY / _endPosY));
            crtProgressTxt.text = $"{crtProgress}%";
        }

    }

    public void LRTrm()
    {
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }
}
