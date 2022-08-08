using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage02Clear : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    GameObject _L;
    GameObject _R;

    UIManager _ui;

    private void Awake()
    {
        _ui = GameObject.Find("UIManager").GetComponent<UIManager>();
        _L = GameObject.Find("L");
        _R = GameObject.Find("R");
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerR"))
            _playerR = true;
        if (collision.gameObject.CompareTag("PlayerL"))
            _playerL = true;
    }

    private void Update()
    {
        if (_playerL == true && _playerR == true)
        {
            GameManager.Instance._stage = 2;
            _ui.crtProgressTxt.gameObject.SetActive(true);
            SceneManager.LoadScene("P");
            _ui.LRTrm();
        }
    }
}
