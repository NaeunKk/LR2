using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HideBox : MonoBehaviour
{
    private bool _isHideTrigger = false;//몇 초 후 숨기게 할 시간을 키고 끄는 변수
    private float _hideTime = 0f;

    private SpriteRenderer _hideBoxSprite;

    [Header("밑의 시간 후 사라짐")]
    [SerializeField] private float HideStartDelay = 3f;


    private BoxCollider2D _hideBoxCollider;


    private void Awake()
    {
        _hideBoxSprite = GetComponent<SpriteRenderer>();
        _hideBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HidingTime();
        HidingBox();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isHideTrigger = true;
    }

    private void HidingTime()
    {
        if (_isHideTrigger == true)
        {
            _hideTime += Time.deltaTime;
        }
    }

    private void HidingBox()
    {
        if(_hideTime > HideStartDelay)
        {
            StartCoroutine(HidingDelay());
        }
    }

    IEnumerator HidingDelay()
    {
        _hideTime = 0f;
        _hideBoxSprite.DOFade(0, 2f);
        _hideBoxCollider.enabled = false;
        _isHideTrigger = false;
        yield return new WaitForSeconds(1.5f);
        _hideBoxCollider.enabled = true;
        _hideBoxSprite.DOFade(2, 2f);
        
    }



}
