using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class IsPressed : MonoBehaviour
{
    private Animator _pAnimator; // 애니메이터
    private Vector3 _pressedPosition = new Vector3(0, 0.5f, 0); // 누르는 걸 감지하는 위치 ( + transporm.position ) 해야함
    [SerializeField] private string _tagName; // 플레이어 태그 이름  L이면 R태그 R이면 L태그 적어넣어두면 됨

    // Start is called before the first frame update
    void Start()
    {
        _pAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PressedOn();
        
    }

    private void PressedOn()
    {
        Vector3 pressedPosition = _pressedPosition + transform.position; // 감지 위치
        RaycastHit2D raycastHit2D = Physics2D.Raycast(pressedPosition, Vector3.up, 1); //레이캐스트
        Debug.DrawRay(pressedPosition, Vector3.up);
        if (raycastHit2D.collider != null && raycastHit2D.transform.CompareTag(_tagName))
        {
            _pAnimator.SetBool("isPressed", true);
        }
        else
        {
            _pAnimator.SetBool("isPressed", false);
        }
    }
}
