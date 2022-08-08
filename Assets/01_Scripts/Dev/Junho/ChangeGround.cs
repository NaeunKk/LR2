using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeGround : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _errorGroundImage;
    [SerializeField] private SpriteRenderer _clearGroundImage;
    [SerializeField] private SpriteRenderer _changeGroundImage;

    [SerializeField] private GameObject _changeGround;

    [SerializeField] private BoxCollider2D _changeGroundBoxCollider;

    [SerializeField] private bool _isGroundChange = false; //false == Error, true == Clear

    [Header("밑의 시간 후 발판 변경")]
    [SerializeField] private float _changeDelay = 3f;

    private void Awake()
    {
        _errorGroundImage = GameObject.Find("ErrorGround").GetComponent<SpriteRenderer>();
        _clearGroundImage = GameObject.Find("ClearGround").GetComponent<SpriteRenderer>();

        _changeGroundImage = _changeGround.GetComponent<SpriteRenderer>();
        _changeGroundBoxCollider = _changeGround.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        StartCoroutine("ChangeDelay");
    }

    private void Update()
    {
        GroundChange();
        AbleGround();
    }

    private void GroundChange()
    {
        if(_isGroundChange == false)
        {
            _changeGroundImage.sprite = _errorGroundImage.sprite;
        }
        if(_isGroundChange == true)
        {
            _changeGroundImage.sprite = _clearGroundImage.sprite;
        }
    }

    private void AbleGround()
    {
        if(_isGroundChange == false)
        {
            _changeGroundBoxCollider.enabled = false;
        }
        if(_isGroundChange == true)
        {
            _changeGroundBoxCollider.enabled = true;
        }
    }

    IEnumerator ChangeDelay()
    {
        while (true)
        {
            _isGroundChange = true;
            yield return new WaitForSeconds(_changeDelay);
            _isGroundChange = false;
            yield return new WaitForSeconds(_changeDelay);
        }
    }

}
