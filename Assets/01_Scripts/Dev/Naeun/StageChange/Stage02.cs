using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage02 : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    [SerializeField] GameObject L;
    [SerializeField] GameObject R;

    UIManager _ui;

    BoxCollider2D _stage2BoxCollider;

    private void Awake()
    {
        _stage2BoxCollider = GetComponent<BoxCollider2D>();
        _ui = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Start()
    {
        _ui.LRTrm();
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
            _ui.crtProgressTxt.gameObject.SetActive(false);
            SceneManager.LoadScene("Stage02");
            GameManager.Instance._stage = 0;
        }
        DeleteBar();

    }
    private void DeleteBar()
    {
        if (DeleteStageBar._isStage2Bar == true)
        {
            _stage2BoxCollider.gameObject.SetActive(false);
        }
    }
}
