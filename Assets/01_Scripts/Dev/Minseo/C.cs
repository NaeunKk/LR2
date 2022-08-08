using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
        [SerializeField] GameObject _PlayerR;

        private void Start()
        {
            _PlayerR = GameObject.Find("R");
        }
        private void Update()
        {
            Vector3 PlayerPos = _PlayerR.transform.position;
            transform.position = new Vector3(transform.position.x, PlayerPos.y, transform.position.z);
        }
    
}
