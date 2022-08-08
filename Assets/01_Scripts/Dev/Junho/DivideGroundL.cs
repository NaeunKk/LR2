using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideGroundL : MonoBehaviour
{
    [SerializeField] private float _returnGroundL = 2f;

    private BoxCollider2D _divideGroundColliderL;

    private void Awake()
    {
        _divideGroundColliderL = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerR"))
        {
            StartCoroutine(ReGroundL());
        }

    }

    IEnumerator ReGroundL()
    {
        _divideGroundColliderL.enabled = false;
        yield return new WaitForSeconds(_returnGroundL);
        _divideGroundColliderL.enabled = true;
    }
}
