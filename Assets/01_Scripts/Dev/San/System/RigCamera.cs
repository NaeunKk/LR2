using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RigCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _objL;
    [SerializeField]
    private GameObject _objR;

    private Transform _transform;
    [SerializeField]
    private float _posX = 0;

    private CinemachineVirtualCamera _rigCam;

    private void Start()  
    {
        _transform = GetComponent<Transform>();
        _rigCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        RigCam();
    }
    private void RigCam()
    {
        float posY = (_objL.transform.position.y + _objR.transform.position.y) / 2;
        _transform.position = new Vector3(_posX, posY, -10);

        float otho = _rigCam.m_Lens.OrthographicSize;
        float halfHeigth = otho * 9 / 16;

        float posYL = _objL.transform.position.y;
        float posYR = _objR.transform.position.y;
        float crtMaxPosY = _transform.position.y + halfHeigth;
        float crtMinPosY = _transform.position.y - halfHeigth;
        float h = 3f * Time.deltaTime;

        if (posYL > crtMaxPosY + h || posYL < crtMinPosY - h || posYR > crtMaxPosY + h || posYR < crtMinPosY - h)
        {
            _rigCam.m_Lens.OrthographicSize += h;
        }
        else if (posYL > crtMaxPosY - h || posYL < crtMinPosY + h || posYR > crtMaxPosY - h || posYR < crtMinPosY + h)
        {

        }
        else if (otho > 5)
        {
            _rigCam.m_Lens.OrthographicSize -= h;
            if (_rigCam.m_Lens.OrthographicSize < 5)
                _rigCam.m_Lens.OrthographicSize = 5;
        }
    }
}
