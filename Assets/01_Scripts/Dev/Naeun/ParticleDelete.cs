using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDelete : MonoBehaviour
{
    [SerializeField] float deleteDelay = 0.3f;

    private void Update()
    {
        StartCoroutine(DeleteParticle());
    }

    IEnumerator DeleteParticle()
    {
        yield return new WaitForSeconds(deleteDelay);
        PoolingManager.Instance.Push(gameObject);
    }
}
