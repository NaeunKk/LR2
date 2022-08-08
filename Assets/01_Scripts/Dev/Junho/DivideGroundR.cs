using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideGroundR : MonoBehaviour
{
    [SerializeField] private float _returnGroundR = 2f;
    
    private BoxCollider2D _divideGroundColliderR;

    private void Awake()
    {
        _divideGroundColliderR = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerL"))
        {
            StartCoroutine(ReGroundR());
        }
        
    }

    IEnumerator ReGroundR()
    {
        _divideGroundColliderR.enabled = false;
        yield return new WaitForSeconds(_returnGroundR);
        _divideGroundColliderR.enabled = true;
    }
}
