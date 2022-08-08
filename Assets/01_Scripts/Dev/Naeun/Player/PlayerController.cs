using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Move
    [Header("Move")]
    private Rigidbody2D _rigidJump2D;
    [SerializeField] protected float _moveSpeed = 5;
    [SerializeField] protected float _jumpPower = 2;
    [SerializeField] private bool _isJumping = false;
    [SerializeField] private float _ray = 0.6f;
    #endregion
    #region Animation
    private Animator _pAnimator; // 애니메이터
    private Vector3 _pressedPosition = new Vector3(0, 0.5f, 0); // 누르는 걸 감지하는 위치 ( + transporm.position ) 해야함
    [SerializeField] private string _tagName; // 플레이어 태그 이름  L이면 R태그 R이면 L태그 적어넣어두면 됨
    #endregion

    protected virtual void Awake()
    {
        _rigidJump2D = GetComponent<Rigidbody2D>();
        _pAnimator = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
            SceneManager.LoadScene("Stage02");
        Debug.DrawRay(transform.position, Vector2.down * _ray, Color.red);
        PressedOn();
        Debug.DrawRay(transform.position, Vector2.down * _ray, Color.red);
    }

    protected void Jump(KeyCode key)
    {
        if (Input.GetKeyDown(key) && _isJumping == true)
        {
            _rigidJump2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    protected void JumpLimit()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector3.down, _ray, LayerMask.GetMask("Ground"));
        if (raycastHit2D.collider != null)
        {
            _isJumping = true;
        }
        else if (raycastHit2D.collider == null)
        {
            //Debug.Log("a");
            _isJumping = false;
        }
    }
    protected void Move(KeyCode key, float dir)
    {
        if (Input.GetKey(key))
        {
            _rigidJump2D.velocity = new Vector2(dir * _moveSpeed, _rigidJump2D.velocity.y);
        }
        else
            _rigidJump2D.velocity = new Vector2(0, _rigidJump2D.velocity.y);
    }

    protected void PressedOn()
    {
        Vector3 pressedPosition = _pressedPosition + transform.position; // 감지 위치
        RaycastHit2D raycastHit2D = Physics2D.Raycast(pressedPosition, Vector3.up, 1); //레이캐스트
        Debug.DrawRay(pressedPosition, Vector3.up);
        Debug.Log("a");
        if (raycastHit2D.collider != null && raycastHit2D.transform.CompareTag(_tagName))
        {
            Debug.Log("b");
            _pAnimator.SetBool("isPressed", true);
        }
        else
        {
            _pAnimator.SetBool("isPressed", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
            gameObject.transform.SetParent(collision.gameObject.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
            gameObject.transform.SetParent(null);
    }
}
