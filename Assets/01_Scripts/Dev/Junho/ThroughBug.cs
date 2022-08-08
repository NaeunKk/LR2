using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThroughBug : MonoBehaviour
{
    [SerializeField] private GameObject _playerR;//씬에서 추가하기
    [SerializeField] private GameObject _playerL;//씬에서 추가하기
    
    [SerializeField] private float _bugTriggerTimeR = 0f;
    [SerializeField] private float _bugTriggerTimeL = 0f;

    [SerializeField] private bool _isTriggerOnR = false;//시간 초 흐르게 하는 변수
    [SerializeField] private bool _isTriggerOnL = false;//시간 초 흐르게 하는 변수

    [Header("밑의 시간 후 땅을 뚫음")]
    [SerializeField] private float ThroughStartDelayR = 3f;
    [SerializeField] private float ThroughStartDelayL = 3f;

    [Header("밑의 수치 만큼 떨어짐")]
    [SerializeField] private float FallingValue = 10f;

    private void Awake()
    { 
        _playerL = GameObject.Find("L").GetComponent<GameObject>();
        _playerR = GameObject.Find("R").GetComponent<GameObject>();
    }

    private void Update()
    {
        TimeCheck(); 
        ThroughBugRunning();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerR"))
        {
            _isTriggerOnR = true;
        }
        if(collision.gameObject.CompareTag("PlayerL"))
        {
            _isTriggerOnL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _bugTriggerTimeR = 0f;
        _bugTriggerTimeL = 0f;
        _isTriggerOnR = false;
        _isTriggerOnL = false;
    }
    
    private void TimeCheck()
    {
        if(_isTriggerOnR == true)
        {
            _bugTriggerTimeR += Time.deltaTime;
        }
        if(_isTriggerOnL == true)
        {
            _bugTriggerTimeL += Time.deltaTime;
        }
    }

    private void ThroughBugRunning()
    {
        if (_bugTriggerTimeR > ThroughStartDelayR)
        {
            Debug.Log("RRRRR");
            _playerR.transform.position = new Vector3(transform.position.x, transform.position.y-FallingValue, 0);
        }
        if (_bugTriggerTimeL > ThroughStartDelayL)
        {
            Debug.Log("LLLLL");
            _playerL.transform.position = new Vector3(transform.position.x, transform.position.y-FallingValue, 0);
        }
    }
}